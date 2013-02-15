using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class DalManager : IDalManager
    {
        public EntitiesLayer.User getUserByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public IList<EntitiesLayer.Artiste> Artistes
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
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
