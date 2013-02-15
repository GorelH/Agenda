using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    public class Utilisateur
    {
        /// <summary>
        /// Login de l'utilisateur
        /// </summary>
        private string _login;
        /// <summary>
        /// Mot de Passe de l'utilisateur
        /// </summary>
        private string _password;

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="login">Login de l'utilisateur</param>
        /// <param name="password">Mot de passe</param>
        public Utilisateur(string login, string password)
        {
            Password = password;
            Login = login;
        }
    }
}
