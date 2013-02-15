using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    /// <summary>
    /// Exposition
    /// </summary>
    public class Exposition : Evenement 
    {
        /// <summary>
        /// Le nombre d'oeuvres exposées
        /// </summary>
        private int _nombreOeuvresExposees;

        public int NombreOeuvresExposees
        {
            get { return _nombreOeuvresExposees; }
            private set { _nombreOeuvresExposees = value; }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Exposition() :
            base()
        {
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="titre">Titre de l'exposition</param>
        /// <param name="description">Description de l'exposition</param>
        /// <param name="tarif">Tarif de l'exposition</param>
        /// <param name="guid">ID de l'exposition</param>
        /// <param name="nombreOeuvre">Nombre d'oeuvres de l'exposition</param>
        /// <param name="artistes">Liste des artistes de l'exposition</param>
        public Exposition(string titre, string description, float tarif, Guid guid, int nombreOeuvre, IEnumerable<Artiste> artistes) :
            base(titre, description, tarif, guid, artistes)
        {
            NombreOeuvresExposees = nombreOeuvre;
        }

        /// <summary>
        /// Calcul du tarrif
        /// </summary>
        /// <returns>Le tarif</returns>
        public override float CalculerTarif()
        {
            return (NombreOeuvresExposees * Tarif);
        }

        /// <summary>
        /// To string
        /// </summary>
        /// <returns>Description de l'exposition</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.Append("Oeuvres Exposées : ").AppendLine(NombreOeuvresExposees.ToString());

            return sb.ToString();
        }
    }
}
