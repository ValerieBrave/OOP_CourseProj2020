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
        Label name;
        ListBox catalog;
        int cat_id;
        public CatalogFiller(ContextDB d, dbExceptionHandler h, Catalog c, ListBox cat, Label nam, int id)
        {
            db = d;
            handler = h;
            catalog = cat;
            cat_win = c;
            name = nam;
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
        public Grid getGrid(Order or)
        {
            Grid rc = new Grid();
            Styler.catalogListItem(rc, or);
            var del = rc.Children.OfType<Button>().Where(i => (Grid.GetColumn(i) == 2)).First<Button>();
            var edit = rc.Children.OfType<Button>().Where(i => (Grid.GetColumn(i) == 1)).First<Button>();
            ((Button)del).Tag = or.Order_id;
            ((Button)del).Click += new RoutedEventHandler(OpenSureToDel);
            ((Button)edit).Tag = or.Order_id;
            ((Button)edit).Click += new RoutedEventHandler(OpenEditCatElement);
            return rc;
        }
        public Grid getGrid(Comission com)
        {
            Grid rc = new Grid();
            Styler.catalogListItem(rc, com);
            var del = rc.Children.OfType<Button>().Where(i => (Grid.GetColumn(i) == 2)).First<Button>();
            var edit = rc.Children.OfType<Button>().Where(i => (Grid.GetColumn(i) == 1)).First<Button>();
            ((Button)del).Tag = com.Comission_id;
            ((Button)del).Click += new RoutedEventHandler(OpenSureToDel);
            ((Button)edit).Tag = com.Comission_id;
            ((Button)edit).Click += new RoutedEventHandler(OpenEditCatElement);
            return rc;
        }
        public void Fill(int id)
        {
            try
            {
                if (id == 1)    //Supervisors
                {
                    name.Content = "Все руководители:";
                    List<Supervisor> revs = db.GetAllSupervisorsList();
                    foreach (Supervisor r in revs) catalog.Items.Add(getGrid(r));
                }
                if(id == 2)     //Orders
                {
                    name.Content = "Все приказы:";
                    List<Order> ors = db.GetAllOrdersList();
                    foreach (Order o in ors) catalog.Items.Add(getGrid(o));
                }
                if(id == 3)     //Comissions
                {
                    name.Content = "Комиссии по предзащите:";
                    List<Comission> coms = db.GetAllComissionsList();
                    foreach (Comission c in coms) catalog.Items.Add(getGrid(c));
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
        public void FillEditOthers(int cat_id, string del_id, TextBlock oldid, TextBlock oldid_help, TextBlock newid_help)
        {
            if (cat_id == 2)
            {
                oldid.Text = del_id;
                oldid_help.Text = "Идентификатор приказа:";
                newid_help.Text = "Новый идентификатор:";
            }
            if(cat_id == 3)
            {
                oldid.Text = del_id;
                oldid_help.Text = "Председатель комиссии:";
                newid_help.Text = "Новый председатель:";
            }
        }
    }
}
