using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace PixelWorldsManager
{
    public class AccountList
    {
        public string CognitoIdentity { get; set; }
        public string lastLoginKey { get; set; }

        public object loggedOut { get; set; }
    }
    internal class Account : MainWindow
    {
        public void Save()
        {
            AccountList account = new AccountList();
            RegeditKey regedit = new RegeditKey();
            string cognitoString = regedit.CognitoAndLogin().Cognito;
            string lastLoginString = regedit.CognitoAndLogin().LastLogin;

            var AccountData = new AccountList
            {
                CognitoIdentity = cognitoString,
                lastLoginKey = lastLoginString
            };
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize<AccountList>(AccountData, options);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON file (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == true)
            File.WriteAllText(saveFileDialog.FileName, jsonString);
        }
        public void Replace()
        {
            string[] subKeysValues = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Kukouri\Pixel Worlds").GetValueNames();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            openFileDialog.ShowDialog();
            string jsonString = File.ReadAllText(openFileDialog.FileName);
            AccountList accountList = JsonSerializer.Deserialize<AccountList>(jsonString);
            string getCognito = accountList.CognitoIdentity;
            string getLastLogin = accountList.lastLoginKey;
            byte[] CognitoBytes = Encoding.Default.GetBytes(getCognito);
            byte[] LastLoginBytes = Encoding.Default.GetBytes(getLastLogin);
            string lastLoginRegName = string.Empty;
            string cognitoRegName = string.Empty;
            string loggedOutName = string.Empty;
            foreach (var item in subKeysValues)
            {
                if (item.Contains("Cognito"))
                { cognitoRegName = item; };
                if (item.Contains("lastLoginKey"))
                { lastLoginRegName = item; };
                if (item.Contains("loggedOut"))
                { loggedOutName = item; };
            }
            using (RegistryKey myKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Kukouri\Pixel Worlds", true))
            {
                if (myKey != null)
                {
                    {
                        myKey.SetValue(cognitoRegName, CognitoBytes, RegistryValueKind.Binary);
                        myKey.SetValue(lastLoginRegName, LastLoginBytes, RegistryValueKind.Binary);
                        myKey.SetValue(loggedOutName, 0, RegistryValueKind.DWord);
                        
                    }
                }
            }
        }
    }
}
