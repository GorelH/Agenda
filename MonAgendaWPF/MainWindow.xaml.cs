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

/*
 * recevoir une lsite de planning element (on save)
 * le dal recoit la liste :
 * pour chaque ligne
 *  est ce qu'on ajoute ?
 *  est ce qu'on supprime ?
 *  modification ?
 *  ==>
 *  on récupère tout les id de la table
 *  tout les id de la liste
 *  on fait un diff
 *  on a ce qu'on doit faire !!!!!!!!!!!!!!!!!!!!
 */

namespace MonAgendaWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Login mLogin = new Login();
        private EvenementDate mEvDate;
        private Artistes mArtistes;
        private Lieux mLieux;
        private EvenementsParLieu mEvenementsParLieu;
        private static MainWindow instance = null;

        public static MainWindow Instance
        {
            get { return instance; }
        }

        private BusinessManager mBusinessManager;

        private User currentUser;

        public MainWindow()
        {
            instance = this;
            InitializeComponent();

            mBusinessManager = new BusinessManager();

            this.Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing);
            mLogin.Closed += login_Closed;
            
            mLogin.Show();
            this.Hide();
        }

        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (mLogin != null) mLogin.Close();
            if (mEvDate != null) mEvDate.Close();
            if (mArtistes != null) mArtistes.Close();
            if (mLieux != null) mLieux.Close();
            if (mEvenementsParLieu != null) mEvenementsParLieu.Close();
        }

        public BusinessManager BM
        {
            get { return mBusinessManager; }
        }

        public void ConnectUser(User u)
        {
            currentUser = u;
        }

        private void evenementsButton_Click(object sender, RoutedEventArgs e)
        {
            if (mEvDate == null)
            {
                mEvDate = new EvenementDate();
                mEvDate.Closed += new EventHandler(mEvDate_Closed);
            }
            mEvDate.Show();
        }

        void mEvDate_Closed(object sender, EventArgs e)
        {
            mEvDate = null;
        }

        private void artistesButton_Click(object sender, RoutedEventArgs e)
        {
            if (mArtistes == null)
            {
                mArtistes = new Artistes();
                mArtistes.Closed += new EventHandler(mArtistes_Closed);
            }
            mArtistes.Show();
        }

        void mArtistes_Closed(object sender, EventArgs e)
        {
            mArtistes = null;
        }

        private void lieuxButton_Click(object sender, RoutedEventArgs e)
        {
            if (mLieux == null)
            {
                mLieux = new Lieux();
                mLieux.Closed += new EventHandler(mLieux_Closed);
            }
            mLieux.Show();
        }

        void mLieux_Closed(object sender, EventArgs e)
        {
            mLieux = null;
        }

        private void evenementsParLieuxButton_Click(object sender, RoutedEventArgs e)
        {
            if (mEvenementsParLieu == null)
            {
                mEvenementsParLieu = new EvenementsParLieu();
                mEvenementsParLieu.Closed += new EventHandler(mEvenementsParLieu_Closed);
            }
            mEvenementsParLieu.Show();
        }

        void mEvenementsParLieu_Closed(object sender, EventArgs e)
        {
            mEvenementsParLieu = null;
        }

        private void login_Closed(object sender, EventArgs e)
        {
            if (currentUser == null)
            {
                this.Close();
            }
            else
            {
                this.Show();
            }
        }
    }
}
