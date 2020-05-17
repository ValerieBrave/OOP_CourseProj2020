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
    public class CatalogFiller
    {
        ContextDB db;
        dbExceptionHandler handler;
        Catalog cat_win;
        ListBox catalog;
        int cat_id;
        public CatalogFiller(ContextDB d, dbExceptionHandler h, Catalog c, ListBox cat, int id)
        {
            db = d;
            handler = h;
            catalog = cat;
            cat_win = c;
            cat_id = id;
        }
        private void OpenSureToDel(object sender, RoutedEventArgs e)
        {
            SureToDel std = new SureToDel(db, handler, ((Button)sender).Tag.ToString(), cat_id);
            std.ShowDialog();
        }
        public Grid getGrid(Supervisor sup)
        {
            Grid rc = new Grid();
            Styler.catalogListItem(rc, sup);
            var del = rc.Children.OfType<Button>().Where(i => (Grid.GetColumn(i) == 2)).First<Button>();
            ((Button)del).Tag = sup.Supervisor_id;
            ((Button)del).Click += new RoutedEventHandler(OpenSureToDel);
            
            
            return rc;
        }

        public void Fill(int id)
        {
            try
            {
                if (id == 1)
                {
                    List<Supervisor> revs = db.GetAllSupervisorsList();
                    foreach (Supervisor r in revs) catalog.Items.Add(getGrid(r));
                }
            }
            catch(Exception ex)
            {
                handler.WriteProtocol(ex);
            }
        }
    }
}
