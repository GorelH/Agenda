using System;
using MonAgendaWPF.Utils;

namespace MonAgendaWPF.Configuration
{
    [Serializable]
    public class UserConfiguration
    {

        /// <summary>
        /// Dictionnaire contenant l'ensemble des configurations des utilisateurs.
        /// </summary>
        private SerializableDictionary<string, ApplicationConfiguration> applicationConfiguration = new SerializableDictionary<string, ApplicationConfiguration>();

        public SerializableDictionary<string, ApplicationConfiguration> ApplicationConfiguration
        {
            get { return applicationConfiguration; }
            set { applicationConfiguration = value; }
        }

        /// <summary>
        /// Retourne la configuration d'un utilisateur suivant son nom.
        /// </summary>
        /// <param name="username">Le nom de l'utilisateur.</param>
        /// <returns>La configuration des différentes fenêtres.</returns>
        public ApplicationConfiguration GetApplicationconfigurationFromUsername(string username)
        {

            if (!applicationConfiguration.ContainsKey(username))
            {
                applicationConfiguration.Add(username, new ApplicationConfiguration());
            }

            return applicationConfiguration[username];

        }

    }
}
