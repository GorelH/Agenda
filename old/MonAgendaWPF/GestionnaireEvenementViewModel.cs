using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesLayer;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MonAgendaWPF
{
    class GestionnaireEvenementViewModel : ViewModelBase
    {
        private List<PlanningElement> mListModif = new List<PlanningElement>();
        private List<PlanningElement> mListDel = new List<PlanningElement>();

        public GestionnaireEvenementViewModel(List<PlanningElement> planningElementsModel)
        {
            planningElementsModel.ForEach(pe => mPlannings.Add(new PlanningElementViewModel(pe)));
        }

        private ObservableCollection<PlanningElementViewModel> mPlannings = new ObservableCollection<PlanningElementViewModel>();
        public ObservableCollection<PlanningElementViewModel> PlanningElements
        {
            get 
            {
                return mPlannings; 
            }
            set 
            {
                if (value != mPlannings)
                {
                    mPlannings = value;
                    OnPropertyChanged("Evenements");
                }
            }
        }

        private PlanningElementViewModel mSelectedItem;
        public PlanningElementViewModel SelectedItem
        {
            get { return mSelectedItem; }
            set
            {
                if (value != mSelectedItem)
                {
                    mSelectedItem = value;
                    OnPropertyChanged("SelectedItem");
                }
            }
        }

        private RelayCommand mAddCommand;
        public ICommand AddCommand
        {
            get
            {
                if (mAddCommand == null)
                {
                    mAddCommand = new RelayCommand(
                        () => this.Add(),
                        () => true
                        );
                }

                return mAddCommand;
            }
        }

        private void Add()
        {
            PlanningElement pe = new PlanningElement(0, DateTime.Now, DateTime.Now,
                new Concert(0, new List<Artiste>(), "", 0, "", Concert.DispositionCli.NORMAL, 0, 0),
                new Lieu(0, "", "", "", 0, "", 0, "", ""), 0);

            this.SelectedItem = new PlanningElementViewModel(pe);

            mListModif.Add(pe);
            mPlannings.Add(this.SelectedItem);
        }

        private RelayCommand mRemoveCommand;
        public ICommand RemoveCommand
        {
            get
            {
                if (mRemoveCommand == null)
                {
                    mRemoveCommand = new RelayCommand(
                        () => this.Remove(),
                        () => this.SelectedItem != null
                        );
                }
                return mRemoveCommand;
            }
        }

        private void Remove()
        {
            mListDel.Add(this.SelectedItem.PlanningElement);
            mPlannings.Remove(this.SelectedItem);
        }
        
    }
}
