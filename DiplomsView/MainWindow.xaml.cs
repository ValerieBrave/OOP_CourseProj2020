using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DiplomsDB.Models;

namespace DiplomsView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ContextDB db;
        DiplomListFiller list_filler;
        public MainWindow()
        {
            InitializeComponent();
            db = new ContextDB();
            list_filler = new DiplomListFiller(this.diplomsList, db);
            FilterFiller filter_filler = new FilterFiller(this.filterGrid, db);
            list_filler.Fill();
            filter_filler.Fill(this.order_Select, this.spec_Select, this.supervisor_Select, this.setter_Select, this.reviewer_Select, this.comission_Select, this.form_p_Select);

        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            bool search = false;
            String query = "select * from Diploms ";
            if((bool)check_Order.IsChecked)
            {
                search = true;
                query += " where Diploms.Order_id like '" + ((Order)this.order_Select.SelectedItem).Order_id + "'";
            }
            if((bool)this.check_Form.IsChecked)
            {
                if (!search) query += " where Diploms.Form like ";
                else query += " and Diploms.Form like ";
                search = true;
                if ((bool)this.form_p_Select.IsChecked) query += " 'п' ";
                else query += " 'р' ";
            }
            if((bool)this.check_Speciality.IsChecked)
            {
                if (!search) query += "where Diploms.Speciality_id like ";
                else query += " and Diploms.Speciality_id like ";
                search = true;
                query += " '" + ((Speciality)this.spec_Select.SelectedItem).Speciality_id + "' ";
            }
            if((bool)this.check_Student.IsChecked)
            {
                if(this.student_Select.Text != null)
                {
                    if (!search) query += " where Diploms.Student_name like ";
                    else query += " and Diploms.Speciality_id like ";
                    search = true;
                    query += " '%"+ this.student_Select.Text+"%' ";
                }
            }
            if((bool)this.check_Supervisor.IsChecked)
            {
                if (!search) query += " where Diploms.Supervisor_id like ";
                else query += " and Diploms.Supervisor_id like ";
                search = true;
                query += " '" + ((Supervisor)this.supervisor_Select.SelectedItem).Supervisor_id + "' ";
            }
            if((bool)this.check_Topic.IsChecked)
            {
                if(this.topic_Select.Text != null)
                {
                    if (!search) query += " where Diploms.Topic like ";
                    else query += " and Diploms.Topic like ";
                    search = true;
                    query += " '%" + this.topic_Select.Text + "%'";
                }
            }
            if((bool)this.check_Setter.IsChecked)
            {
                if (!search) query += " where Diploms.Setter_id like ";
                else query += " and Diploms.Setter_id like ";
                search = true;
                query += " '" + ((DiplomsDB.Models.Setter)this.setter_Select.SelectedItem).Setter_id + "' ";
            }
            if((bool)this.check_Reviewer.IsChecked)
            {
                if (!search) query += " where Diploms.Reviewer_id like ";
                else query += " and Diploms.Reviewer_id like ";
                search = true;
                query += " '"+((Reviewer)this.reviewer_Select.SelectedItem).Reviewer_id +"' ";
            }
            if((bool)this.check_Comission.IsChecked)
            {
                if (!search) query += " where Diploms.Comission_id like ";
                else query += " and Diploms.Comission_id like ";
                search = true;
                query += " '" + ((Comission)this.comission_Select.SelectedItem).Comission_id + "' ";
            }
            if((bool)this.check_Deadline.IsChecked)
            {
                if(this.deadline_Select.SelectedDate != null)
                {
                    if (!search) query += " where Diploms.Deadline <= ";
                    else query += " and Diploms.Deadline <= ";
                    search = true;
                    query += " '" + ((DateTime)this.deadline_Select.SelectedDate).ToString("yyyy-MM-dd") + "' ";
                }
            }
            if ((bool)this.check_ExamDate.IsChecked)
            {
                if (this.examdate_Select.SelectedDate != null)
                {
                    if (!search) query += " where Diploms.ExamDate like ";
                    else query += " and Diploms.ExamDate like ";
                    search = true;
                    query += " '" + ((DateTime)this.examdate_Select.SelectedDate).ToString("yyyy-MM-dd") + "' ";
                }
            }
            var dips = this.db.Database.SqlQuery<Diplom>(query);
            this.diplomsList.Items.Clear();
            foreach (var dip in dips) this.diplomsList.Items.Add(list_filler.getExpander((Diplom)dip));
            this.diplomsList.Items.Refresh();
        }
    }
}
