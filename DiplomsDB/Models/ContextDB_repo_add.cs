using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomsDB.Models
{
    public partial class ContextDB
    {
        public Diplom AddDiplom(Diplom dip)
        {
            Diplom rc = null; 
            this.Diploms.Add(dip);
            rc = dip;
            
            this.SaveChanges();
            if (this.diplomAdded != null) this.diplomAdded(dip.Topic);
            return rc;
        }
        public Order AddOrder(Order or)
        {
            Order rc = null;
            this.Orders.Add(or);
            rc = or;
            this.SaveChanges();
            return rc;
        }
        public Reviewer AddReviewer(Reviewer rev)
        {
            Reviewer rc = null;
            this.Reviewers.Add(rev);
            rc = rev;
            this.SaveChanges();
            return rc;
        }
        public Setter AddSetter(Setter se)
        {
            Setter rc = null;
            this.Setters.Add(se);
            rc = se;
            this.SaveChanges();
            return rc;
        }
        public Speciality AddSpeciality(Speciality sp)
        {
            Speciality rc = null;
            this.Specialities.Add(sp);
            rc = sp;
            this.SaveChanges();
            return rc;
        }
        public Supervisor AddSupervisor(Supervisor su)
        {
            Supervisor rc = null;
            this.Supervisors.Add(su);
            rc = su;
            this.SaveChanges();
            return rc;
        }
        public Chairman AddChairman(Chairman ch)
        {
            Chairman rc = null;
            this.Chairmen.Add(ch);
            rc = ch;
            this.SaveChanges();
            return rc;
        }
        public Comission AddComission(Comission co)
        {
            Comission rc = null;
            this.Comissions.Add(co);
            rc = co;
            this.SaveChanges();
            return rc;
        }
    }
}
