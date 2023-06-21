using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace PixelWorldsManager
{
    public class ExceptionTimer
    {
        public void Main()
        {
            Timer t = new Timer();
            t.Interval = 1; 
            t.AutoReset = false; 
            t.Elapsed += new ElapsedEventHandler(TimerElapsed);
            t.Start();
        }

        void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.ErrorText.Visibility = Visibility.Hidden;
        }
    }
}
