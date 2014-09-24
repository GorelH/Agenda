using System.Linq;

namespace MonAgendaWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour Artists.xaml
    /// </summary>
    public partial class Artists : AbstractWindow
    {
        public Artists()
        {
            InitializeComponent();

            EventsList.ItemsSource = App.BusinessManager.ArtistesAssocies().ToList();
        }

        private new void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.Window_Closing(sender, e);
        }
    }
}
