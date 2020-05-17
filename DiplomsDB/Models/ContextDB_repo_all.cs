using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomsDB.Models
{
    public partial class ContextDB
    {
        public List<Diplom> GetAllDiplomsList()
        {
            return this.Diploms.ToList();
        }
        public List<Order> GetAllOrdersList()
        {
            return this.Orders.ToList();
        }
        public List<Speciality> GetAllSpecialitiesList()
        {
            return this.Specialities.ToList();
        }
        public List<Supervisor> GetAllSupervisorsList()
        {
            return this.Supervisors.ToList();
        }
        public List<Setter> GetAllSettersList()
        {
            return this.Setters.ToList();
        }
        public List<Reviewer> GetAllReviewersList()
        {
            List<Reviewer> rc = new List<Reviewer>();
            var revs = this.Database.SqlQuery<Reviewer>("select * from Reviewers");
            foreach (Reviewer r in revs) rc.Add(r);
            return rc;
        }
        public List<Comission> GetAllComissionsList()
        {
            return this.Comissions.ToList();
        }
        public List<Chairman> GetAllChairmenList()
        {
            return this.Chairmen.ToList();
        }
        
    }
}
