using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace PixelWorldsManager
{
    internal class RegeditKey : MainWindow
    {
        public (string Cognito, string LastLogin, object LoggedOut) CognitoAndLogin()
        {
          RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Kukouri\Pixel Worlds");
          string[] subKeyNames = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Kukouri\Pixel Worlds").GetSubKeyNames();
          string[] subKeysValues = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Kukouri\Pixel Worlds").GetValueNames();
          string getCognitoValue = String.Empty;
          string getLoginValue = String.Empty;
          string getLoggedOut = String.Empty;
            foreach (var item in subKeysValues)
          {
           if (item.Contains("Cognito"))
              { getCognitoValue = item; };
           if (item.Contains("lastLoginKey"))
              { getLoginValue = item; };
           if (item.Contains("loggedOut"))
              { getLoggedOut = item; }
          }
          byte[] dataLogin = (byte[])key.GetValue(getLoginValue);
          byte[] dataCognito = (byte[])key.GetValue(getCognitoValue);
          var dataLoggedOut = key.GetValue(getLoggedOut);
          string lastLoginKey = Encoding.ASCII.GetString(dataLogin.Select(x => (byte)x).ToArray());
          string cognitoIdentity = Encoding.ASCII.GetString(dataCognito.Select(x => (byte)x).ToArray());
          return (cognitoIdentity, lastLoginKey, dataLoggedOut);
        }
    }
}
