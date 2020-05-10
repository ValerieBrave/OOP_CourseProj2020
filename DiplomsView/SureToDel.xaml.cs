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
    /// Логика взаимодействия для SureToDel.xaml
    /// </summary>
    public partial class SureToDel : Window
    {
        ContextDB db;
        dbExceptionHandler ex_handler;
        public Expander selected;
        
        private void FillInfo()
        {
            Diplom to_del = db.GetDiplomByID((int)selected.Tag);
            this.dip_info.Text = "Тема: \"" + to_del.Topic + "\"" + '\n';
            this.dip_info.Text += "Форма: " + to_del.Form + '\n';
            this.dip_info.Text += "Студент: " + to_del.Student_name + '\n';
            this.dip_info.Text += "Руководитель: " + to_del.Supervisor_id + '\n';
            this.dip_info.Text += "Рецензент: " + to_del.Reviewer_id + '\n';
            this.dip_info.Text += "Комиссия: " + to_del.Comission_id + '\n';
            this.dip_info.Text += "Срок предоставления: " + (to_del.Deadline == null? "" : to_del.Deadline.Value.Date.ToString() )+ '\n';
        }

        public SureToDel(ContextDB d, dbExceptionHandler h, Expander ex)
        {
            InitializeComponent();
            this.db = d;
            this.ex_handler = h;
            this.selected = ex;
            FillInfo();
            
        }

        private void btn_DelDip_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.DeleteDiplom((int)selected.Tag);
            }
            catch (Exception ex)
            {
                ex_handler.WriteProtocol(ex);
            }
            finally
            {
                this.Close();
            }
        }
    }
}
