using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    public abstract class Evenement
    {
        #region
        private List<Artiste> mArtistes = new List<Artiste>();

        public List<Artiste> Artistes
        {
            get { return mArtistes; }
            set { mArtistes = value; }
        }
        private string mDescription;

        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }
        private int mGUID;

        public int GUID
        {
            get { return mGUID; }
            set { mGUID = value; }
        }
        private float mTarif;

        public float Tarif
        {
            get { return mTarif; }
            set { mTarif = value; }
        }
        private string mTitre;

        public string Titre
        {
            get { return mTitre; }
            set { mTitre = value; }
        }
        #endregion

        public abstract float CalculerTarif();

        public Evenement(int guid, List<Artiste> artistes, string description, float tarif, string titre)
        {
            mGUID = guid;
            mArtistes = artistes;
            mDescription = description;
            mTarif = tarif;
            mTitre = titre;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(mGUID).Append(" ").Append(mDescription).Append(mTarif).Append(" ").Append(mTitre).Append("\nArtistes présents : ");
            foreach (Artiste artiste in mArtistes)
            {
                sb.Append(mArtistes).Append("\n");
            }

            return sb.ToString();
        }
    }
}
