using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    class Utilisateur
    {
        #region Membres
        private string mNom;

        public string Nom
        {
            get { return mNom; }
            set { mNom = value; }
        }
        private string mPrenom;

        public string Prenom
        {
            get { return mPrenom; }
            set { mPrenom = value; }
        }
        private string mLogin;

        public string Login
        {
            get { return mLogin; }
            set { mLogin = value; }
        }
        private string mPassword;

        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }
        #endregion

    }
}
