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
using BusinessLayer;
using EntitiesLayer;

namespace MonAgendaWPF
{
    /// <summary>
    /// Logique d'interaction pour PlanningElementView.xaml
    /// </summary>
    public partial class PlanningElementView : UserControl
    {
        public PlanningElementView()
        {
            InitializeComponent();


            /* pour binder il faut set le this.DataContext comme etant le PlanningElementViewModel qui lui meme fait le lien avec le business layer
             * ensuite dans le xaml, tous les champs "Content" des données doivent integrer la string "{Binding XXX}" avec XXX = Propriété définie
             * dans le ElementViewModel "pointé" par this.DataContext
             * on peut aussi specifier le mode de binding (two-way, etc) via {Binding XXXX, Mode="TwoWay"} => si j'ai bien compris, mais le two-way
             * est set par defaut, donc utile uniquement si on veut specifier un autre mode (pour read only par exemple)
             */

            /* pour implementer la liste "evenements par date", le modele associé doit renvoyer un ObservableCollection<PlanningElementViewModel> */
        }
    }
}
