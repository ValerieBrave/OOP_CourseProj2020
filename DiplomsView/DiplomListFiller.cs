using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DiplomsDB.Models;

namespace DiplomsView
{
    public class DiplomListFiller
    {
        ContextDB db;
        ListView listview;
        dbExceptionHandler handler;
        public DiplomListFiller(ListView l, ContextDB c, dbExceptionHandler h )
        {
            db = c;
            listview = l;
            handler = h;
        }
        public Expander getExpander(Diplom dip)
        {
            Expander rc = new Expander();
            rc.Tag = dip.Diplom_id;
            Styler.dipExpanderStyle(rc);
            Styler.dipExpanderContent(rc, dip);
            return rc;
        }
        public void Fill()
        {
            try
            {
                List<Diplom> alldips = db.GetAllDiplomsList();
                foreach(Diplom d in alldips) listview.Items.Add(getExpander(d));
            }
            catch(Exception ex)
            {
                handler.WriteProtocol(ex);
            }
        }
        
    }
}
