using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    public class Lieu
    {

        /// <summary>
        /// GUID
        /// </summary>
        private Guid _guid;

        /// <summary>
        /// Le nom du lieu.
        /// </summary>
        private string _nom;

        /// <summary>
        /// L'adresse du lieu.
        /// </summary>
        private string _adresse;

        /// <summary>
        /// Le Code postal.
        /// </summary>
        private string _codePostal;

        /// <summary>
        /// La ville.
        /// </summary>
        private string _ville;

        /// <summary>
        /// La description du lieu.
        /// </summary>
        private string _description;

        /// <summary>
        /// Le nombre place maximum du lieu.
        /// </summary>
        private int _nombrePlacesTotal;

        /// <summary>
        /// Le site internet du lieu.
        /// </summary>
        private string _siteInternet;

        /// <summary>
        /// Pourcentage commission.
        /// </summary>
        private int _pourcentageCommission;

        /// <summary>
        /// Téléphone.
        /// </summary>
        private string _telephone;

        public Lieu()
        {

        }

        /// <summary>
        /// Constructeur complet.
        /// </summary>
        /// <param name="nom">Le nom.</param>
        /// <param name="adresse">L'adresse.</param>
        /// <param name="description">La description.</param>
        /// <param name="nbPlace">Le nombre de place maximum.</param>
        /// <param name="site">Le site internet.</param>
        public Lieu(string guid, string nom, string adresse, string description, int nbPlace, string site)
        {
            this.Guid = new Guid(guid);
            Nom = nom;
            Adresse = adresse;
            Description = description;
            NombrePlacesTotal = nbPlace;
            SiteInternet = site;
        }

        public Guid Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }

        public string CodePostal1
        {
            get { return _codePostal; }
            set { _codePostal = value; }
        }

        /// <summary>
        /// Propriété du nom.
        /// </summary>
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        /// <summary>
        /// Propriété de l'adresse.
        /// </summary>
        public string Adresse
        {
            get { return _adresse; }
            set { _adresse = value; }
        }

        /// <summary>
        /// Propriété de la description.
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Ville
        {
            get { return _ville; }
            set { _ville = value; }
        }
        
        /// <summary>
        /// Propriété du nombre de place.
        /// </summary>
        public int NombrePlacesTotal
        {
            get { return _nombrePlacesTotal; }
            set { _nombrePlacesTotal = value; }
        }

        public int PourcentageCommission
        {
            get { return _pourcentageCommission; }
            set { _pourcentageCommission = value; }
        }

        /// <summary>
        /// Propriété du site internet.
        /// </summary>
        public string SiteInternet
        {
            get { return _siteInternet; }
            set { _siteInternet = value; }
        }

        /// <summary>
        /// To string
        /// </summary>
        /// <returns>Description du Lieu</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Nom);
            return sb.ToString();
        }

        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj is Lieu)
                return Nom.Equals(((Lieu)obj).Nom);
            else
                return false;
        }

        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }
    }
}
