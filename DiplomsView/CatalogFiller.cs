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
        public Grid getGrid(Reviewer rev)
        {
            Grid rc = new Grid();
            Styler.catalogListItem(rc, rev);
            var del = rc.Children.OfType<Button>().Where(i => (Grid.GetColumn(i) == 2)).First<Button>();
            var edit = rc.Children.OfType<Button>().Where(i => (Grid.GetColumn(i) == 1)).First<Button>();
            ((Button)del).Tag = rev.Reviewer_id;
            ((Button)del).Click += new RoutedEventHandler(OpenSureToDel);
            ((Button)edit).Tag = rev.Reviewer_id;
            ((Button)edit).Click += new RoutedEventHandler(OpenEditCatElement);
            return rc;
        }
        public Grid getGrid(DiplomsDB.Models.Setter st)
        {
            Grid rc = new Grid();
            Styler.catalogListItem(rc, st);
            var del = rc.Children.OfType<Button>().Where(i => (Grid.GetColumn(i) == 2)).First<Button>();
            var edit = rc.Children.OfType<Button>().Where(i => (Grid.GetColumn(i) == 1)).First<Button>();
            ((Button)del).Tag = st.Setter_id;
            ((Button)del).Click += new RoutedEventHandler(OpenSureToDel);
            ((Button)edit).Tag = st.Setter_id;
            ((Button)edit).Click += new RoutedEventHandler(OpenEditCatElement);
            return rc;
        }
        public Grid getGrid(Speciality spec)
        {
            Grid rc = new Grid();
            Styler.catalogListItem(rc, spec);
            var del = rc.Children.OfType<Button>().Where(i => (Grid.GetColumn(i) == 2)).First<Button>();
            var edit = rc.Children.OfType<Button>().Where(i => (Grid.GetColumn(i) == 1)).First<Button>();
            ((Button)del).Tag = spec.Speciality_id;
            ((Button)del).Click += new RoutedEventHandler(OpenSureToDel);
            ((Button)edit).Tag = spec.Speciality_id;
            ((Button)edit).Click += new RoutedEventHandler(OpenEditCatElement);
            return rc;
        }
        public Grid getGrid(Chairman cha)
        {
            Grid rc = new Grid();
            Styler.catalogListItem(rc, cha);
            var del = rc.Children.OfType<Button>().Where(i => (Grid.GetColumn(i) == 2)).First<Button>();
            var edit = rc.Children.OfType<Button>().Where(i => (Grid.GetColumn(i) == 1)).First<Button>();
            ((Button)del).Tag = cha.Chairman_id;
            ((Button)del).Click += new RoutedEventHandler(OpenSureToDel);
            ((Button)edit).Tag = cha.Chairman_id;
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
                if(id == 4)     //Reviewers
                {
                    name.Content = "Рецензенты:";
                    List<Reviewer> revs = db.GetAllReviewersList();
                    foreach (Reviewer r in revs) catalog.Items.Add(getGrid(r));
                }
                if(id == 5)     //Setter
                {
                    name.Content = "Нормоконтролёры:";
                    List<DiplomsDB.Models.Setter> sets = db.GetAllSettersList();
                    foreach (DiplomsDB.Models.Setter s in sets) catalog.Items.Add(getGrid(s));
                }
                if(id == 6)     //Speciality
                {
                    name.Content = "Специальности:";
                    List<Speciality> sps = db.GetAllSpecialitiesList();
                    foreach (Speciality s in sps) catalog.Items.Add(getGrid(s));
                }
                if(id == 7) //Chairman
                {
                    name.Content = "Председатели ГЭК:";
                    List<Chairman> chs = db.GetAllChairmenList();
                    foreach (Chairman c in chs) catalog.Items.Add(getGrid(c));
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
            if (cat_id == 4)
            {
                oldid.Text = del_id;
                oldid_help.Text = "Рецензент:";
                newid_help.Text = "Новый рецензент:";
            }
            if (cat_id == 5)
            {
                oldid.Text = del_id;
                oldid_help.Text = "Нормоконтролёр:";
                newid_help.Text = "Новый нормоконтролёр:";
            }
            if (cat_id == 6)
            {
                oldid.Text = del_id;
                oldid_help.Text = "Специальность:";
                newid_help.Text = "Новая специальность:";
            }
            if (cat_id == 7)
            {
                oldid.Text = del_id;
                oldid_help.Text = "Председатель ГЭК:";
                newid_help.Text = "Новый председатель:";
            }
        }
    }
}
