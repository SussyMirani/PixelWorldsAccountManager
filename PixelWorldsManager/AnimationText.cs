using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows;

namespace PixelWorldsManager
{
    internal class AnimationText : MainWindow
    {
        //I'm sorry for this garbage code, but i can't solve bug with animation, so it's only working one
        public async void ErrorInfo()
        {
            ErrorText.Visibility = Visibility.Visible;
            await Task.Delay(TimeSpan.FromSeconds(1));

            DoubleAnimation fadeOutAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = TimeSpan.FromSeconds(1)
            };

            Storyboard.SetTarget(fadeOutAnimation, ErrorText);
            Storyboard.SetTargetProperty(fadeOutAnimation, new PropertyPath(OpacityProperty));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(fadeOutAnimation);

            storyboard.Completed += (sender, e) =>
            {
                ErrorText.Visibility = Visibility.Collapsed;
            };

            storyboard.Begin();
        }
        public async void ErrorJSONInfo()
        {
            ErrorJSON.Visibility = Visibility.Visible;
            await Task.Delay(TimeSpan.FromSeconds(1));

            DoubleAnimation fadeOutAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = TimeSpan.FromSeconds(1)
            };

            Storyboard.SetTarget(fadeOutAnimation, ErrorJSON);
            Storyboard.SetTargetProperty(fadeOutAnimation, new PropertyPath(OpacityProperty));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(fadeOutAnimation);

            storyboard.Completed += (sender, e) =>
            {
                ErrorJSON.Visibility = Visibility.Collapsed;
            };

            storyboard.Begin();
        }
    }
    
}
