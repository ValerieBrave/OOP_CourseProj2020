using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomsDB.Models;

namespace TestDB
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ContextDB db = new ContextDB();
            dbExceptionHandler exHandler = new dbExceptionHandler();
            Supervisor sup = db.GetSupervisorById("Блинова Е.А.");
            Order or = new Order() { Order_id = "--не назначен--" };
            Comission com = new Comission() { Comission_id = "--не назначен--" };
            db.AddComission(com);
            //db.DeleteDiplom(250);
            //try
            //{
            //    db.UpdSupervisor(s.Supervisor_id, new Supervisor() { Supervisor_id = "Блинчикова В.В." });
            //}
            //catch(InvalidOperationException e)
            //{
            //    int k = 0;
            //    exHandler.WriteProtocol(e);
            //}
            //Diplom new30 = new Diplom()
            //{
            //    Order_id = "1237-C, 04042019",
            //    Speciality_id = "ПОИБМС",
            //    Supervisor_id = "Шиман Д.В.",
            //    Setter_id = "Петрова М.М.",
            //    Reviewer_id = "Жук Я.А.",
            //    Comission_id = "Жиляк Н.А.",
            //    Chairman_id = "Самаль Д.И.",
            //    Form = "р",
            //    Student_name = "Джойстик А.В.",
            //    Topic = "Электронная очередь на консультацию к преподавателю вуза",
            //    Deadline = DateTime.Now,
            //    ExamDate = DateTime.Now,
            //    Date_position = 7,
            //    Mark = 5
            //};
            //Diplom new30 = new Diplom(db.GetDiplomByID(30));
            //new30.Student_name = "Мостик А.В.";
            //db.UpdDiplom(30, new30);
            //try
            //{
            //    db.AddDiplom(new Diplom()
            //    {
            //        Order_id = "1234-C, 03032019",
            //        Speciality_id = "ПОИТ",
            //        Supervisor_id = "Шиман Д.В.",
            //        Setter_id = "Жигаровская С.А.",
            //        Reviewer_id = "Пацей Н.В.",
            //        Comission_id = "Блинова Е.А.",
            //        Chairman_id = "Комличенко В.Н.",
            //        Form = "р",
            //        Student_name = "Константин Харашкевич",
            //        Topic = "",
            //        Deadline = DateTime.Now,
            //        ExamDate = DateTime.Now,
            //        Date_position = 11,
            //        Mark = 9
            //    });
            //    db.SaveChanges();
            //}
            //catch (DbUpdateException e){exHandler.WriteProtocol(e);}
            
            
            Console.WriteLine("end");
            Console.ReadKey();
        }
    }
}
