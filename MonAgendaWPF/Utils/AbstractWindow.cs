using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using MonAgendaWPF.Configuration;
using MonAgendaWPF.Utils;
using MonAgendaWPF.Resources;

namespace MonAgendaWPF
{
    public abstract class AbstractWindow : Window
    {

        public static WindowConfiguration getWindowConfiguration(UserConfiguration uc, String username, String key)
        {
            WindowConfiguration wc = null;
            try
            {
                if (uc != null)
                    wc = uc.GetApplicationconfigurationFromUsername(username).WindowsConfiguration[key];
            }
            catch (KeyNotFoundException) { }
            return wc;
        }

        public void setWindowConfiguration(WindowConfiguration wc)
        {
            if (wc != null)
            {
                this.Width = wc.Width;
                this.Height = wc.Height;
                this.Left = wc.Position.X;
                this.Top = wc.Position.Y;
            }
            else
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
        }

        protected void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            WindowConfiguration ws = AbstractWindow.getWindowConfiguration(MainWindow.UserConfiguration, App._currentUser, sender.ToString());
            if (ws == null)
            {
                ws = new WindowConfiguration();
                MainWindow.UserConfiguration.GetApplicationconfigurationFromUsername(App._currentUser).WindowsConfiguration.Add(sender.ToString(), ws);
            }

            ws.Width = ActualWidth;
            ws.Height = ActualHeight;
            ws.Position = new Point(Left, Top);

            StorageUtil.Save(MainWindow.UserConfiguration, AppResources.CONFIGURATION_FILENAME);
        }

    }
}
