using System;
using System.ComponentModel;
using System.Windows;
using MonAgendaWPF.Configuration;
using MonAgendaWPF.Resources;
using MonAgendaWPF.Utils;

namespace MonAgendaWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        public static UserConfiguration UserConfiguration = new UserConfiguration();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            UserConfiguration = StorageUtil.Load(AppResources.CONFIGURATION_FILENAME);
            var wc = getWindowConfiguration(UserConfiguration, App._currentUser, ToString());
            setWindowConfiguration(wc);
        }

        private new void Window_Closing(object sender, CancelEventArgs e)
        {
            base.Window_Closing(sender, e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Events events = new Events();
            WindowConfiguration wc = getWindowConfiguration(UserConfiguration, App._currentUser, events.ToString());
            events.setWindowConfiguration(wc);
            events.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Locations locations = new Locations();
            WindowConfiguration wc = getWindowConfiguration(UserConfiguration, App._currentUser, locations.ToString());
            locations.setWindowConfiguration(wc);
            locations.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Artists artists = new Artists();
            WindowConfiguration wc = getWindowConfiguration(UserConfiguration, App._currentUser, artists.ToString());
            artists.setWindowConfiguration(wc);
            artists.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            EventsForLocation eventsForLocation = new EventsForLocation();
            WindowConfiguration wc = getWindowConfiguration(UserConfiguration, App._currentUser, eventsForLocation.ToString());
            eventsForLocation.setWindowConfiguration(wc);
            eventsForLocation.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            EventManagement eventmanagement = new EventManagement();
            WindowConfiguration wc = getWindowConfiguration(UserConfiguration, App._currentUser, eventmanagement.ToString());
            eventmanagement.setWindowConfiguration(wc);
            eventmanagement.ShowDialog();
        }
    }
}
