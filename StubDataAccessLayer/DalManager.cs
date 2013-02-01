using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesLayer;

namespace StubDataAccessLayer
{
    public class DalManager
    {
        #region Membre
        private List<Artiste> mArtistes = new List<Artiste>();

        public List<Artiste> Artistes
        {
            get { return mArtistes; }
            set { mArtistes = value; }
        }

        private List<Concert> mConcerts = new List<Concert>();

        public List<Concert> Concerts
        {
            get { return mConcerts; }
            set { mConcerts = value; }
        }


        private List<Exposition> mExpositions = new List<Exposition>();

        public List<Exposition> Expositions
        {
            get { return mExpositions; }
            set { mExpositions = value; }
        }


        private List<PlanningElement> mPlannings = new List<PlanningElement>();

        public List<PlanningElement> Plannings
        {
            get { return mPlannings; }
            set { mPlannings = value; }
        }


        private List<Lieu> mLieux = new List<Lieu>();

        public List<Lieu> Lieux
        {
            get { return mLieux; }
            set { mLieux = value; }
        }

        private Dictionary<string, User> mUsers = new Dictionary<string, User>();

        public Dictionary<string, User> Users
        {
          get { return mUsers; }
          set { mUsers = value; }
        }

        #endregion

        public DalManager()
        {
            mArtistes = new List<Artiste>();
            Artiste artiste_a = new Artiste(1, "Bogtob", "Karim", new DateTime(1212, 12, 12));
            mArtistes.Add(artiste_a);

            Artiste artiste_b = new Artiste(2, "Faure", "Vivien", new DateTime(1111, 11, 11));
            mArtistes.Add(artiste_b);
           
            Concert concert = new Concert(3, mArtistes, "LES BOGOSS", 2.00f, "LES BOGOSS EN FOLIE", Concert.DispositionCli.SUPERSON, 90, 3);
            
            Exposition exposition_a = new Exposition(4, mArtistes, "PEINTURE NEXT GEN", 2.00f, "NEW PEINTURES", 42);

            mLieux.Add(new Lieu(5, "84 baies des cochons", "99999", "Baie des cochons", 999, "CUBA", .2f, "+66666666", "Sierra Maestra"));

            mPlannings.Add(new PlanningElement(6, new DateTime(2013, 1, 1), new DateTime(2013, 2, 1), concert, mLieux.ElementAt(0), 66));
            mPlannings.Add(new PlanningElement(7, new DateTime(2014, 1, 1), new DateTime(2014, 2, 1), concert, mLieux.ElementAt(0), 66));

            mUsers.Add("kbogtob", new User("Bogtob", "Karim", "kbogtob", "blabla"));
            mUsers.Add("vfaure", new User("Faure", "Vivien", "vfaure", "bloblo"));
        }

        public User getUserByLogin(string login)
        {
            User u;
            if (!mUsers.TryGetValue(login, out u))
                throw new UserNotFoundException();   
            return u;
        }
    }
}
