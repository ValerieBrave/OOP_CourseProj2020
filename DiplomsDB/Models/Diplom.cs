namespace DiplomsDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Diplom
    {
        [Key]
        public int Diplom_id { get; set; }

        [StringLength(50)]
        public string Order_id { get; set; }

        [StringLength(20)]
        public string Speciality_id { get; set; }

        [StringLength(50)]
        public string Supervisor_id { get; set; }

        [StringLength(50)]
        public string Setter_id { get; set; }

        [StringLength(50)]
        public string Reviewer_id { get; set; }

        [StringLength(50)]
        public string Comission_id { get; set; }

        [StringLength(50)]
        public string Chairman_id { get; set; }

        [StringLength(1)]
        public string Form { get; set; }

        [StringLength(50)]
        public string Student_name { get; set; }

        [StringLength(200)]
        public string Topic { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Deadline { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExamDate { get; set; }

        public int? Date_position { get; set; }

        public int? Mark { get; set; }

        public virtual Chairman Chairmen { get; set; }

        public virtual Comission Comissions { get; set; }

        public virtual Order Orders { get; set; }

        public virtual Reviewer Reviewers { get; set; }

        public virtual Setter Setters { get; set; }

        public virtual Speciality Specialities { get; set; }

        public virtual Supervisor Supervisors { get; set; }

        public Diplom()
        {

        }

        public Diplom(Diplom dip)
        {
            //this.Diplom_id = dip.Diplom_id;
            this.Order_id = dip.Order_id;
            this.Speciality_id = dip.Speciality_id;
            this.Supervisor_id = dip.Supervisor_id;
            this.Setter_id = dip.Setter_id;
            this.Reviewer_id = dip.Reviewer_id;
            this.Comission_id = dip.Comission_id;
            this.Chairman_id = dip.Chairman_id;
            this.Form = dip.Form;
            this.Student_name = dip.Student_name;
            this.Topic = dip.Topic;
            this.Deadline = dip.Deadline;
            this.ExamDate = dip.ExamDate;
            this.Date_position = dip.Date_position;
            this.Mark = dip.Mark;
        }

        public void Update(Diplom dip)
        {
            //this.Diplom_id = dip.Diplom_id;
            this.Order_id = dip.Order_id;
            this.Speciality_id = dip.Speciality_id;
            this.Supervisor_id = dip.Supervisor_id;
            this.Setter_id = dip.Setter_id;
            this.Reviewer_id = dip.Reviewer_id;
            this.Comission_id = dip.Comission_id;
            this.Chairman_id = dip.Chairman_id;
            this.Form = dip.Form;
            this.Student_name = dip.Student_name;
            this.Topic = dip.Topic;
            this.Deadline = dip.Deadline;
            this.ExamDate = dip.ExamDate;
            this.Date_position = dip.Date_position;
            this.Mark = dip.Mark;
        }
    }
}
