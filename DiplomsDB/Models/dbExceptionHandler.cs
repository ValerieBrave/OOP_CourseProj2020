using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomsDB.Models
{
    public class dbExceptionHandler
    {
        private string _protocol="";
        public string Protocol
        {
            get { return this._protocol; }
            set { this._protocol = value + '\n'+ this._protocol; }
        }
        //Конфликт инструкции INSERT с ограничением FOREIGN KEY "Diploms_Supervisors_fk". Конфликт произошел в базе данных "Diploms", таблица "dbo.Supervisors", column 'Supervisor_id'.

        public bool WriteProtocol(DbUpdateException ex)
        {
            this.Protocol = ex.InnerException.InnerException.Message ?? "Неизвестная ошибка";
            return true;
        }
        public bool WriteProtocol(InvalidOperationException ex)
        {
            this.Protocol = ex.InnerException.Message ?? "Неизвестная ошибка";
            return true;
        }
        public bool WriteProtocol(Exception ex)
        {
            this.Protocol = ex.Message ?? "Неизвестная ошибка";
            return true;
        }
    }
}
