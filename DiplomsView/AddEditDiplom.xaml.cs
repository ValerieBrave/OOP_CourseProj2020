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
using System.Net.Mail;
using System.Net;

namespace DiplomsView
{
    /// <summary>
    /// Логика взаимодействия для AddDiplom.xaml
    /// </summary>
    public partial class AddEditDiplom : Window
    {
        public ContextDB db;
        public dbExceptionHandler ex_handler;
        AddEditFormFiller filler;
        bool edit = false;
        Expander to_del = new Expander();
        private string password = "21625";
        public AddEditDiplom()
        {
            InitializeComponent();
        }
        public AddEditDiplom(dbExceptionHandler handler)
        {
            InitializeComponent();
            db = SingleContext.getContext();
            ex_handler = handler;
            filler = new AddEditFormFiller(this.db, this.ex_handler);
            filler.FillAddForm(this.order_select,
                            this.spec_select,
                            this.supervisor_select,
                            this.setter_select,
                            this.reviewer_select,
                            this.comission_select,
                            this.form_p_select,
                            this.chairman_select);
            this.error_info.Text = ex_handler.Protocol;
        }

        public AddEditDiplom(ContextDB c, dbExceptionHandler handler, Expander to_d)
        {
            InitializeComponent();
            db = c;
            ex_handler = handler;
            to_del = to_d;
            edit = true;
            this.btn_Add.Content = "Редактировать";
            filler = new AddEditFormFiller(this.db, this.ex_handler);
            filler.FillEditForm(this.to_del,
                            this.order_select,
                            this.spec_select,
                            this.supervisor_select,
                            this.setter_select,
                            this.reviewer_select,
                            this.comission_select,
                            this.form_p_select,
                            this.form_w_select,
                            this.chairman_select,
                            this.topic_select,
                            this.student_select,
                            this.deadline_select,
                            this.examdate_select,
                            this.position_select,
                            this.mark_select);
            this.error_info.Text = ex_handler.Protocol;
        }

