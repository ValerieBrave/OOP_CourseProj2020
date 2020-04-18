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
            this.Diploms.Remove(this.GetDiplomByID(id));
            this.SaveChanges();
        }
    }
}
