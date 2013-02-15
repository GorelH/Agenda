using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesLayer;
using Commun;

namespace StubDataAccessLayer
{
    /// <summary>
    /// StubDataAccessLayer
    /// </summary>
    public class DALManager
    {
        /// <summary>
        /// Liste des artistes
        /// </summary>
        private IList<Artiste> _artistes = new List<Artiste>();
        /// <summary>
        /// Liste des utilisateurs
        /// </summary>
        private IList<Utilisateur> _utilisateurs = new List<Utilisateur>();
        /// <summary>
        /// Liste des événements
        /// </summary>
        private IList<Evenement> _evenements = new List<Evenement>();
        /// <summary>
        /// Liste des lieux
        /// </summary>
        private IList<Lieu> _lieux = new List<Lieu>();
        /// <summary>
        /// Liste des plannings
        /// </summary>
        private IList<PlanningElement> _plannings = new List<PlanningElement>();
        /// <summary>
        /// Type of dal, useless in stub mode
        /// </summary>
        public static DALProvider PROVIDER;

        /// <summary>
        /// The singleton instance
        /// </summary>
        private static volatile DALManager _instance;

        /// <summary>
        /// Singleton Lock
        /// </summary>
        private static object locker = new Object();

        /// <summary>
        /// Singleton property
        /// </summary>
        public static DALManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (locker)
                    {
                        if (_instance == null)
                        {
                            _instance = new DALManager();
                        }
                    }
                }
                return _instance;
            }
        }

        public IList<PlanningElement> Plannings
        {
            get { return _plannings; }
            set { _plannings = value; }
        }

        public IList<Utilisateur> Utilisateurs
        {
            get { return _utilisateurs; }
            set { _utilisateurs = value; }
        }

        public IList<Lieu> Lieux
        {
            get { return _lieux; }
            set { _lieux = value; }
        }

        public IList<Evenement> Evenements
        {
            get { return _evenements; }
            set { _evenements = value; }
        }

        public IList<Artiste> Artistes
        {
            get { return _artistes; }
            set { _artistes = value; }
        }

        public IList<Artiste> GetAllArtistes()
        {
            return Artistes;
        }

        public IList<Evenement> GetAllEvenements()
        {
            return Evenements;
        }

        public IList<Lieu> GetAllLieux()
        {
            return Lieux;
        }

        public IList<PlanningElement> GetAllPlannings()
        {
            return Plannings;
        }

        public void RemovePlanning(PlanningElement element)
        {
            Plannings.Remove(element);
        }

        public void AddPlanning(PlanningElement element)
        {
            Plannings.Add(element);
            Evenements.Add(element.MonEvenement);
        }

        /// <summary>
        /// Constructeur d'un data access layer de type MOC
        /// </summary>
        private DALManager()
        {
            Artiste tmpArt;
            IList<Artiste> tmpList = new List<Artiste>();
            IList<Artiste> tmpList2 = new List<Artiste>();

            Utilisateurs.Add(new Utilisateur("Kevin", "pass"));
            Utilisateurs.Add(new Utilisateur("alex", "pass"));

            Artistes.Add(new Artiste("Alexandre", "Mottet", new DateTime(1990, 05, 13), 0));
            Artistes.Add(new Artiste("Mikael", "Perrin", new DateTime(01, 01, 01), 1));
            Artistes.Add(new Artiste("Jeremy", "Bounynynyny", new DateTime(01, 01, 01), 2));
            Artistes.Add(new Artiste("Kévin", "Renella", new DateTime(1991, 06, 07), 3));

            tmpArt = new Artiste("Johnny", "Halliday", new DateTime(1940, 01, 01), 4);
            Artistes.Add(tmpArt);
            tmpList.Add(tmpArt);
            tmpArt = new Artiste("Wax", "Tailor", new DateTime(1960, 03, 17), 5);
            tmpList2.Add(tmpArt);

            Evenements.Add(new Exposition("Charivari", "Medieval", 15f, new Guid(), 10, Artistes));

            Evenements.Add(new Concert("Concert Johnny Halliday", "Rock", 70f, new Guid(), null, 160, 20, tmpList));
            Evenements.Add(new Concert("Wax Tailor", "Electro", 35f, new Guid(), null, 240, 2, tmpList2));

            Lieux.Add(new Lieu("", "Place du charivari", "Billom", "Quartier Medieval", 150, "charivari.fr"));
            Lieux.Add(new Lieu("", "Zénith", "Aubière", "Rue du Zénith", 8000, "zénith.fr"));
            Lieux.Add(new Lieu("", "LaCoopé", "Clermont-Ferrand", "Place du 1er mai", 3000, "lacoope.fr"));

            Plannings.Add(new PlanningElement(Evenements.First(), Lieux.First(), new DateTime(2012, 12, 01), new DateTime(2012, 12, 31), 0));
            Plannings.Add(new PlanningElement(Evenements.ElementAt(1), Lieux.ElementAt(1), new DateTime(2012, 12, 15), new DateTime(2012, 12, 15), 0));
            Plannings.Add(new PlanningElement(Evenements.ElementAt(2), Lieux.ElementAt(2), new DateTime(2013, 04, 21), new DateTime(2013, 04, 21), 0));
            Plannings.Add(new PlanningElement(Evenements.ElementAt(2), Lieux.ElementAt(2), new DateTime(2013, 04, 22), new DateTime(2013, 04, 22), 0));
            Plannings.Add(new PlanningElement(Evenements.ElementAt(2), Lieux.ElementAt(2), new DateTime(2013, 04, 23), new DateTime(2013, 04, 23), 0));
        }

        public Utilisateur GetUtilisateurByLogin(string login)
        {
            foreach (Utilisateur utilisateur in Utilisateurs)
            {
                if (utilisateur.Login == login)
                    return utilisateur;
            }

            throw new Exception("User not found");
        }
    }
}