        private void Add()
        {
            bool correct = true;
            Order d_or = new Order();
            String d_form = "", d_student = "", d_topic = "";
            Speciality d_spec = new Speciality();
            Supervisor d_sup = new Supervisor();
            Reviewer d_rev = new Reviewer();
            Comission d_com = new Comission();
            Chairman d_chair = new Chairman();
            DiplomsDB.Models.Setter d_set = new DiplomsDB.Models.Setter();
            DateTime d_exam = new DateTime(), d_deadline = new DateTime();
            int d_pos = 0, d_mark = 0;
            
            try
            {
                d_or = (Order)this.order_select.SelectedItem;
                if ((bool)this.form_p_select.IsChecked) d_form = "п";
                else d_form = "р";
                d_student = this.student_select.Text;
                d_topic = this.topic_select.Text;
                d_spec = (Speciality)this.spec_select.SelectedItem;
                d_sup = (Supervisor)this.supervisor_select.SelectedItem;
                d_rev = (Reviewer)this.reviewer_select.SelectedItem;
                d_com = (Comission)this.comission_select.SelectedItem;
                d_chair = (Chairman)this.chairman_select.SelectedItem;
                d_set = (DiplomsDB.Models.Setter)this.setter_select.SelectedItem;
                if (this.deadline_select.SelectedDate != null && this.examdate_select.SelectedDate != null)
                {
                    this.deadline_select.BorderBrush = new SolidColorBrush(Colors.Gray);
                    this.examdate_select.BorderBrush = new SolidColorBrush(Colors.Gray);
                    if (this.deadline_select.SelectedDate.Value >= this.examdate_select.SelectedDate.Value)
                    {
                        this.deadline_select.BorderBrush = new SolidColorBrush(Colors.Red);
                        ex_handler.Protocol = "Некорректный срок предоставления / дата защиты";
                        correct = false;
                        //error_messages = "Некорректный срок предоставления / дата защиты" + '\n' + error_messages;
                        //throw new Exception("Некорректный срок предоставления / дата защиты");
                    }
                }
                if (this.deadline_select.SelectedDate != null) d_deadline = this.deadline_select.SelectedDate.Value;
                if (this.examdate_select.SelectedDate != null) d_exam = this.examdate_select.SelectedDate.Value;
                if (this.mark_select.Text != "" && int.TryParse(this.mark_select.Text, out d_mark))
                {
                    this.mark_select.BorderBrush = new SolidColorBrush(Colors.Gray);
                    if (d_mark < 0 || d_mark > 10)
                    {
                        this.mark_select.BorderBrush = new SolidColorBrush(Colors.Red);
                        ex_handler.Protocol = "Задано невозможное значение оценки";
                        correct = false;
                        //error_messages = "Задано невозможное значение оценки" + '\n' + error_messages;
                        //throw new Exception("Задано невозможное значение оценки");
                    }
                }
                else if (this.mark_select.Text == "") d_mark = 0;
                else
                {
                    ex_handler.Protocol = "Ошибка в записи оценки";
                    correct = false;
                }
                //error_messages = "Ошибка в записи оценки" + '\n' + error_messages;
                //throw new Exception("Ошибка в записи оценки");
                if (this.position_select.Text != "" && int.TryParse(this.position_select.Text, out d_pos))
                {
                    this.position_select.BorderBrush = new SolidColorBrush(Colors.Gray);
                    if (d_pos < 0)
                    {
                        this.position_select.BorderBrush = new SolidColorBrush(Colors.Red);
                        ex_handler.Protocol = "Задано невозможное место в очереди";
                        correct = false;
                        //error_messages = "Задано невозможное место в очереди" + '\n' + error_messages;
                        //throw new Exception("Задано невозможное место в очереди");
                    }
                }
                else if (this.position_select.Text == "") d_pos = 0;
                else
                {
                    ex_handler.Protocol = "Ошибка в записи места";
                    correct = false;
                }
                //error_messages = "Ошибка в записи места" + '\n' + error_messages;
                //throw new Exception("Ошибка в записи места");

            }
            catch (Exception ex)
            {
                ex_handler.WriteProtocol(ex);
            }
            finally
            {
                
                this.error_info.Text = ex_handler.Protocol;
                if (correct)       // значит все правильно
                {
                    try
                    {
                        Diplom to_add = new Diplom()
                        {
                            Order_id = d_or.Order_id,
                            Speciality_id = d_spec.Speciality_id,
                            Supervisor_id = d_sup.Supervisor_id,
                            Setter_id = d_set.Setter_id,
                            Reviewer_id = d_rev.Reviewer_id,
                            Comission_id = d_com.Comission_id,
                            Chairman_id = d_chair.Chairman_id,
                            Form = d_form,
                            Student_name = d_student,
                            Topic = d_topic,
                            Deadline = d_deadline,
                            ExamDate = d_exam,
                            Date_position = d_pos,
                            Mark = d_mark
                        };
                        this.db.AddDiplom(to_add);
                        //---------SENDING MAIL
                        if(!d_sup.Mail.Equals(""))
                        {
                            MailAddress mailAddressFrom = new MailAddress("smw60@mail.ru", "Зав.каф. ИСиТ");
                            MailAddress mailAddressTo = new MailAddress(d_sup.Mail);
                            MailMessage message = new MailMessage(mailAddressFrom, mailAddressTo);
                            message.Body = "help pls a";
                            SmtpClient smtpClient = new SmtpClient();
                            smtpClient.Host = "smtp.mail.ru";
                            smtpClient.Port = 587;
                            smtpClient.EnableSsl = true;
                            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtpClient.UseDefaultCredentials = false;
                            smtpClient.Credentials = new NetworkCredential(mailAddressFrom.Address, password);
                            smtpClient.Send(message);
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        ex_handler.WriteProtocol(ex);
                    }

                }
            }
        }

        private void Edit()
        {
            bool correct = true;
            Order d_or = new Order();
            String d_form = "", d_student = "", d_topic = "";
            Speciality d_spec = new Speciality();
            Supervisor d_sup = new Supervisor();
            Reviewer d_rev = new Reviewer();
            Comission d_com = new Comission();
            Chairman d_chair = new Chairman();
            DiplomsDB.Models.Setter d_set = new DiplomsDB.Models.Setter();
            DateTime d_exam = new DateTime(), d_deadline = new DateTime();
            int d_pos = 0, d_mark = 0;

            try
            {
                d_or = (Order)this.order_select.SelectedItem == null? db.GetOrderById("--не назначен--"): (Order)this.order_select.SelectedItem;
                if ((bool)this.form_p_select.IsChecked) d_form = "п";
                else d_form = "р";
                d_student = this.student_select.Text;
                d_topic = this.topic_select.Text;
                d_spec = (Speciality)this.spec_select.SelectedItem;
                d_sup = (Supervisor)this.supervisor_select.SelectedItem;
                d_rev = (Reviewer)this.reviewer_select.SelectedItem;
                d_com = (Comission)this.comission_select.SelectedItem;
                d_chair = (Chairman)this.chairman_select.SelectedItem;
                d_set = (DiplomsDB.Models.Setter)this.setter_select.SelectedItem;
                if (this.deadline_select.SelectedDate != null && this.examdate_select.SelectedDate != null)
                {
                    this.deadline_select.BorderBrush = new SolidColorBrush(Colors.Gray);
                    this.examdate_select.BorderBrush = new SolidColorBrush(Colors.Gray);
                    if (this.deadline_select.SelectedDate.Value >= this.examdate_select.SelectedDate.Value)
                    {
                        this.deadline_select.BorderBrush = new SolidColorBrush(Colors.Red);
                        ex_handler.Protocol = "Некорректный срок предоставления / дата защиты";
                        correct = false;
                    }
                }
                if (this.deadline_select.SelectedDate != null) d_deadline = this.deadline_select.SelectedDate.Value;
                if (this.examdate_select.SelectedDate != null) d_exam = this.examdate_select.SelectedDate.Value;
                if (this.mark_select.Text != "" && int.TryParse(this.mark_select.Text, out d_mark))
                {
                    this.mark_select.BorderBrush = new SolidColorBrush(Colors.Gray);
                    if (d_mark < 0 || d_mark > 10)
                    {
                        this.mark_select.BorderBrush = new SolidColorBrush(Colors.Red);
                        ex_handler.Protocol = "Задано невозможное значение оценки";
                        correct = false;
                    }
                }
                else if (this.mark_select.Text == "") d_mark = 0;
                else
                {
                    ex_handler.Protocol = "Ошибка в записи оценки";
                    correct = false;
                }
                if (this.position_select.Text != "" && int.TryParse(this.position_select.Text, out d_pos))
                {
                    this.position_select.BorderBrush = new SolidColorBrush(Colors.Gray);
                    if (d_pos < 0)
                    {
                        this.position_select.BorderBrush = new SolidColorBrush(Colors.Red);
                        ex_handler.Protocol = "Задано невозможное место в очереди";
                        correct = false;
                    }
                }
                else if (this.position_select.Text == "") d_pos = 0;
                else
                {
                    ex_handler.Protocol = "Ошибка в записи места";
                    correct = false;
                }
            }
            catch (Exception ex)
            {
                ex_handler.WriteProtocol(ex);
            }
            finally
            {
                //this.error_info.Text = ex_handler.Protocol;
                if (correct)       // значит все правильно
                {
                    try
                    {
                        Diplom to_add = new Diplom()
                        {
                            Order_id = d_or.Order_id,
                            Speciality_id = d_spec.Speciality_id,
                            Supervisor_id = d_sup.Supervisor_id,
                            Setter_id = d_set.Setter_id,
                            Reviewer_id = d_rev.Reviewer_id,
                            Comission_id = d_com.Comission_id,
                            Chairman_id = d_chair.Chairman_id,
                            Form = d_form,
                            Student_name = d_student,
                            Topic = d_topic,
                            Deadline = d_deadline,
                            ExamDate = d_exam,
                            Date_position = d_pos,
                            Mark = d_mark
                        };
                        this.db.UpdDiplom((int)this.to_del.Tag, to_add);
                    }
                    catch (Exception ex)
                    {
                        ex_handler.WriteProtocol(ex);
                    }

                }
            }
        }

        public void RefreshForm(string id)
        {
            filler.FillAddForm(this.order_select,
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
            if (!edit) Add();
            else
            {
                Edit();
            }
            
        }

        public void ShowProtocol(string pr)
        {
            this.error_info.Text = pr + this.error_info.Text;
        }
        public void ShowDipAddSuccess(string topic)
        {
            this.error_info.Text = "Добавлен новый диплом " +
                (topic.Equals("")? "" : "'"+topic+"'") + 
                '\n' + this.error_info.Text;
        }
        public void ShowDipDelSuccess(string topic)
        {
            this.error_info.Text = "Удален диплом " +
                (topic.Equals("") ? "" : "'" + topic + "'") +
                '\n' + this.error_info.Text;
        }
        public void ShowDipUpdSuccess(string info)
        {
            this.error_info.Text = "Изменен диплом " +
                info +
                '\n' + this.error_info.Text;
        }
        public void ShowSupDelSuccess(string id)
        {
            this.error_info.Text = "Удален руководитель " + id + '\n' + this.error_info.Text;
        }
        public void ShowSupUpdSuccess(string id)
        {
            this.error_info.Text = "Изменен руководитель " + id + '\n' + this.error_info.Text;
        }
        public void ShowSupAddSuccess(string id)
        {
            this.error_info.Text = "Добавлен руководитель " + id + '\n' + this.error_info.Text;
        }
        public void ShowOrdDelSuccess(string id)
        {
            this.error_info.Text = "Удален приказ " + id + '\n' + this.error_info.Text;
        }
        public void ShowOrdUpdSuccess(string id)
        {
            this.error_info.Text = "Изменен приказ " + id + '\n' + this.error_info.Text;
        }
        public void ShowOrdAddSuccess(string id)
        {
            this.error_info.Text = "Добавлен приказ " + id + '\n' + this.error_info.Text;
        }
        public void ShowComDelSuccess(string id)
        {
            this.error_info.Text = "Удалена комиссия по предзащите " + id + '\n' + this.error_info.Text;
        }
        public void ShowComUpdSuccess(string id)
        {
            this.error_info.Text = "Изменена комиссия по предзащите " + id + '\n' + this.error_info.Text;
        }
        public void ShowComAddSuccess(string id)
        {
            this.error_info.Text = "Добавлена комиссия по предзащите " + id + '\n' + this.error_info.Text;
        }
        public void ShowRevDelSuccess(string id)
        {
            this.error_info.Text = "Удален рецензент " + id + '\n' + this.error_info.Text;
        }
        public void ShowRevUpdSuccess(string id)
        {
            this.error_info.Text = "Изменен рецензент " + id + '\n' + this.error_info.Text;
        }
        public void ShowRevAddSuccess(string id)
        {
            this.error_info.Text = "Добавлен рецензент " + id + '\n' + this.error_info.Text;
        }
        public void ShowSetDelSuccess(string id)
        {
            this.error_info.Text = "Удален нормоконтролёр " + id + '\n' + this.error_info.Text;
        }
        public void ShowSetUpdSuccess(string id)
        {
            this.error_info.Text = "Изменен нормоконтролёр " + id + '\n' + this.error_info.Text;
        }
        public void ShowSetAddSuccess(string id)
        {
            this.error_info.Text = "Добавлен нормоконтролёр " + id + '\n' + this.error_info.Text;
        }
        public void ShowSpecDelSuccess(string id)
        {
            this.error_info.Text = "Удалена специальность " + id + '\n' + this.error_info.Text;
        }
        public void ShowSpecUpdSuccess(string id)
        {
            this.error_info.Text = "Изменена специальность " + id + '\n' + this.error_info.Text;
        }
        public void ShowSpecAddSuccess(string id)
        {
            this.error_info.Text = "Добавлена специальность " + id + '\n' + this.error_info.Text;
        }
        public void ShowChaDelSuccess(string id)
        {
            this.error_info.Text = "Удален председатель ГЭК " + id + '\n' + this.error_info.Text;
        }
        public void ShowChaUpdSuccess(string id)
        {
            this.error_info.Text = "Изменен председатель ГЭК " + id + '\n' + this.error_info.Text;
        }
        public void ShowChaAddSuccess(string id)
        {
            this.error_info.Text = "Добавлен председатель ГЭК " + id + '\n' + this.error_info.Text;
        }
        private void AddEditDiplom_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Subscriber.Unsubscribe(this);
        }
    }
}
