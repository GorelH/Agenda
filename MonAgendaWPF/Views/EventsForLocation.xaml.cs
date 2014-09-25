using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using EntitiesLayer;
using MonAgendaWPF.Utils;

namespace MonAgendaWPF.Views
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

        private new void Window_Closing(object sender, CancelEventArgs e)
        {
            base.Window_Closing(sender, e);
        }
    }
}
