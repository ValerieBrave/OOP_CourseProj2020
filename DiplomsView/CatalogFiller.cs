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
        private void OpenEditCatElement(object sender, RoutedEventArgs e)
        {
            EditCatElement ece = new EditCatElement(db, handler, this, ((Button)sender).Tag.ToString(), cat_id);
            cat_win.Close();
            ece.ShowDialog();
        }
        public Grid getGrid(Supervisor sup)
        {
            Grid rc = new Grid();
            Styler.catalogListItem(rc, sup);
            var del = rc.Children.OfType<Button>().Where(i => (Grid.GetColumn(i) == 2)).First<Button>();
            var edit = rc.Children.OfType<Button>().Where(i => (Grid.GetColumn(i) == 1)).First<Button>();
            ((Button)del).Tag = sup.Supervisor_id;
            ((Button)del).Click += new RoutedEventHandler(OpenSureToDel);
            ((Button)edit).Tag = sup.Supervisor_id;
            ((Button)edit).Click += new RoutedEventHandler(OpenEditCatElement);
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
        public void FillEditSupervisor(int cat_id, string ed_id, TextBlock oldid, TextBlock oldemail)
        {
            try
            {
                Supervisor sup = db.GetSupervisorById(ed_id);
                oldid.Text = sup.Supervisor_id;
                //oldemail.Text = sup.Mail
            }
            catch(Exception ex)
            {
                handler.WriteProtocol(ex);
            }
        }
        public void FillEditOthers(int cat_id, string del_id)
        {

        }
    }
}
