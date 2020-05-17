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
        int catalog_id;
        private void FillInfo()
        {
            this.title.Text = "Удалить выбранный диплом?";
            Diplom to_del = db.GetDiplomByID((int)selected.Tag);
            this.info.Text = "Тема: \"" + to_del.Topic + "\"" + '\n';
            this.info.Text += "Форма: " + to_del.Form + '\n';
            this.info.Text += "Студент: " + to_del.Student_name + '\n';
            this.info.Text += "Руководитель: " + to_del.Supervisor_id + '\n';
            this.info.Text += "Рецензент: " + to_del.Reviewer_id + '\n';
            this.info.Text += "Комиссия: " + to_del.Comission_id + '\n';
            this.info.Text += "Срок предоставления: " + (to_del.Deadline == null? "" : to_del.Deadline.Value.Date.ToString() )+ '\n';
        }
        private void FillInfo(string id)
        {
            this.title.Text = "Удалить?";
            this.info.Text = id;
        }
        public SureToDel(ContextDB d, dbExceptionHandler h, Expander ex)
        {
            InitializeComponent();
            this.db = d;
            this.ex_handler = h;
            this.selected = ex;
            FillInfo();
            
        }
        public SureToDel(ContextDB d, dbExceptionHandler h, string todel_id, int cat_id)
        {
            InitializeComponent();
            this.db = d;
            this.ex_handler = h;
            this.catalog_id = cat_id;
            FillInfo(todel_id);

        }
        private void btn_DelDip_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(selected != null) db.DeleteDiplom((int)selected.Tag);
                else if(catalog_id == 1)    //значит удаляем руководителей
                {
                    db.DeleteSupervisor(this.info.Text);
                }
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
