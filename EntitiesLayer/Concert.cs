using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    /// <summary>
    /// Dispositions particulières d'un evenement
    /// </summary>
    public enum DispositionParticuliere
    {
        VIP,
        HANDICAPE
    }

    /// <summary>
    /// Concert
    /// </summary>
    public class Concert : Evenement
    {
        /// <summary>
        /// Liste des dispositions particulières
        /// </summary>
        private IEnumerable<DispositionParticuliere> _dispositionsParticulieres;
        /// <summary>
        /// Durée du concert
        /// </summary>
        private int _dureeEnMinutes;
        /// <summary>
        /// Nombre de loges
        /// </summary>
        private int _nombresLoges;

        public int NombresLoges
        {
            get { return _nombresLoges; }
            private set { _nombresLoges = value; }
        }

        public IEnumerable<DispositionParticuliere> DispositionsParticulieres
        {
            get { return _dispositionsParticulieres; }
            private set { _dispositionsParticulieres = value; }
        }

        public int DureeEnMinutes
        {
            get { return _dureeEnMinutes; }
            private set { _dureeEnMinutes = value; }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        public Concert()
        {

        }

        /// <summary>
        /// Calcul du tarrif
        /// </summary>
        /// <returns>Le tarif</returns>
        public override float CalculerTarif()
        {
            return base.CalculerTarif();
        }

        /// <summary>
        /// Constructeur complet.
        /// </summary>
        /// <param name="titre">Le titre du concert.</param>
        /// <param name="description">La description du concert.</param>
        /// <param name="duree">Durée du concert</param>
        /// <param name="dispositions">Liste des dispositions particulières</param>
        /// <param name="guid">ID</param>
        /// <param name="nbLoges">Nombre de loges</param>
        /// <param name="prix">Le prix de la place du concert.</param>
        /// <param name="artistes">Les artistes du concert.</param>
        public Concert(string titre, string description, float prix, Guid guid, IEnumerable<DispositionParticuliere> dispositions, int duree, int nbLoges, IEnumerable<Artiste> artistes) :
            base(titre, description, prix, guid, artistes)
        {
            DispositionsParticulieres = dispositions;
            DureeEnMinutes = duree;
            NombresLoges = nbLoges;
        }

    }
}
