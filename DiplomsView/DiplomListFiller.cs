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
        ContextDB db = new ContextDB();
        StackPanel stackpanel;
        public DiplomListFiller(StackPanel s)
        {
            stackpanel = s;
        }
        Expander getExpander(Diplom dip)
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
                foreach(Diplom d in alldips)
                {
                    stackpanel.Children.Add(getExpander(d));
                }
            }
            catch(Exception e)
            {

            }
        }
    }
}
