using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    public class Lieu
    {
        #region Membres
        private string mAdresse;
        private string mCodePostal;
        private int mGUID;
        private string mNom;
        private int mNombrePlaces;
        private string mPays;
        private double mPourcentageCommission;
        private string mTéléphone;
        private string mVille;
        #endregion

        public int GUID
        {
            get { return mGUID; }
            set { mGUID = value; }
        }

        public string Nom
        {
            get { return mNom; }
            set { mNom = value; }
        }

        public int NombrePlaces
        {
            get { return mNombrePlaces; }
            set { mNombrePlaces = value; }
        }

        public string Pays
        {
            get { return mPays; }
            set { mPays = value; }
        }

        public double PourcentageCommission
        {
            get { return mPourcentageCommission; }
            set { mPourcentageCommission = value; }
        }

        public string Téléphone
        {
            get { return mTéléphone; }
            set { mTéléphone = value; }
        }

        public string Ville
        {
            get { return mVille; }
            set { mVille = value; }
        }

        public string Adresse
        {
            get { return mAdresse; }
            set { mAdresse = value; }
        }

        public string CodePostal
        {
            get { return mCodePostal; }
            set { mCodePostal = value; }
        }

        public Lieu(int guid, string adresse, string codePostal, string nom, int nombrePlaces, string pays, double pourcentageCommission, 
            string téléphone, string ville)
        {
            mGUID = guid;
            mAdresse = adresse;
            mCodePostal = codePostal;
            mNom = nom;
            mNombrePlaces = nombrePlaces;
            mPays = pays;
            mPourcentageCommission = pourcentageCommission;
            mTéléphone = téléphone;
            mVille = ville;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(mGUID).Append(" ").Append(mNom).Append(" ").Append(mNombrePlaces).Append(" ").Append(mPourcentageCommission).Append(" ")
                .Append(mNombrePlaces).Append(" ").Append(" ").Append(mAdresse).Append(" ").Append(mCodePostal).Append(" ").Append(mVille)
                .Append(" ").Append(mPays).Append(" ").Append(mTéléphone);

            return sb.ToString();
        }
    }
}
