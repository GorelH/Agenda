using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using MonAgendaWPF.Configuration;

namespace MonAgendaWPF.Utils
{
    public class StorageUtil
    {

        private static IsolatedStorageFile Storage = IsolatedStorageFile.GetStore(IsolatedStorageScope.Roaming | IsolatedStorageScope.User | IsolatedStorageScope.Assembly | IsolatedStorageScope.Domain, null, null);

        /// <summary>
        /// Constructeur Complet.
        /// </summary>

        public static void Save(UserConfiguration objectToSave, string filename)
        {
            IsolatedStorageFileStream stream = Storage.CreateFile(filename);

            XmlSerializer xml = new XmlSerializer(objectToSave.GetType());
            xml.Serialize(stream, objectToSave);

            stream.Close();
            stream.Dispose();
        }

        public static UserConfiguration Load(string filename)
        {
            UserConfiguration configuration = new UserConfiguration();

            if (Storage.FileExists(filename))
            {
                IsolatedStorageFileStream stream = Storage.OpenFile(filename, FileMode.Open);
                XmlSerializer xml = new XmlSerializer(typeof(UserConfiguration));
                configuration = xml.Deserialize(stream) as UserConfiguration;
                stream.Close();
                stream.Dispose();
            }

            return configuration;
        }

    }
}
