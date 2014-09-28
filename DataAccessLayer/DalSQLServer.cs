using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesLayer;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalSQLServer : IDal
    {

        /// <summary>
        /// The connnection string
        /// </summary>
        private String _connectionString;

        /// <summary>
        /// Property
        /// </summary>
        public String ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="connectionString">Chaine de connexion</param>
        public DalSQLServer(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Construit une datatable à partir d'une requete SQL
        /// </summary>
        /// <param name="request">Requete SQL</param>
        /// <returns>Data table correspondante</returns>
        private DataTable GetDataTable(string request)
        {
            DataTable results = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(results);
            }
            return results;
        }

        /// <summary>
        /// Accés en base de donnée
        /// </summary>
        /// <returns>Data table correspondant à la liste des artistes</returns>
        public DataTable GetArtistsTable()
        {
            return GetDataTable("select * from ARTISTS;");
        }

        /// <see cref="IDal.Cs"/>
        public List<Artiste> GetAllArtists()
        {
            List<Artiste> artists = new List<Artiste>();
            DataTable table = GetArtistsTable();
            foreach ( DataRow col in table.Rows )
            {
                string guid = col["GUID"].ToString();
                string name = col["NAME"].ToString();
                String birthdate = null;
                if (!(col["BIRTH_DATE"] is DBNull))
                {
                    birthdate = col["BIRTH_DATE"].ToString();
                }

                DateTime dt = String.IsNullOrEmpty(birthdate) ? new DateTime() : DateTime.Parse(birthdate);
                artists.Add( new Artiste(name, name, dt, Convert.ToInt32(guid)) );
            }

            return artists;
        }

        /// <see cref="IDal.Cs"/>
        public List<PlanningElement> GetAllPlannings()
        {
            List<PlanningElement> plannings = new List<PlanningElement>();
            DataTable table = GetDataTable("select * from EVENT_DATE_PLACE;");
            foreach (DataRow col in table.Rows)
            {
                string eventguid = col["EVENT_GUID"].ToString();
                string placeguid = col["PLACE_GUID"].ToString();
                int reservations = int.Parse(col["RESERVED_PLACES"].ToString());
                String begindate = null;
                String enddate = null;

                if (!(col["DATE_END"] is DBNull))
                    enddate = col["DATE_END"].ToString();

                if (!(col["DATE_BEGIN"] is DBNull))
                    begindate = col["DATE_BEGIN"].ToString();

                DateTime dt_begin = String.IsNullOrEmpty(begindate) ? new DateTime() : DateTime.Parse(begindate);
                DateTime dt_end = String.IsNullOrEmpty(enddate) ? new DateTime() : DateTime.Parse(enddate);
                plannings.Add(new PlanningElement(GetEventByGuid(eventguid), GetPlaceByGuid(placeguid), dt_begin, dt_end, reservations));
            }

            return plannings;
        }

        /// <see cref="IDal.Cs"/>
        public List<Lieu> GetAllLieux()
        {
            List<Lieu> places = new List<Lieu>();
            DataTable table = GetDataTable("select * from PLACES;");
            foreach (DataRow col in table.Rows)
            {
                string guid = col["GUID"].ToString();
                string address = col["ADRESS"].ToString();
                string name = col["NAME"].ToString();
                string description = col["DESCRIPTION"].ToString();
                string site = col["WEB_SITE"].ToString();
                int nbPlaces = int.Parse(col["NUMBER_PLACES"].ToString());
                places.Add(new Lieu(guid, name, address, description, nbPlaces, site));
            }

            return places;
        }

        /// <summary>
        /// Recherche un id de lieux par nom
        /// </summary>
        /// <param name="name">Nom du lieu</param>
        /// <returns>Guid du lieu</returns>
        public Guid? getPlaceIdByName(string name)
        {
            Guid? guid = null;
            DataTable table = GetDataTable("select GUID from Places where NAME = '" + name + "';");

            if (table.Rows.Count > 0)
            {
                DataRow col = table.Rows[0];

                guid = new Guid(col["GUID"].ToString());
            }
            return guid;
        }

        /// <see cref="IDal.Cs"/>
        public List<Evenement> GetEvenementByLieu(string lieu)
        {
            List<Evenement> events = new List<Evenement>();
            Guid? placeGuid = getPlaceIdByName(lieu);
            DataTable table = GetDataTable("select ev.GUID, ev.TITLE, ev.DESCRIPTION, ev.PRICE, ev.EVENT_TYPE_GUID from EVENTS ev, EVENT_DATE_PLACE edp, PLACES p WHERE edp.PLACE_GUID = p.GUID AND edp.EVENT_GUID = ev.GUID AND p.GUID = '" + placeGuid + "';");
            foreach (DataRow col in table.Rows)
            {
                string guid = col["GUID"].ToString();
                string title = col["TITLE"].ToString();
                string description = col["DESCRIPTION"].ToString();
                string price = col["PRICE"].ToString();
                string eventType = col["EVENT_TYPE_GUID"].ToString();
                string eventTypeString = GetTypeFromEvent(eventType).ToLower();

                Evenement evenement = null;
                switch (eventTypeString)
                {
                    case "concert":
                        evenement = new Concert(title, description, float.Parse(price), new Guid(guid), null, 0, 0, GetArtistsForEvent(guid));
                        break;
                    case "exposition":
                        evenement = new Exposition(title, description, float.Parse(price), new Guid(guid), 0, GetArtistsForEvent(guid));
                        break;
                }

                events.Add(evenement);
            }

            return events;
        }

        /// <see cref="IDal.Cs"/>
        public Utilisateur GetUtilisateurByLogin(string login)
        {
            Utilisateur user = null; ;
            DataTable table = GetDataTable("select * from USERS where LOGIN = '" + login + "';");
            if (table.Rows.Count > 0)
            {
                DataRow col = table.Rows[0];
                string password = col["PASSWORD"].ToString();
                string firstname = col["PRENOM"].ToString();
                string lastname = col["NOM"].ToString();
                user = new Utilisateur(login, password);
            }

            return user;
        }

        /// <summary>
        /// Ne fonctionne pas.
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        private DataTable DataTableFromList(List<PlanningElement> events)
        {
            // Construire l'architecture de la table exacte, mais vide grace au where 1 = 2
            DataTable table = GetDataTable("select * from EVENT_DATE_PLACE where 1=2;");

            foreach(PlanningElement element in events)
            {
                DataRow row = table.NewRow();
                row["EVENT_GUID"] = element.MonEvenement.Guid;
                row["PLACE_GUID"] = element.MonLieu.Guid;
                row["DATE_BEGIN"] = element.DateDebut.ToString();
                row["DATE_END"] = element.DateFin.ToString();
                row["RESERVED_PLACES"] = element.NombrePlacesreserves;
                table.Rows.Add(row);
            }

            return table;
        }

        /// <see cref="IDal.Cs"/>
        public void Update(List<PlanningElement> events)
        {
            DataTable elements = DataTableFromList(events);
            //UpdateByCommandBuilder("select * from EVENT_DATE_PLACE;", elements);
            UpdateAllPlannings(events);
            UpdateAllEvents(events);
        }

        /// <summary>
        /// Exécute une requete SQL qui ne retourne aucune donnée
        /// </summary>
        /// <param name="sqlConnection">Chaine de connexion</param>
        /// <param name="request">Requete SQL</param>
        private void ExecureNonQueryRequest(SqlConnection sqlConnection, string request)
        {
            SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            sqlCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Met à jour tous les plannings dans la base
        /// </summary>
        /// <param name="elements">Liste des plannings</param>
        public void UpdateAllPlannings(List<PlanningElement> elements)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            foreach (PlanningElement element in elements)
            {
                StringBuilder query = new StringBuilder();
                query.Append("update EVENT_DATE_PLACE set RESERVED_PLACES = ").Append(element.NombrePlacesreserves);
                query.Append(",PLACE_GUID = '").Append(element.MonLieu.Guid.ToString()).Append("'");
                query.Append(" WHERE EVENT_GUID = '").Append(element.MonEvenement.Guid.ToString()).Append("'");
                query.Append(" AND DATE_BEGIN =  CONVERT(datetime, '").Append(element.DateDebut.ToString()).Append("', 103);");

                ExecureNonQueryRequest(sqlConnection, query.ToString());
            }
            sqlConnection.Close();
        }

        /// <summary>
        /// Met à jour tous les événements dans la base
        /// </summary>
        /// <param name="elements">Liste des événements</param>
        public void UpdateAllEvents(List<PlanningElement> elements)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            foreach (PlanningElement element in elements)
            {
                StringBuilder query = new StringBuilder();
                query.Append("update EVENTS set TITLE = '").Append(element.MonEvenement.Titre).Append("'");
                query.Append(",DESCRIPTION = '").Append(element.MonEvenement.Description).Append("'");
                query.Append(" WHERE GUID = '").Append(element.MonEvenement.Guid.ToString()).Append("'");

                ExecureNonQueryRequest(sqlConnection, query.ToString());
            }
            sqlConnection.Close();
        }

        private int UpdateByCommandBuilder(string request, DataTable events)
        {
            int result = 0;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

                sqlDataAdapter.UpdateCommand = sqlCommandBuilder.GetUpdateCommand();
                sqlDataAdapter.InsertCommand = sqlCommandBuilder.GetInsertCommand();
                sqlDataAdapter.DeleteCommand = sqlCommandBuilder.GetDeleteCommand();

                sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                result = sqlDataAdapter.Update(events);
            }

            return result;
        }
        
        private List<Artiste> GetArtistsForEvent(string guid)
        {
            List<Artiste> artists = new List<Artiste>();
            DataTable table = GetDataTable("select * from ARTISTS a, EVENTS_ARTISTS ea WHERE a.GUID = ea.ARTISTS_GUID AND ea.EVENTS_GUID = '" + guid + "';");
            foreach (DataRow col in table.Rows)
            {
                string artistGuid = col["GUID"].ToString();
                string name = col["NAME"].ToString();
                String birthdate = null;

                if (!(col["BIRTH_DATE"] is DBNull))
                    birthdate = col["BIRTH_DATE"].ToString();

                DateTime dt = String.IsNullOrEmpty(birthdate) ? new DateTime() : DateTime.Parse(birthdate);
                artists.Add(new Artiste(name, "", dt, artistGuid.GetHashCode()));
           
            }

            return artists;
        }
        
        /// <summary>
        /// Recherche le type d'un événement par son Guid
        /// </summary>
        /// <param name="guid">Guid de l'événement</param>
        /// <returns>Type de l'événément</returns>
        private string GetTypeFromEvent(string guid)
        {
            DataTable table = GetDataTable("select * from EVENT_TYPES types WHERE types.GUID = '" + guid + "';");

            return table.Rows[0]["DESCRIPTION"].ToString();
        }

        /// <summary>
        /// Recherche un lieu par son Guid
        /// </summary>
        /// <param name="inGuid">GUid du lieu</param>
        /// <returns>Lieu concerné</returns>
        public Lieu GetPlaceByGuid(string inGuid)
        {
            Lieu place = null;
            DataTable table = GetDataTable("select * from Places where GUID = '" + inGuid + "';");

            if (table.Rows.Count > 0)
            {
                DataRow col = table.Rows[0];

                string guid = col["GUID"].ToString();
                string address = col["ADRESS"].ToString();
                string name = col["NAME"].ToString();
                string description = col["DESCRIPTION"].ToString();
                string site = col["WEB_SITE"].ToString();
                int nbPlaces = int.Parse(col["NUMBER_PLACES"].ToString());
                place = new Lieu(guid, name, address, description, nbPlaces, site);

            }
            return place;
        }

        /// <summary>
        /// Recherche un événement par son Guid
        /// </summary>
        /// <param name="inGuid">Guid de l'événement</param>
        /// <returns>Evénement concerné</returns>
        public Evenement GetEventByGuid(string inGuid)
        {
            Evenement evenement = null;
            DataTable table = GetDataTable("select * from EVENTS where GUID = '" + inGuid + "';");

            if (table.Rows.Count > 0)
            {
                DataRow col = table.Rows[0];

                string guid = col["GUID"].ToString();
                string title = col["TITLE"].ToString();
                string description = col["DESCRIPTION"].ToString();
                string price = col["PRICE"].ToString();
                string eventType = col["EVENT_TYPE_GUID"].ToString();
                string eventTypeString = GetTypeFromEvent(eventType).ToLower();

                switch (eventTypeString)
                {
                    case "concert":
                        evenement = new Concert(title, description, float.Parse(price), new Guid(guid), null, 0, 0, GetArtistsForEvent(guid));
                        break;
                    case "exposition":
                        evenement = new Exposition(title, description, float.Parse(price), new Guid(guid), 0, GetArtistsForEvent(guid));
                        break;
                }

            }
            return evenement;
        }

        /// <see cref="IDal.Cs"/>
        public List<Evenement> GetAllEvenements()
        {
            List<Evenement> events = new List<Evenement>();
            DataTable table = GetDataTable("select * from EVENTS;");
            foreach (DataRow col in table.Rows)
            {
                string guid = col["GUID"].ToString();
                string title = col["TITLE"].ToString();
                string description = col["DESCRIPTION"].ToString();
                string price = col["PRICE"].ToString();
                string eventType = col["EVENT_TYPE_GUID"].ToString();
                string eventTypeString = GetTypeFromEvent(eventType).ToLower();

                Evenement evenement = null;
                switch (eventTypeString)
                {
                    case "concert":
                        evenement = new Concert(title, description, float.Parse(price), new Guid(guid), null, 0, 0, GetArtistsForEvent(guid));
                        break;
                    case "exposition":
                        evenement = new Exposition(title, description, float.Parse(price), new Guid(guid), 0, GetArtistsForEvent(guid));
                        break;
                }
                    

                events.Add(evenement);
            }

            return events;
        }

        /// <see cref="IDal.Cs"/>
        public void RemovePlanning(PlanningElement element)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            StringBuilder query = new StringBuilder();

            query.Append("delete from EVENT_DATE_PLACE");
            query.Append(" WHERE EVENT_GUID = '").Append(element.MonEvenement.Guid.ToString()).Append("'");
            query.Append(" AND PLACE_GUID = '").Append(element.MonLieu.Guid.ToString()).Append("'");
            query.Append(" AND DATE_BEGIN =  CONVERT(datetime, '").Append(element.DateDebut.ToString()).Append("', 103);");
            
            sqlConnection.Open();
            ExecureNonQueryRequest(sqlConnection, query.ToString());
            sqlConnection.Close();
        }

        /// <see cref="IDal.Cs"/>
        public void AddPlanning(PlanningElement element)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            StringBuilder insertPlanning = new StringBuilder();
            StringBuilder insertEvent = new StringBuilder();

            insertEvent.Append("insert into EVENTS");
            insertEvent.Append(" values('").Append(element.MonEvenement.Guid).Append("'");
            insertEvent.Append(", '").Append(element.MonEvenement.Titre).Append("'");
            insertEvent.Append(", '").Append(element.MonEvenement.Description).Append("'");
            insertEvent.Append(", ").Append(element.MonEvenement.Tarif);
            insertEvent.Append(", (select GUID from EVENT_TYPES where DESCRIPTION = 'concert'));");

            insertPlanning.Append("insert into EVENT_DATE_PLACE");
            insertPlanning.Append(" values('").Append(element.MonEvenement.Guid.ToString()).Append("'");
            insertPlanning.Append(", '").Append(element.MonLieu.Guid.ToString()).Append("'");
            insertPlanning.Append(", CONVERT(datetime, '").Append(element.DateDebut.ToString()).Append("', 103)");
            insertPlanning.Append(", CONVERT(datetime, '").Append(element.DateFin.ToString()).Append("', 103)");
            insertPlanning.Append(",").Append(element.NombrePlacesreserves).Append(");");

            sqlConnection.Open();
            ExecureNonQueryRequest(sqlConnection, insertEvent.ToString());
            ExecureNonQueryRequest(sqlConnection, insertPlanning.ToString());
            sqlConnection.Close();
        }
    }

}
