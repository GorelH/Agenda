using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    public class Artiste
    {

        /// <summary>
        /// Date de naissance
        /// </summary>
        private DateTime _dateNaissance;
        /// <summary>
        /// prénom de l'artiste
        /// </summary>
        private string _prenom;
        /// <summary>
        /// Nom de l'artiste
        /// </summary>
        private string _nom;
        /// <summary>
        /// ID de l'artiste
        /// </summary>
        private int _guid;

        public DateTime DateNaissance
        {
            get { return _dateNaissance; }
            set { _dateNaissance = value; }
        }
        

        public int Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }
        

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }
        

        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Artiste()
        {
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nom">Nom de l'artiste</param>
        /// <param name="prenom">prénom de l'artiste</param>
        /// <param name="dateNaissance">Date de naissance</param>
        /// <param name="guid">ID</param>
        public Artiste(string nom, string prenom, DateTime dateNaissance, int guid)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            Guid = guid;
        }

        /// <summary>
        /// To String
        /// </summary>
        /// <returns>Description de l'artiste</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Prenom).Append(" ").Append(Nom);

            return sb.ToString();
        }
    }
}
