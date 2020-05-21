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
    /// Логика взаимодействия для EditCatElement.xaml
    /// </summary>
    public partial class EditCatElement : Window
    {
        ContextDB db;
        dbExceptionHandler handler;
        CatalogFiller filler;
        string edit_id;
        int cat_id;
        TextBlock old_email;
        TextBlock old_email_help;
        TextBox new_email;
        TextBlock new_email_help;
        public EditCatElement()
        {
            InitializeComponent();
        }
        public EditCatElement(ContextDB d, dbExceptionHandler h, CatalogFiller f, string e_id, int c_id)
        {
            InitializeComponent();
            db = d;
            handler = h;
            filler = f;
            edit_id = e_id;
            cat_id = c_id;
            if (cat_id == 1)
            {
                old_email = new TextBlock();
                Grid.SetRow(old_email, 1);
                Grid.SetColumnSpan(old_email, 2);
                old_email.Margin = new Thickness(10, 40, 10, 0);
                this.grid.Children.Add(old_email);
                //-----------------
                new_email = new TextBox();
                Grid.SetRow(new_email, 2);
                Grid.SetColumnSpan(new_email, 2);
                new_email.Margin = new Thickness(10, 97, 10, 72);
                new_email.Name = "new_email";
                new_email.Text = "new_email";
                grid.Children.Add(new_email);
                //---------------------------
                old_email_help = new TextBlock();
                Grid.SetRow(old_email_help, 1);
                old_email_help.Margin = new Thickness(10, 10, 10, 45);
                old_email_help.Text = "Адрес эл. почты:";
                grid.Children.Add(old_email_help);
                //----------------------------
                new_email_help = new TextBlock();
                Grid.SetRow(new_email_help, 2);
                Grid.SetColumn(new_email_help, 0);
                new_email_help.Margin = new Thickness(10, 70, 23, 114);
                grid.Children.Add(new_email_help);
                filler.FillEditSupervisor(cat_id, edit_id, this.old_id, this.old_email);
            }
            else filler.FillEditOthers(cat_id, edit_id, this.old_id, this.old_id_help, this.new_id_help);
        }

        private void btnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            bool edit = false;
            
            try
            {
                if (cat_id == 1) // Supervisor
                {
                    Supervisor old_sup = db.GetSupervisorById(this.edit_id);
                    Supervisor new_sup = new Supervisor();
                    new_sup.Supervisor_id = this.new_id.Text != "" ? this.new_id.Text : old_sup.Supervisor_id;
                    // new_sup.Mail = this.new_email.Text != "" ? this.new_email.Text : old_sup.Mail
                    if (new_sup.Supervisor_id != "")    // || new_sup.Mail != ""
                    {
                        db.UpdSupervisor(this.edit_id, new_sup);
                        edit = true;
                    }
                }
                else if(cat_id == 2)
                {
                    if(this.new_id.Text != "")
                    {
                        Order old_or = db.GetOrderById(this.edit_id);
                        Order new_or = new Order();
                        new_or.Order_id = this.new_id.Text;
                        db.UpdOrder(this.edit_id, new_or);
                        edit = true;
                    }
                }
                else if (cat_id == 3)
                {
                    if (this.new_id.Text != "")
                    {
                        Comission old_com = db.GetComissionById(this.edit_id);
                        Comission new_com = new Comission();
                        new_com.Comission_id = this.new_id.Text;
                        db.UpdComission(this.edit_id, new_com);
                        edit = true;
                    }
                }
                else if(cat_id == 4)
                {
                    if (this.new_id.Text != "")
                    {
                        Reviewer old_rev = db.GetReviewerById(this.edit_id);
                        Reviewer new_rev = new Reviewer();
                        new_rev.Reviewer_id = this.new_id.Text;
                        db.UpdReviewer(this.edit_id, new_rev);
                        edit = true;
                    }
                }
                else if (cat_id == 5)
                {
                    if (this.new_id.Text != "")
                    {
                        DiplomsDB.Models.Setter old_set = db.GetSetterById(this.edit_id);
                        DiplomsDB.Models.Setter new_set = new DiplomsDB.Models.Setter();
                        new_set.Setter_id = this.new_id.Text;
                        db.UpdSetter(this.edit_id, new_set);
                        edit = true;
                    }
                }
                else if (cat_id == 6)
                {
                    if (this.new_id.Text != "")
                    {
                        Speciality old_spec = db.GetSpecialityById(this.edit_id);
                        Speciality new_spec = new Speciality();
                        new_spec.Speciality_id = this.new_id.Text;
                        db.UpdSpeciality(this.edit_id, new_spec);
                        edit = true;
                    }
                }
                else if (cat_id == 7)
                {
                    if (this.new_id.Text != "")
                    {
                        Chairman old_ch = db.GetChairmanById(this.edit_id);
                        Chairman new_ch = new Chairman();
                        new_ch.Chairman_id = this.new_id.Text;
                        db.UpdChairman(this.edit_id, new_ch);
                        edit = true;
                    }
                }
            }
            catch(Exception ex)
            {
                handler.WriteProtocol(ex);
            }
            finally
            {
               if(edit) this.Close();
            }
        }
    }
}
