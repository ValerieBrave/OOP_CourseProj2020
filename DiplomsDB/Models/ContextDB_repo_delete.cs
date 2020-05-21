using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomsDB.Models
{
    public partial class ContextDB
    {
        public void DeleteDiplom(int id)
        {
            string topic = this.GetDiplomByID(id).Topic;
            this.Diploms.Remove(this.GetDiplomByID(id));
            this.SaveChanges();
            this.diplomDeleted(topic);
        }
        public void DeleteSupervisor(string id)
        {
            this.Supervisors.Remove(this.GetSupervisorById(id));
            this.SaveChanges();
            this.supDeleted(id);
        }
        public void DeleteOrder(string id)
        {
            this.Orders.Remove(this.GetOrderById(id));
            this.SaveChanges();
            this.ordDeleted(id);
        }
        public void DeleteComission(string id)
        {
            this.Comissions.Remove(this.GetComissionById(id));
            this.SaveChanges();
            this.comDeleted(id);
        }
        public void DeleteReviewer(string id)
        {
            this.Reviewers.Remove(this.GetReviewerById(id));
            this.SaveChanges();
            this.revDeleted(id);
        }
        public void DeleteSetter(string id)
        {
            this.Setters.Remove(this.GetSetterById(id));
            this.SaveChanges();
            this.setDeleted(id);
        }
        public void DeleteSpeciality(string id)
        {
            this.Specialities.Remove(this.GetSpecialityById(id));
            this.SaveChanges();
            this.specDeleted(id);
        }
        public void DeleteChairman(string id)
        {
            this.Chairmen.Remove(this.GetChairmanById(id));
            this.SaveChanges();
            this.chaDeleted(id);
        }
    }
}
