using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    public class PlanningElement
    {

        /// <summary>
        /// GUID
        /// </summary>
        private Guid _guid;

        /// <summary>
        /// L'événement correspondant.
        /// </summary>
        private Evenement _monEvenement;

        /// <summary>
        /// Le lieu de l'événement.
        /// </summary>
        private Lieu _monLieu;

        /// <summary>
        /// La date (heure) de début.
        /// </summary>
        private DateTime _dateDebut;

        /// <summary>
        /// La date (heure) de fin.
        /// </summary>
        private DateTime _dateFin;

        /// <summary>
        /// Le nombre de place réservées.
        /// </summary>
        private int _nombrePlacesReserves;

        public PlanningElement()
        {
            MonEvenement = new Concert();
            MonLieu = new Lieu();
        }

        /// <summary>
        /// Constructeur complet.
        /// </summary>
        /// <param name="e">L'événement</param>
        /// <param name="location">Le lieu</param>
        /// <param name="begin">L'heure de début</param>
        /// <param name="end">L'heure de fin</param>
        /// <param name="reserved">Le nombre de place réservées.</param>
        public PlanningElement(Evenement e, Lieu location, DateTime begin, DateTime end, int reserved)
        {
            MonEvenement = e;
            MonLieu = location;
            DateDebut = begin;
            DateFin = end;
            NombrePlacesreserves = reserved;
        }

        /// <summary>
        /// Propriété de l'événement
        /// </summary>
        public Guid Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }

        /// <summary>
        /// Propriété de l'événement
        /// </summary>
        public Evenement MonEvenement
        {
            get { return _monEvenement; }
            set { _monEvenement = value; }
        }

        /// <summary>
        /// Propriété de la location
        /// </summary>
        public Lieu MonLieu
        {
            get { return _monLieu; }
            set { _monLieu = value; }
        }

        /// <summary>
        /// Propriété de l'heure de début.
        /// </summary>
        public DateTime DateDebut
        {
            get { return _dateDebut; }
            set { _dateDebut = value; }
        }

        /// <summary>
        /// Propriété de l'heure de fin.
        /// </summary>
        public DateTime DateFin
        {
            get { return _dateFin; }
            set { _dateFin = value; }
        }

        /// <summary>
        /// Propriété du nombre de place réservées.
        /// </summary>
        public int NombrePlacesreserves
        {
            get { return _nombrePlacesReserves; }
            set { _nombrePlacesReserves = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(MonEvenement.Titre);
            if (!String.IsNullOrEmpty(MonEvenement.Description))
                sb.Append(" (").Append(MonEvenement.Description).Append(") ");
            sb.Append(" - ").Append(MonLieu.Nom).Append(" - ").Append(DateDebut.Date.ToString("dd/mm/yyyy"));

            return sb.ToString();
        }
    }
}
