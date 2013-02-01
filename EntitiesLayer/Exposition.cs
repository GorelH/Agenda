using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    public class Exposition : Evenement
    {
        private int mNombreOeuvresExposées;

        public int NombreOeuvresExposées
        {
            get { return mNombreOeuvresExposées; }
            set { mNombreOeuvresExposées = value; }
        }

        public Exposition(int guid, List<Artiste> artistes, string description, float tarif, string titre, int nombreOeuvresExposées)
            : base(guid, artistes, description, tarif, titre)
        {
            mNombreOeuvresExposées = nombreOeuvresExposées;
        }

        public override float CalculerTarif()
        {
            return mNombreOeuvresExposées * 0.01f + Tarif;
        }
    }
}
