﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StubDataAccessLayer;
using EntitiesLayer;


namespace BusinessLayer
{
    public class BusinessManager
    {
        #region Membres
        DalManager mDalManager = new DalManager();
        #endregion

        public BusinessManager()
        {
        }

        public List<Lieu> GetLieu()
        {
            return mDalManager.Lieux;
        }

        public List<PlanningElement> GetPlanningElements()
        {
            return mDalManager.Plannings;
        }

        public List<string> AfficherEvenements()
        {
            List<string> requete = new List<string>();
            requete = (from planningEl in mDalManager.Plannings
                                    orderby planningEl.DateDebut
                                    select planningEl.MonEvenement.Description + " - " + planningEl.DateDebut.ToString() + " - " +planningEl.MonLieu.Nom).ToList();
            return requete;

        }

        public List<string> AfficherArtistes()
        {
            List<string> requete = new List<string>();
            requete = (from artiste in mDalManager.Artistes
                       orderby artiste.Nom
                       select artiste.Prenom + " " + artiste.Nom).ToList();
            return requete;
        }

        public List<string> AfficherLieuEvenementsProgrammes()
        {
            List<string> listeLieu = (from planingEl in mDalManager.Plannings
                                     select planingEl.MonLieu.Nom).Distinct().ToList();
            return listeLieu;
        }

        public List<string> AfficherEvenementsLieux(Lieu lieu)
        {
            List<string> listeLieu =
                (from planningEl in mDalManager.Plannings
                where planningEl.MonLieu == lieu
                orderby planningEl.DateFin
                select planningEl.MonEvenement.Titre + " - " + planningEl.DateDebut.ToShortDateString() + " - " + planningEl.MonLieu.Ville).ToList();
            return listeLieu;
        }

        public Lieu GetLieuParNom(string nom)
        {
            Lieu lieu = mDalManager.Lieux.First(l => nom == l.Nom);
            return lieu;
        }

        public User Connection(string login, string password)
        {
            try
            {
                User u = mDalManager.getUserByLogin(login);
                if (u.Password == password)
                {
                    return u;
                }
                else
                {
                    return null;
                }
            }
            catch (UserNotFoundException)
            {
                return null;
            }
        }
    }
}
