using DiplomsDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DiplomsView
{
    public class AddFormFiller
    {
        ContextDB db;
        public AddFormFiller(ContextDB c)
        {
            db = c;
        }
        public void FillForm(ComboBox orders, ComboBox spec, ComboBox supers, ComboBox setters, ComboBox revs, ComboBox comission, RadioButton def, ComboBox chair)
        {
            foreach (Order o in db.GetAllOrdersList())
            {
                orders.Items.Add(o);
                if (o.Order_id.Equals("--не назначен--")) orders.SelectedItem = o;
            } 
            foreach (Speciality s in db.GetAllSpecialitiesList())
            {
                spec.Items.Add(s);
                if (s.Speciality_id.Equals("ИСиТ")) spec.SelectedItem = s;
            }
            foreach (Supervisor s in db.GetAllSupervisorsList())
            {
                supers.Items.Add(s);
                if (s.Supervisor_id.Equals("--не назначен--")) supers.SelectedItem = s;
            }
            foreach (Setter s in db.GetAllSettersList())
            {
                setters.Items.Add(s);
                if (s.Setter_id.Equals("--не назначен--")) setters.SelectedItem = s;
            }
            foreach (Reviewer r in db.GetAllReviewersList())
            {
                revs.Items.Add(r);
                if (r.Reviewer_id.Equals("--не назначен--")) revs.SelectedItem = r;
            }
            foreach (Comission c in db.GetAllComissionsList())
            {
                comission.Items.Add(c);
                if (c.Comission_id.Equals("--не назначен--")) comission.SelectedItem = c;
            }
            foreach(Chairman c in db.GetAllChairmenList())
            {
                chair.Items.Add(c);
                if (c.Chairman_id.Equals("--не назначен--")) chair.SelectedItem = c;

            }
            def.IsChecked = true;
        }

        //public bool Check(TextBox mark, TextBox position, DatePicker deadline, DatePicker exam)
        //{
        //    bool rc = true;
        //    int m, p;
        //    if(int.TryParse(mark.Text, out m))
        //    {
        //        if (m < 0 || m > 10) throw new Exception("Невозможное значение оценки");
        //    }
        //    else throw new Exception("Ошибка в записи оценки");
        //    return rc;
        //}
    }
}
