using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using Newtonsoft.Json;

namespace PixelWorldsManager
{
    
    public partial class MainWindow : Window

    {
        public MainWindow()
        {
            InitializeComponent();
            ErrorText.Visibility = Visibility.Hidden;
            ErrorJSON.Visibility = Visibility.Hidden;
            LoadSuccessfully.Visibility = Visibility.Hidden;
            ExtractSuccessfully.Visibility = Visibility.Hidden;

        }
        //Garbage animation code
        public void Animation(bool errorTextAnimation = false, bool errorJSONAnimation = false, bool accountExtractAnimation = false, bool accountLoadAnimation = false)
        {
            if (errorTextAnimation)
            {
                DoubleAnimation fadeAnimation = new DoubleAnimation
                {
                    From = 1.0,
                    To = 0.0,
                    Duration = TimeSpan.FromSeconds(2), 
                };

                Storyboard.SetTarget(fadeAnimation, ErrorText);
                Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath(TextBlock.OpacityProperty));

                
                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(fadeAnimation);
                storyboard.Begin();
            }
            else if (errorJSONAnimation)
            {
                DoubleAnimation fadeAnimation = new DoubleAnimation
                {
                    From = 1.0,
                    To = 0.0,
                    Duration = TimeSpan.FromSeconds(2), 
                };

                Storyboard.SetTarget(fadeAnimation, ErrorJSON);
                Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath(TextBlock.OpacityProperty));

                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(fadeAnimation);
                storyboard.Begin();
            }
            else if (accountExtractAnimation)
            {
                DoubleAnimation fadeAnimation = new DoubleAnimation
                {
                    From = 1.0,
                    To = 0.0,
                    Duration = TimeSpan.FromSeconds(2),
                };

                Storyboard.SetTarget(fadeAnimation, ExtractSuccessfully);
                Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath(TextBlock.OpacityProperty));

                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(fadeAnimation);
                storyboard.Begin();
            }
            else if (accountLoadAnimation)
            {
                DoubleAnimation fadeAnimation = new DoubleAnimation
                {
                    From = 1.0,
                    To = 0.0,
                    Duration = TimeSpan.FromSeconds(2),
                };

                Storyboard.SetTarget(fadeAnimation, LoadSuccessfully);
                Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath(TextBlock.OpacityProperty));

                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(fadeAnimation);
                storyboard.Begin();
            }
            
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Account account = new Account();
                account.Replace();
                LoadSuccessfully.Visibility = Visibility.Visible;
                Animation(accountLoadAnimation: true);
            }
            catch (Exception)
            {
                ErrorText.Visibility = Visibility.Visible;
                Animation(errorTextAnimation:true);
            }
        }
        private void ExtractAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Account account = new Account();
                account.Save();
                ExtractSuccessfully.Visibility = Visibility.Visible;
                Animation(accountExtractAnimation: true);
            }
            catch (Exception)
            {
                ErrorJSON.Visibility = Visibility.Visible;
                Animation(errorJSONAnimation:true);

            }
        }
    }
}
