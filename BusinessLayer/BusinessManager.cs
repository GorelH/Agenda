using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesLayer;
//using StubDataAccessLayer;
using DataAccessLayer;
using Commun;

namespace BusinessLayer
{
    /// <summary>
    /// Business layer
    /// </summary>
    public class BusinessManager
    {
        /// <summary>
        /// DataAcessLayer
        /// </summary>
        private DALManager _DALManager;

        public DALManager DALManager
        {
            get { return _DALManager; }
            set { _DALManager = value; }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public BusinessManager()
        {
            DALManager.PROVIDER = DALProvider.SQLSERVER;
            _DALManager = DALManager.Instance;
        }

        /// <summary>
        /// Retourne la liste des événements ordonnés par date.
        /// </summary>
        /// <returns>La liste des événements</returns>
        public IEnumerable<PlanningElement> EvenementsClassesDate()
        {
            return (from plan in DALManager.GetAllPlannings()
                    orderby plan.DateDebut
                    select plan).ToList();
        }

        /// <summary>
        /// Retourne la liste des artistes triés par nom.
        /// </summary>
        /// <returns>La liste des artistes.</returns>
        public IEnumerable<String> ArtistesAssocies()
        {

            IEnumerable<String> list = new List<String>();
            ICollection<Evenement> events = DALManager.GetAllEvenements();

            list = (from e in events from a in e.Artistes orderby a.Nom select a.Nom).Distinct();

            return list;
        }

        /// <summary>
        /// Retourne la liste des lieux auquels sont ratéchés un ou plusieurs événements.
        /// </summary>
        /// <returns>La liste de lieux.</returns>
        public IEnumerable<Lieu> LieuxUtilises()
        {
            IEnumerable<Lieu> list = new List<Lieu>();
            ICollection<PlanningElement> events = DALManager.GetAllPlannings();

            list = (from e in events orderby e.MonLieu.Nom select e.MonLieu).Distinct();

            return list;
        }

        /// <summary>
        /// Retourne la liste des événements pour un lieu précis ordonnés par date.
        /// </summary>
        /// <param name="location">Le lieu de recherche.</param>
        /// <returns>La liste.</returns>
        public IEnumerable<String> EvenementsPourLieu(String lieu)
        {

            IEnumerable<String> list = new List<String>();
            ICollection<PlanningElement> events = DALManager.GetAllPlannings();

            list = (from e in events where e.MonLieu.Nom == lieu orderby e.DateDebut select e.MonEvenement.Titre).Distinct();

            return list;

        }

        /// <summary>
        /// Valide la connexion utilisateur
        /// </summary>
        /// <param name="login">Login</param>
        /// <param name="password">Password (sha1)</param>
        /// <returns></returns>
        public bool CheckUserConnection(string login, string password)
        {
#if DEBUG
            return true;
#endif
            bool value = false;

            try
            {
                Utilisateur user = DALManager.GetUtilisateurByLogin(login);

                if (user != null && user.Password == password)
                    value = true;
            }
            catch (Exception)
            {
                value = false;
            }

            return value;
        }

        /// <summary>
        /// Recherche le premier lieu utilisé
        /// </summary>
        /// <returns>Premier lieu utilisé</returns>
        public Guid GetFirstPlaceGuid()
        {
            return LieuxUtilises().First().Guid;
        }

        /// <summary>
        /// Supprime un planning
        /// </summary>
        /// <param name="element">Planning a supprimer</param>
        public void RemovePlanning(PlanningElement element)
        {
            DALManager.RemovePlanning(element);
        }

        /// <summary>
        /// Ajoute un planning
        /// </summary>
        /// <param name="element">Planning a ajouter</param>
        public void AddPlanning(PlanningElement element)
        {
            DALManager.AddPlanning(element);
        }

        /// <summary>
        /// Met la base à jour
        /// </summary>
        /// <param name="elements">Elements à mettre à jour</param>
        public void Update(List<PlanningElement> elements)
        {
            DALManager.Update(elements);
        }
    }
}
