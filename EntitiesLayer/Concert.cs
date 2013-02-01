using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    public class Concert : Evenement
    {
        public enum DispositionCli
        {
            SUPERSON, NORMAL
        }

        private Concert.DispositionCli mDisposition;

        public Concert.DispositionCli Disposition
        {
            get { return mDisposition; }
            set { mDisposition = value; }
        }
        private int mDureeMinute;

        public int DureeMinute
        {
            get { return mDureeMinute; }
            set { mDureeMinute = value; }
        }
        private int mNombreLoges;

        public int NombreLoges
        {
            get { return mNombreLoges; }
            set { mNombreLoges = value; }
        }

        public Concert(int guid, List<Artiste> artistes, string description, float tarif, string titre, Concert.DispositionCli disposition,
            int dureeMinute, int nombreLoges): base(guid, artistes, description, tarif, titre)
        {
            mDisposition = disposition;
            mDureeMinute = dureeMinute;
            mNombreLoges = nombreLoges;
        }

        public override float CalculerTarif()
        {
            return mDureeMinute * ((mDisposition == DispositionCli.NORMAL) ? 1f : 1.25f) * 0.01f + Tarif;
        }
    }
}
