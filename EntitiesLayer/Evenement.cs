using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    /// <summary>
    /// Evenement
    /// </summary>
    public abstract class Evenement
    {
        /// <summary>
        /// Liste des artistes
        /// </summary>
        private IEnumerable<Artiste> _artistes;
        /// <summary>
        /// Description de l'événement
        /// </summary>
        private string _description;
        /// <summary>
        /// Titre de l'événement
        /// </summary>
        private string _Titre;
        /// <summary>
        /// ID
        /// </summary>
        private Guid _guid;
        /// <summary>
        /// Tarif de l'événement
        /// </summary>
        private float _tarif;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public Guid Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }

        public float Tarif
        {
            get { return _tarif; }
            set { _tarif = value; }
        }

        public string Titre
        {
            get { return _Titre; }
            set { _Titre = value; }
        }

        public IEnumerable<Artiste> Artistes
        {
            get { return _artistes; }
            set { _artistes = value; }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Evenement()
        { 
        }

        /// <summary>
        /// Constructeur 
        /// </summary>
        /// <param name="titre">Titre de l'événement</param>
        /// <param name="description">Description de l'événement</param>
        /// <param name="tarif">Tarif de l'événement</param>
        /// <param name="guid">ID</param>
        /// <param name="artistes">Liste des artistes</param>
        public Evenement(string titre, string description, float tarif, Guid guid, IEnumerable<Artiste> artistes)
        {
            Titre = titre;
            Description = description;
            Tarif = tarif;
            Artistes = artistes;
            this.Guid = guid;
        }

        /// <summary>
        /// Calcul du tarrif
        /// </summary>
        /// <returns>Le tarif</returns>
        public virtual float CalculerTarif()
        {
            return Tarif;
        }
        
        /// <summary>
        /// To string
        /// </summary>
        /// <returns>Description de l'événement</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("--- Evenement ---");
            sb.Append("Description : ").AppendLine(Description);
            sb.Append("Titre : ").AppendLine(Titre);
            sb.Append("Tarif : ").AppendLine(Tarif.ToString());
            sb.Append("GUID : ").AppendLine(Guid.ToString());

            foreach(Artiste artiste in _artistes)
                sb.Append("Artiste : ").AppendLine(artiste.Nom);

            return sb.ToString();
        }
    }
}
