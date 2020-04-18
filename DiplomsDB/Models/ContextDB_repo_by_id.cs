using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomsDB.Models
{
    public partial class ContextDB
    {
        public Diplom GetDiplomByID(int id)
        {
            return this.Diploms.Find(id);
        }
        public Order GetOrderById(string id)
        {
            return this.Orders.Find(id);
        }
        public Reviewer GetReviewerById(string id)
        {
            return this.Reviewers.Find(id);
        }
        public Setter GetSetterById(string id)
        {
            return this.Setters.Find(id);
        }
        public Speciality GetSpecialityById(string id)
        {
            return this.Specialities.Find(id);
        }
        public Supervisor GetSupervisorById(string id)
        {
            return this.Supervisors.Find(id);
        }
        public Chairman GetChairmanById(string id)
        {
            return this.Chairmen.Find(id);
        }
        public Comission GetComissionById(string id)
        {
            return this.Comissions.Find(id);
        }
    }
}
