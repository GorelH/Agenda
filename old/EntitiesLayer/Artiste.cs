using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    public class Artiste
    {
        #region Membres
        private DateTime mDateNaissance;
        private int mGUID;
        private string mNom;
        private string mPrenom;
        #endregion

        /// <summary>
        /// Date de naissance de l'artiste
        /// </summary>
        public DateTime DateNaissance
        {
            get
            {
                return mDateNaissance;
            }
            set
            {
                mDateNaissance = value;
            }
        }

        /// <summary>
        /// Global user identifier
        /// </summary>
        public int GUID
        {
            get
            {
                return mGUID;
            }
            set
            {
                mGUID = value;
            }
        }

        /// <summary>
        /// Nom de l'artiste
        /// </summary>
        public string Nom
        {
            get
            {
                return mNom;
            }
            set
            {
                mNom = value;
            }
        }

        /// <summary>
        /// Prénom de l'artiste
        /// </summary>
        public string Prenom
        {
            get
            {
                return mPrenom;
            }
            set
            {
                mPrenom = value;
            }
        }

        /// <summary>
        /// Constructeur de l'artiste
        /// </summary>
        /// <param name="GUID">Global User Identifier de l'artiste</param>
        /// <param name="nom">Nom de l'artiste</param>
        /// <param name="prenom">Prénom de l'artiste</param>
        /// <param name="dateNaissance">Date de naissance de l'artiste</param>
        public Artiste(int GUID, string nom, string prenom, DateTime dateNaissance)
        {
            mGUID = GUID;
            mNom = nom;
            mPrenom = prenom;
            mDateNaissance = dateNaissance;
        }

        /// <summary>
        /// Sérialise l'artiste en chaîne de caractère
        /// </summary>
        /// <returns>Artiste sérialisé</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(mGUID).Append(" ").Append(mNom).Append(" ").Append(mPrenom).Append(" ").Append(mDateNaissance);

            return sb.ToString();
        }
    }
}
