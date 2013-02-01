using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    public class PlanningElement
    {
        #region Membres
        private DateTime mDateDebut;
        private DateTime mDateFin;
        private int mGUID;
        private Evenement mMonEvenement;
        private Lieu mMonLieu;
        private int mNombrePlacesReservees;
        #endregion

        public DateTime DateFin
        {
            get { return mDateFin; }
            set { mDateFin = value; }
        }

        public int GUID
        {
            get { return mGUID; }
            set { mGUID = value; }
        }

        public Evenement MonEvenement
        {
            get { return mMonEvenement; }
            set { mMonEvenement = value; }
        }

        public Lieu MonLieu
        {
            get { return mMonLieu; }
            set { mMonLieu = value; }
        }

        public int NombrePlacesReservees
        {
            get { return mNombrePlacesReservees; }
            set { mNombrePlacesReservees = value; }
        }

        public DateTime DateDebut
        {
            get { return mDateDebut; }
            set { mDateDebut = value; }
        }

        public PlanningElement(int guid, DateTime dateDebut, DateTime dateFin, Evenement monEvenement, Lieu monLieu, int nombrePlacesReservees)
        {
            mGUID = guid;
            mDateDebut = dateDebut; 
            mDateFin = dateFin;
            mMonEvenement = monEvenement;
            mMonLieu = monLieu;
            mNombrePlacesReservees = nombrePlacesReservees;
        }
    }
}
