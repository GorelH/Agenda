using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntitiesLayer;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    class DalSqlServer : IDalManager
    {
        public enum Type
        {
            ARTIST,
            USER,
            EVENT,
            PLACE
        };

        #region Description de la base de donnée
        private const string TableArtists = "ARTISTS";
        private const string TableUsers = "USERS"; // mettre les noms des tables, et les noms de tous les champs
        private const string TablePlaces = "PLACES";
        private const string TableEventDatePlace = "EVENT_DATE_PLACE";
        private const string TableEventsArtists = "EVENTS_ARTISTS";
        private const string TableEvents = "EVENTS";
        private const string TableEventTypes = "EVENT_TYPES";

        // EVENT_TYPES
        private const int ColETGUID = 0;
        private const int ColETDescription = 1;

        // EVENTS_ARTISTS
        private const int ColEAEventsGUID = 0;
        private const int ColEAArtistsGUID = 1;

        // EVENTS
        private const int ColEGUID = 0;
        private const int ColETitle = 1;
        private const int ColEDescription = 2;
        private const int ColEPrice = 3;
        private const int ColRETGUID = 4;

        // ARTISTS
        private const int ColAGUID = 0;
        private const int ColAName = 1;
        private const int ColABirthDate = 2;

        // PLACES
        private const int ColPGUID = 0;
        private const int ColPName = 1;
        private const int ColPAdress = 2;
        private const int ColPDescription = 3;
        private const int ColPNumberPlaces = 4;
        private const int ColPWebSite = 5;
        private const int ColPLocationPercent = 6;

        // EVENT_DATE_PLACE
        private const int ColEDPEventGUID = 0;
        private const int ColEDPPlaceGUID = 1;
        private const int ColEDPDateBegin = 2;
        private const int ColEDPDateEnd = 3;
        private const int ColEDPReservedPlaces = 4;

        //USER
        private const int ColULogin = 0;
        private const int ColUPasswd = 1;
        private const int ColUNom = 2;
        private const int ColUPrenom = 3;

        //TYPE
        private const string TypeConcert = "Concert";
        private const string TypeExpo = "Exposition";
        #endregion

        private string mPath = null;

        public DalSqlServer(string path)
        {
            mPath = path;
        }

        public void Save(DataTable dt, Type type )
        {
            string request;
            
            switch (type)
            {
                default:
                    break;
            }
            //string request = "SELECT
            
        }

        private void insert(string inRequest, DataTable dt)
        {
            SqlConnection dbh = new SqlConnection();
            dbh.ConnectionString = mPath;
            SqlTransaction trans = dbh.BeginTransaction();
            using (dbh)
            {
                try
                {

                    SqlCommand cmd = new SqlCommand(inRequest, dbh, trans);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    da.UpdateCommand = cb.GetUpdateCommand();
                    da.InsertCommand = cb.GetInsertCommand();
                    da.DeleteCommand = cb.GetDeleteCommand();

                    da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    da.Update(dt);
                }
                catch(SystemException)
                {
                    trans.Rollback();
                }
            }

        }

        public DataTable Select(string query)
        {
            DataTable ret = new DataTable();
           
            using(SqlConnection dbh = new SqlConnection(mPath))
            {
                SqlCommand sqlcmd = new SqlCommand(query, dbh);
                SqlDataAdapter  da = new SqlDataAdapter(sqlcmd);
                da.Fill(ret);
            }

            return ret;
        }

        public EntitiesLayer.User getUserByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public IList<EntitiesLayer.Artiste> Artistes
        {
            get
            {
                DataTable dt = new DataTable();
                List<EntitiesLayer.Artiste> listeArtiste = new List<EntitiesLayer.Artiste>();
                string request = "SELECT * FROM " + TableArtists + ";";

                dt = Select(request);

                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    listeArtiste.Add(new Artiste(int.Parse(dt.Rows[i][ColAGUID].ToString()), dt.Rows[i][ColAName].ToString(), dt.Rows[i][ColAName].ToString() , DateTime.Parse(dt.Rows[i][ColABirthDate].ToString())));
                }
                return listeArtiste;
            }
        }

        public IList<EntitiesLayer.Concert> Concerts
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IList<EntitiesLayer.Exposition> Expositions
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IList<EntitiesLayer.PlanningElement> Plannings
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IList<EntitiesLayer.Lieu> Lieux
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        IList<Artiste> IDalManager.Artistes
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        IList<Lieu> IDalManager.Lieux
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
