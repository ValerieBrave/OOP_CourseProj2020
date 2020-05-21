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
using DiplomsDB.Models;

namespace DiplomsView
{
    /// <summary>
    /// Логика взаимодействия для AddCatElement.xaml
    /// </summary>
    public partial class AddCatElement : Window
    {
        ContextDB db;
        dbExceptionHandler handler;
        int cat_id;
        TextBox email;
        public AddCatElement()
        {
            InitializeComponent();
        }
        public AddCatElement(ContextDB d, dbExceptionHandler h, int c_id)
        {
            InitializeComponent();
            db = d;
            handler = h;
            cat_id = c_id;
            if (cat_id == 1) // Supervisors -> +email
            {
                this.cat_name_help.Text = "Добавление нового руководителя";
                //---------------------------
                TextBlock email_help = new TextBlock();
                email_help.Text = "Эл.почта:";
                Grid.SetRow(email_help, 2);
                email_help.Margin = new Thickness(30, 6, 66, 113);
                email_help.Height = 22;
                email_help.FontSize = 16;
                grid.Children.Add(email_help);
                //----------------------------
                email = new TextBox();
                Grid.SetRow(email, 2);
                Grid.SetColumnSpan(email, 2);
                email.Margin = new Thickness(30, 42, 30, 67);
                email.Height = 32;
                email.FontSize = 16;
                grid.Children.Add(email);
            }
            else if (cat_id == 2) this.cat_name_help.Text = "Добавление нового приказа";
            else if (cat_id == 3) this.cat_name_help.Text = "Добавление новой комиссии";
            else if (cat_id == 4) this.cat_name_help.Text = "Добавление нового рецензента";
            else if (cat_id == 5) this.cat_name_help.Text = "Добавление нового нормоконтролёра";
            else if (cat_id == 6) this.cat_name_help.Text = "Добавление новой специальности";
            else if (cat_id == 7) this.cat_name_help.Text = "Добавление нового председателя ГЭК";
        }
        private void btn_AddElement_Click(object sender, RoutedEventArgs e)
        {
            bool add = false;
            try
            {
                if (cat_id == 1) // Supervisor
                {
                    Supervisor sup = new Supervisor();
                    sup.Supervisor_id = this.new_id.Text.Equals("") ? "" : this.new_id.Text;
                    //sup.Mail = this.email.Text.Equals("") ? "": this.email.Text;
                    if(!sup.Supervisor_id.Equals(""))   // email может быть пустым
                    {
                        db.AddSupervisor(sup);
                        add = true;
                    }
                }
                if (cat_id == 2)    //Order
                {
                    Order or = new Order();
                    or.Order_id = this.new_id.Text.Equals("") ? "" : this.new_id.Text;
                    if(!or.Order_id.Equals(""))
                    {
                        db.AddOrder(or);
                        add = true;
                    }
                }
                if (cat_id == 3)    //Comission
                {
                    Comission com = new Comission();
                    com.Comission_id = this.new_id.Text.Equals("") ? "" : this.new_id.Text;
                    if(!com.Comission_id.Equals(""))
                    {
                        db.AddComission(com);
                        add = true;
                    }
                }
                if (cat_id == 4)    //Reviewer
                {
                    Reviewer rev = new Reviewer();
                    rev.Reviewer_id = this.new_id.Text.Equals("") ? "" : this.new_id.Text;
                    if(!rev.Reviewer_id.Equals(""))
                    {
                        db.AddReviewer(rev);
                        add = true;
                    }
                }
                if (cat_id == 5)    // Setter
                {
                    DiplomsDB.Models.Setter st = new DiplomsDB.Models.Setter();
                    st.Setter_id = this.new_id.Text.Equals("") ? "" : this.new_id.Text;
                    if(!st.Setter_id.Equals(""))
                    {
                        db.AddSetter(st);
                        add = true;
                    }
                }
                if (cat_id == 6)    //Speciality
                {
                    Speciality sp = new Speciality();
                    sp.Speciality_id = this.new_id.Text.Equals("") ? "" : this.new_id.Text;
                    if(!sp.Speciality_id.Equals(""))
                    {
                        db.AddSpeciality(sp);
                        add = true;
                    }
                }
                if (cat_id == 7)    //Chairman
                {
                    Chairman ch = new Chairman();
                    ch.Chairman_id = this.new_id.Text.Equals("") ? "" : this.new_id.Text;
                    if(!ch.Chairman_id.Equals(""))
                    {
                        db.AddChairman(ch);
                        add = true;
                    }
                }
            }
            catch(Exception ex)
            {
                handler.WriteProtocol(ex);
            }
            finally
            {
                if (add) this.Close();
            }
        }
    }
}
