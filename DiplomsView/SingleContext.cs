using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomsDB.Models;

namespace DiplomsView
{
    public class SingleContext
    {
        private static ContextDB db;
        private SingleContext() { }
        public static ContextDB getContext()
        {
            if (db == null) db = new ContextDB();
            return db;
        }
    }
}
