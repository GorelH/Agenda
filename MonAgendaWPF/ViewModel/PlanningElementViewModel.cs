using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonAgendaWPF.Utils;
using EntitiesLayer;

namespace MonAgendaWPF.ViewModel
{
    class PlanningElementViewModel : ViewModelBase
    {
        private PlanningElement _element;

        public PlanningElement Element
        {
            get { return _element; }
            set 
            { 
                _element = value; 
                OnPropertyChanged("Element");
            }
        }

        public PlanningElementViewModel(PlanningElement element)
        {
            _element = element;
        }

        public string Evenement
        {
            get { return Element.MonEvenement.Titre; }
            set 
            {
                Element.MonEvenement.Titre = value;
                OnPropertyChanged("Evenement");
            }
        }

        public IEnumerable<Artiste> Artists
        {
            get { return Element.MonEvenement.Artistes; }
            set 
            {
                Element.MonEvenement.Artistes = value;
                OnPropertyChanged("Artists");
            }
        }

        public Lieu Locations
        {
            get { return Element.MonLieu; }
            set 
            {
                Element.MonLieu = value;
                OnPropertyChanged("Locations");
            }
        }

        public DateTime Date
        {
            get { return Element.DateDebut; }
            set 
            {
                Element.DateDebut = value;
                OnPropertyChanged("Date");
            }
        }

        public float Price
        {
            get { return Element.MonEvenement.Tarif; }
        }

        public string Description
        {
            get { return Element.MonEvenement.Description; }
            set
            {
                Element.MonEvenement.Description = value;
                OnPropertyChanged("Description");
            }
        }

        public int Reservations
        {
            get { return Element.NombrePlacesreserves; }
            set 
            {
                Element.NombrePlacesreserves = value;
                OnPropertyChanged("Reservations");
                OnPropertyChanged("Price");
            }
        }

        public override string ToString()
        {
            return Element.ToString();
        }
    }
}
