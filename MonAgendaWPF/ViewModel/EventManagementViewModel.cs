using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MonAgendaWPF.Utils;
using EntitiesLayer;
using System.Windows.Input;

namespace MonAgendaWPF.ViewModel
{
    class EventManagementViewModel : ViewModelBase
    {

        private IEnumerable<PlanningElement> _elements;

        public IEnumerable<PlanningElement> Elements
        {
            get { return _elements; }
            set { _elements = value; }
        }

        private ObservableCollection<PlanningElementViewModel> _events;

        public ObservableCollection<PlanningElementViewModel> Events
        {
            get { return _events; }
            set 
            { 
                _events = value;
                OnPropertyChanged("Events");
            }
        }

        private PlanningElementViewModel _modelElement;

        public PlanningElementViewModel ModelElement
        {
            get { return _modelElement; }
            set 
            { 
                _modelElement = value;
                OnPropertyChanged("ModelElement");
            }
        }

        public EventManagementViewModel(IEnumerable<PlanningElement> eventsList)
        {
            Events = new ObservableCollection<PlanningElementViewModel>();
            Elements = eventsList;
            foreach (PlanningElement pe in eventsList)
            {
                Events.Add(new PlanningElementViewModel(pe));
            }
        }

        private RelayCommand _removeEventCommand;
        public ICommand RemoveEventCommand
        {
            get
            {
                if (_removeEventCommand == null)
                {
                    _removeEventCommand = new RelayCommand(
                        () => this.RemoveEvent(),
                        () => this.CanRemoveEvent()
                    );
                }
                return _removeEventCommand;
            }
        }

        public bool CanRemoveEvent()
        {
            return (ModelElement != null);
        }

        public void RemoveEvent()
        {
            App.BusinessManager.RemovePlanning(ModelElement.Element);
            Events.Remove(ModelElement);
        }

        private RelayCommand _addEventCommand;
        public ICommand AddEventCommand
        {
            get
            {
                if (_addEventCommand == null)
                {
                    _addEventCommand = new RelayCommand(
                        () => this.AddEvent()
                    );
                }
                return _addEventCommand;
            }
        }

        public void AddEvent()
        {
            PlanningElement pe = new PlanningElement(new Concert("Default", "Default", 0f, Guid.NewGuid(), null, 0, 0, null), new Lieu(App.BusinessManager.GetFirstPlaceGuid().ToString(), "Default", "", "", 0, ""), DateTime.Now, DateTime.Now, 0);
            
            Events.Add(new PlanningElementViewModel(pe));
            App.BusinessManager.AddPlanning(pe);
        }

        private RelayCommand _validateEventCommand;
        public ICommand ValidateEventCommand
        {
            get
            {
                if (_validateEventCommand == null)
                {
                    _validateEventCommand = new RelayCommand(
                        () => this.ValidateEvent(),
                        () => this.CanValidateEvent()
                    );
                }
                return _validateEventCommand;
            }
        }

        public bool CanValidateEvent()
        {
            return (ModelElement != null);
        }

        public void ValidateEvent()
        {
            App.BusinessManager.Update( Elements.ToList() );
        }
    }
}
