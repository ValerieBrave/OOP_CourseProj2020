using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomsDB.Models
{
    public partial class ContextDB
    {
        public class ExceptionDb : DbUpdateException
        {
            public ExceptionDb() :base(){ }
        }
        
    }
}
