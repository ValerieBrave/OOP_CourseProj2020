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
            return this.Reviewers.ToList();
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
