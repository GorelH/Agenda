using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesLayer;
using System.Data;

namespace DataAccessLayer
{
    public interface IDal
    {
        /// <summary>
        /// Requete en base de donnée
        /// </summary>
        /// <returns>Liste des artistes</returns>
        List<Artiste> GetAllArtists();
        /// <summary>
        /// Requete en base de donnée
        /// </summary>
        /// <returns>Liste des plannings</returns>
        List<PlanningElement> GetAllPlannings();
        /// <summary>
        /// Requete en base de donnée
        /// </summary>
        /// <returns>Liste des lieux</returns>
        List<Lieu> GetAllLieux();
        /// <summary>
        /// Requete en base de donnée
        /// </summary>
        /// <param name="lieu">Lieu désiré</param>
        /// <returns>Evenements associé au lieu</returns>
        List<Evenement> GetEvenementByLieu(String lieu);
        /// <summary>
        /// Requete en base de donnée
        /// </summary>
        /// <returns>Liste des événements</returns>
        List<Evenement> GetAllEvenements();
        /// <summary>
        /// Requete en base de donnée
        /// </summary>
        /// <param name="login">login désité</param>
        /// <returns>Utilisateur lié au login</returns>
        Utilisateur GetUtilisateurByLogin(String login);
        /// <summary>
        /// Requete en base de donnée
        /// </summary>
        /// <param name="element">Element à supprimer</param>
        void RemovePlanning(PlanningElement element);
        /// <summary>
        /// Requete en base de donnée
        /// </summary>
        /// <param name="element">Element à ajouter</param>
        void AddPlanning(PlanningElement element);
        /// <summary>
        /// Requete en base de donnée
        /// </summary>
        /// <param name="elements">ELements à mettre à jour</param>
        void Update(List<PlanningElement> elements);
    }
}
