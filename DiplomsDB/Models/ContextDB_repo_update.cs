using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomsDB.Models
{
    public partial class ContextDB
    {
        public bool UpdDiplom(int oldid, Diplom newdip)
        {
            bool rc = true;
            string info = "";
            Diplom olddip = this.GetDiplomByID(oldid);
            info = olddip.Order_id + "-" + olddip.Speciality_id + "-рук." + olddip.Supervisor_id + "-студ." + olddip.Student_name;
            olddip.Update(newdip);
            this.SaveChanges();
            if (this.diplomUpdated != null) this.diplomUpdated(info);
            return rc;
        }
        public bool UpdOrder(string oldid, Order or)
        {
            bool rc = true;
            string query = "update Orders set Order_id = '"
               + or.Order_id
               + "' where Order_id like '"
               + oldid
               + "'";
            //Order oldor = this.GetOrderById(oldid);
            //oldor.Update(or);
            var o = this.Database.ExecuteSqlCommand(query);
            this.SaveChanges();
            this.ordUpdated(oldid);
            return rc;
        }
        public bool UpdReviewer(string oldid, Reviewer rev)
        {
            bool rc = true;
            //Reviewer olr = this.GetReviewerById(oldid);
            //olr.Update(rev);
            string query = "update Reviewers set Reviewer_id = '"
               + rev.Reviewer_id
               + "' where Reviewer_id like '"
               + oldid
               + "'";
            var o = this.Database.ExecuteSqlCommand(query);
            this.SaveChanges();
            this.revUpdated(oldid);
            return rc;
        }
        public bool UpdSetter(string oldid, Setter se)
        {
            bool rc = true;
            //Setter ols = this.GetSetterById(oldid);
            //ols.Update(se);
            string query = "update Setters set Setter_id = '"
               + se.Setter_id
               + "' where Setter_id like '"
               + oldid
               + "'";
            var o = this.Database.ExecuteSqlCommand(query);
            this.SaveChanges();
            this.setUpdated(oldid);
            return rc;
        }
        public bool UpdSpeciality(string oldid, Speciality sp)
        {
            bool rc = true;
            //Speciality ols = this.GetSpecialityById(oldid);
            //ols.Update(sp);
            string query = "update Specialities set Speciality_id = '"
                + sp.Speciality_id
                + "' where Speciality_id like '"
                + oldid
                + "'";
            var s = this.Database.ExecuteSqlCommand(query);
            this.SaveChanges();
            this.specUpdated(oldid);
            return rc;
        }
        public bool UpdSupervisor(string oldid, Supervisor su)
        {
            bool rc = true;
            //Supervisor ols = this.GetSupervisorById(oldid);
            //ols.Update(su);
            string query = "update Supervisors set Supervisor_id = '"
                + su.Supervisor_id
                + "' where Supervisor_id like '"
                + oldid
                + "'";
            var s = this.Database.ExecuteSqlCommand(query);
            this.SaveChanges();
            this.supUpdated(oldid);
            return rc;
        }
        public bool UpdChairman(string oldid, Chairman ch)
        {
            bool rc = true;
            //Chairman olc = this.GetChairmanById(oldid);
            //olc.Update(ch);
            string query = "update Chairmen set Chairman_id = '"
                + ch.Chairman_id
                + "' where Chairman_id like '"
                + oldid
                + "'";
            var s = this.Database.ExecuteSqlCommand(query);
            this.SaveChanges();
            this.chaUpdated(oldid);
            return rc;
        }
        public bool UpdComission(string oldid, Comission co)
        {
            bool rc = true;
            //Comission olc = this.GetComissionById(oldid);
            //olc.Update(co);
            string query = "update Comissions set Comission_id = '"
                + co.Comission_id
                + "' where Comission_id like '"
                + oldid
                + "'";
            var s = this.Database.ExecuteSqlCommand(query);
            this.SaveChanges();
            this.comUpdated(oldid);
            return rc;
        }
    }
}
