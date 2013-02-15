using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonAgendaWPF.Utils;

namespace MonAgendaWPF.Configuration
{
    [Serializable]
    public class ApplicationConfiguration
    {

        /// <summary>
        /// Dictionnaire contenant l'ensemble des configurations des fenètres.
        /// </summary>
        private SerializableDictionary<String, WindowConfiguration> windowsConfiguration = new SerializableDictionary<String, WindowConfiguration>();

        public SerializableDictionary<String, WindowConfiguration> WindowsConfiguration
        {
            get { return windowsConfiguration; }
            set { windowsConfiguration = value; }
        }
    }
}
