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
    /// Logique d'interaction pour GestionEvenementView.xaml
    /// </summary>
    public partial class GestionEvenementView : Window
    {
        public GestionEvenementView()
        {
            InitializeComponent();
            this.Activated += new EventHandler(GestionEvenementView_Activated);
        }

        void GestionEvenementView_Activated(object sender, EventArgs e)
        {
            List<PlanningElement> plannings = MainWindow.Instance.BM.GetPlanningElements();
            this.DataContext = new GestionnaireEvenementViewModel(plannings);
        }
    }
}
