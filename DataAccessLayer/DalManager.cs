using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesLayer;
using Commun;

namespace DataAccessLayer
{
    public class DALManager : IDal
    {

        /// <summary>
        /// The singleton instance
        /// </summary>
        private static volatile DALManager _instance;

        /// <summary>
        /// Singleton Lock
        /// </summary>
        private static object locker = new Object();

        /// <summary>
        /// 
        /// </summary>
        private IDal _dal;

        /// <summary>
        /// The connexion string
        /// </summary>
        private String _connexionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Drusy\Dropbox\ISIMA\ZZ2\ServiceReseau\ISIMA_TP_.NET\MonAgenda\DataAccessLayer\EventsAgenda.mdf;Integrated Security=True";

        public static DALProvider PROVIDER;

        /// <summary>
        /// Default constructor
        /// </summary>
        private DALManager( DALProvider provider )
        {
            switch (provider)
            {
                case DALProvider.ORACLE:
                    break;
                case DALProvider.SQLSERVER:
                    _dal = new DalSQLServer(_connexionString);
                    break;
            }
        }

        /// <summary>
        /// Singleton property
        /// </summary>
        public static DALManager Instance
        {
            get {
                if (_instance == null)
                {
                    lock (locker)
                    {
                        if (_instance == null)
                        {
                            _instance = new DALManager(PROVIDER);
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Dal property
        /// </summary>
        public IDal Dal
        {
            get { return _dal; }
            set { _dal = value; }
        }

        /// <see cref="IDal.Cs"/>
        public List<EntitiesLayer.Artiste> GetAllArtists()
        {
            return _dal.GetAllArtists();
        }

        /// <see cref="IDal.Cs"/>
        public List<EntitiesLayer.PlanningElement> GetAllPlannings()
        {
            return _dal.GetAllPlannings();
        }

        /// <see cref="IDal.Cs"/>
        public List<EntitiesLayer.Lieu> GetAllLieux()
        {
            return _dal.GetAllLieux();
        }

        /// <see cref="IDal.Cs"/>
        public List<EntitiesLayer.Evenement> GetEvenementByLieu(string lieu)
        {
            return _dal.GetEvenementByLieu(lieu);
        }

        /// <see cref="IDal.Cs"/>
        public EntitiesLayer.Utilisateur GetUtilisateurByLogin(string login)
        {
            return _dal.GetUtilisateurByLogin(login);
        }

        /// <see cref="IDal.Cs"/>
        public void Update(List<EntitiesLayer.PlanningElement> elements)
        {
            _dal.Update(elements);
        }

        /// <see cref="IDal.Cs"/>
        public List<EntitiesLayer.Evenement> GetAllEvenements()
        {
            return _dal.GetAllEvenements();
        }

        /// <see cref="IDal.Cs"/>
        public void RemovePlanning(EntitiesLayer.PlanningElement element)
        {
            _dal.RemovePlanning(element);
        }

        /// <see cref="IDal.Cs"/>
        public void AddPlanning(EntitiesLayer.PlanningElement element)
        {
            _dal.AddPlanning(element);
        }
    }
}
