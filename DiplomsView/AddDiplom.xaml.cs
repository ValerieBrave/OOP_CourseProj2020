using DiplomsDB.Models;
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
using System.Windows.Shapes;

namespace DiplomsView
{
    /// <summary>
    /// Логика взаимодействия для AddDiplom.xaml
    /// </summary>
    public partial class AddDiplom : Window
    {
        ContextDB db;
        AddFormFiller filler;
        public AddDiplom()
        {
            InitializeComponent();
        }
        public AddDiplom(ContextDB c)
        {
            InitializeComponent();
            db = c;
            filler = new AddFormFiller(this.db);
            filler.FillForm(this.order_select,
                            this.spec_select,
                            this.supervisor_select,
                            this.setter_select,
                            this.reviewer_select,
                            this.comission_select,
                            this.form_p_select,
                            this.chairman_select);
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            //this.examdate_select.BorderBrush = new SolidColorBrush(Colors.Red);
            Order d_or;
            String d_form, d_student, d_topic;
            Speciality d_spec;
            Supervisor d_sup;
            Comission d_com;
            Chairman d_chair;
            DiplomsDB.Models.Setter d_set;
            DateTime d_exam, d_deadline;
            int d_pos, d_mark;
            d_or = (Order)this.order_select.SelectedItem;
            if ((bool)this.form_p_select.IsChecked) d_form = "п";
            else d_form = "р";
            d_student = this.student_select.Text;
            d_topic = this.topic_select.Text;
            // TODO валидация + все остальные
        }
    }
}
