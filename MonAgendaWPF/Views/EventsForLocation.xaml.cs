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
using System.Windows.Shapes;
using EntitiesLayer;

namespace MonAgendaWPF
{
    /// <summary>
    /// Logique d'interaction pour EventsForLocation.xaml
    /// </summary>
    public partial class EventsForLocation : AbstractWindow
    {
        public EventsForLocation()
        {
            InitializeComponent();

            LocationBox.ItemsSource = App.BusinessManager.LieuxUtilises().ToList();
        }

        private void LocationBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EventsList.ItemsSource = App.BusinessManager.EvenementsPourLieu(((Lieu)LocationBox.SelectedItem).Nom);
        }

        private new void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.Window_Closing(sender, e);
        }
    }
}
