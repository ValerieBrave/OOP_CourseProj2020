using DiplomsDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DiplomsView
{
    public class AddEditFormFiller
    {
        ContextDB db;
        dbExceptionHandler ex_handler;
        public AddEditFormFiller(ContextDB c, dbExceptionHandler handler)
        {
            db = c;
            ex_handler = handler;
        }
        public void FillAddForm(ComboBox orders, ComboBox spec, ComboBox supers, ComboBox setters, ComboBox revs, ComboBox comission, RadioButton def, ComboBox chair)
        {
            try
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
                foreach (Chairman c in db.GetAllChairmenList())
                {
                    chair.Items.Add(c);
                    if (c.Chairman_id.Equals("--не назначен--")) chair.SelectedItem = c;

                }
                def.IsChecked = true;
            }
            catch(Exception ex)
            {
                ex_handler.WriteProtocol(ex);
            }
        }

        public void FillEditForm(Expander selected, ComboBox orders, 
            ComboBox spec, ComboBox supers, 
            ComboBox setters, ComboBox revs, 
            ComboBox comission, RadioButton def, 
            RadioButton rb, ComboBox chair, 
            TextBox topic, TextBox student,
            DatePicker dealine, DatePicker exam,
            TextBox pos, TextBox mark)
        {
            try
            {
                Diplom to_edit = db.GetDiplomByID((int)selected.Tag);
                foreach (Order o in db.GetAllOrdersList())
                {
                    orders.Items.Add(o);
                    if (o.Order_id.Equals(to_edit.Order_id)) orders.SelectedItem = o;
                }
                foreach (Speciality s in db.GetAllSpecialitiesList())
                {
                    spec.Items.Add(s);
                    if (s.Speciality_id.Equals(to_edit.Speciality_id)) spec.SelectedItem = s;
                }
                foreach (Supervisor s in db.GetAllSupervisorsList())
                {
                    supers.Items.Add(s);
                    if (s.Supervisor_id.Equals(to_edit.Supervisor_id)) supers.SelectedItem = s;
                }
                foreach (Setter s in db.GetAllSettersList())
                {
                    setters.Items.Add(s);
                    if (s.Setter_id.Equals(to_edit.Setter_id)) setters.SelectedItem = s;
                }
                foreach (Reviewer r in db.GetAllReviewersList())
                {
                    revs.Items.Add(r);
                    if (r.Reviewer_id.Equals(to_edit.Reviewer_id)) revs.SelectedItem = r;
                }
                foreach (Comission c in db.GetAllComissionsList())
                {
                    comission.Items.Add(c);
                    if (c.Comission_id.Equals(to_edit.Comission_id)) comission.SelectedItem = c;
                }
                foreach (Chairman c in db.GetAllChairmenList())
                {
                    chair.Items.Add(c);
                    if (c.Chairman_id.Equals(to_edit.Chairman_id)) chair.SelectedItem = c;
                }
                if (to_edit.Form.Equals("п")) def.IsChecked = true;
                else rb.IsChecked = true;
                topic.Text = to_edit.Topic;
                student.Text = to_edit.Student_name;
                dealine.SelectedDate = to_edit.Deadline;
                exam.SelectedDate = to_edit.ExamDate;
                pos.Text = to_edit.Date_position.ToString();
                mark.Text = to_edit.Mark.ToString();
            }
            catch(Exception ex)
            {
                ex_handler.WriteProtocol(ex);
            }
        }
    }
}
