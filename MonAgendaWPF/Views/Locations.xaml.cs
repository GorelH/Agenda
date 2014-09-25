using System.ComponentModel;
using System.Linq;
using MonAgendaWPF.Utils;

namespace MonAgendaWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour Locations.xaml
    /// </summary>
    public partial class Locations : AbstractWindow
    {
        public Locations()
        {
            InitializeComponent();

            EventsList.ItemsSource = App.BusinessManager.LieuxUtilises().ToList();
        }

        private new void Window_Closing(object sender, CancelEventArgs e)
        {
            base.Window_Closing(sender, e);
        }
    }
}
