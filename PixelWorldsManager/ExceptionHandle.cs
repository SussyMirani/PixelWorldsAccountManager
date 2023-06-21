using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace PixelWorldsManager
{
    internal class ExceptionHandle : Application
    {
        public partial class App : Application
        {
            void ErrorText_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
            {
                
                e.Handled = true;
            }
        }
    }
}
