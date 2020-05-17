using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DiplomsDB.Models;

namespace DiplomsView
{
    public class FilterFiller
    {
        ContextDB db;
        Grid filter;
        public FilterFiller(Grid f, ContextDB c)
        {
            db = c;
            filter = f;
        }
        public void Fill(ComboBox orders, ComboBox spec, ComboBox supers, ComboBox setters, ComboBox revs, ComboBox comission, RadioButton def)
        {
            orders.Items.Clear();
            spec.Items.Clear();
            supers.Items.Clear();
            setters.Items.Clear();
            revs.Items.Clear();
            comission.Items.Clear();
            foreach (Order o in db.GetAllOrdersList()) orders.Items.Add(o);
            foreach (Speciality s in db.GetAllSpecialitiesList()) spec.Items.Add(s);
            foreach (Supervisor s in db.GetAllSupervisorsList()) supers.Items.Add(s);
            foreach (Setter s in db.GetAllSettersList()) setters.Items.Add(s);
            foreach (Reviewer r in db.GetAllReviewersList()) revs.Items.Add(r);
            foreach (Comission c in db.GetAllComissionsList()) comission.Items.Add(c);
            orders.SelectedIndex = 0;
            spec.SelectedIndex = 0;
            supers.SelectedIndex = 0;
            setters.SelectedIndex = 0;
            revs.SelectedIndex = 0;
            comission.SelectedIndex = 0;
            def.IsChecked = true;
        }
    }
}
