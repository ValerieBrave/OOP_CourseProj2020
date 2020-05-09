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
    }
}
