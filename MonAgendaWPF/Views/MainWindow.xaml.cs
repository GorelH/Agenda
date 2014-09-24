using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MonAgendaWPF.Utils;
using MonAgendaWPF.Configuration;
using MonAgendaWPF.Resources;
using MonAgendaWPF.Views;

namespace MonAgendaWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : AbstractWindow
    {

        public static UserConfiguration UserConfiguration = new UserConfiguration();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, System.EventArgs e)
        {
            UserConfiguration = StorageUtil.Load(AppResources.CONFIGURATION_FILENAME);
            WindowConfiguration wc = AbstractWindow.getWindowConfiguration(UserConfiguration, App._currentUser, this.ToString());
            this.setWindowConfiguration(wc);
        }

        private new void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.Window_Closing(sender, e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Events events = new Events();
            WindowConfiguration wc = AbstractWindow.getWindowConfiguration(UserConfiguration, App._currentUser, events.ToString());
            events.setWindowConfiguration(wc);
            events.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Locations locations = new Locations();
            WindowConfiguration wc = AbstractWindow.getWindowConfiguration(UserConfiguration, App._currentUser, locations.ToString());
            locations.setWindowConfiguration(wc);
            locations.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Artists artists = new Artists();
            WindowConfiguration wc = AbstractWindow.getWindowConfiguration(UserConfiguration, App._currentUser, artists.ToString());
            artists.setWindowConfiguration(wc);
            artists.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            EventsForLocation eventsForLocation = new EventsForLocation();
            WindowConfiguration wc = AbstractWindow.getWindowConfiguration(UserConfiguration, App._currentUser, eventsForLocation.ToString());
            eventsForLocation.setWindowConfiguration(wc);
            eventsForLocation.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            EventManagement eventmanagement = new EventManagement();
            WindowConfiguration wc = AbstractWindow.getWindowConfiguration(UserConfiguration, App._currentUser, eventmanagement.ToString());
            eventmanagement.setWindowConfiguration(wc);
            eventmanagement.ShowDialog();
        }
    }
}
