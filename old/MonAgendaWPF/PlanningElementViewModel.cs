using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesLayer;

namespace MonAgendaWPF
{
    class PlanningElementViewModel : ViewModelBase
    {
        public PlanningElementViewModel(PlanningElement pe)
        {
            PlanningElement = pe;
            SelectedPlace = PlanningElement.MonLieu.Nom;
            if (PlanningElement.MonEvenement.Artistes.Count > 0)
                SelectedArtist = PlanningElement.MonEvenement.Artistes[0].Nom;

            Places = MainWindow.Instance.BM.GetLieu().Select(l => l.Nom);
            ArtisteList = pe.MonEvenement.Artistes.Select(a => a.Nom);
        }

        public PlanningElement PlanningElement
        {
            get { return mPlanningElement; }
            set
            {
                if (value == mPlanningElement) return;
                mPlanningElement = value;
            }
        }
        private PlanningElement mPlanningElement;

        public string Titre
        {
            get { return mPlanningElement.MonEvenement.Titre; }
            set
            {
                if (value.Equals(mPlanningElement.MonEvenement.Titre)) return;
                mPlanningElement.MonEvenement.Titre = value;
                base.OnPropertyChanged("Titre");
            }
        }

        public IEnumerable<string> ArtisteList
        {
            get { return mArtistes; }
            set { mArtistes = value; }
        }
        public IEnumerable<string> mArtistes;

        public string SelectedArtist
        {
            get
            {
                return mSelectedArtist;
            }
            set
            {
                if (value.Equals(mSelectedArtist))
                    return;
                mSelectedArtist = value;
                base.OnPropertyChanged("SelectedArtist");
            }
        }
        public string mSelectedArtist;

        public IEnumerable<string> Places
        {
            get { return _places; }
            set { _places = value; }
        }
        public IEnumerable<string> _places;

        public string SelectedPlace
        {
            get { return _selectedPlace; }
            set
            {
                if (value.Equals(_selectedPlace))
                    return;
                _selectedPlace = value;
                base.OnPropertyChanged("SelectedPlace");
            }
        }
        public string _selectedPlace;

        public DateTime Date
        {
            get { return mPlanningElement.DateDebut; }
            set
            {
                if (value == mPlanningElement.DateDebut) return;
                mPlanningElement.DateDebut = value;
                base.OnPropertyChanged("Date");
            }
        }

        public float Prix
        {
            get { return mPlanningElement.MonEvenement.Tarif; }
            set
            {
                if (value == mPlanningElement.MonEvenement.Tarif) return;
                mPlanningElement.MonEvenement.Tarif = value;
                base.OnPropertyChanged("Prix");
            }
        }

        public int NbPlacesReserves
        {
            get { return mPlanningElement.NombrePlacesReservees; }
            set
            {
                if (value == mPlanningElement.NombrePlacesReservees) return;
                mPlanningElement.NombrePlacesReservees = value;
                base.OnPropertyChanged("NbPlacesReserves");
            }
        }

        public string Description
        {
            get { return mPlanningElement.MonEvenement.Description; }
            set
            {
                if (value == mPlanningElement.MonEvenement.Description) return;
                mPlanningElement.MonEvenement.Description = value;
                base.OnPropertyChanged("NbPlacesReserves");
            }
        }

        public override string ToString()
        {
            return mPlanningElement.ToString();
        }



    }
}
