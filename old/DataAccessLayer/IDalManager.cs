using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesLayer;

namespace DataAccessLayer
{
    public interface IDalManager
    {
        User getUserByLogin(string login);
        IList<Artiste> Artistes { get; set; }
        IList<Concert> Concerts { get; set; }
        IList<Exposition> Expositions { get; set; }
        IList<PlanningElement> Plannings { get; set; }
        IList<Lieu> Lieux { get; set; }
    }
}
