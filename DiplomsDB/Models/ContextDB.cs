namespace DiplomsDB.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContextDB : DbContext
    {
        public ContextDB()
            : base("name=diploms")
        {
        }
        //------delegates
        public delegate void onDipAdd(string topic);
        public delegate void onDipDelete(string topic);
        public delegate void onDipUpdate(string info);
        public delegate void onSupDelete(string id);
        public delegate void onSupUpdate(string id);
        public delegate void onSupAdd(string id);
        //------events
        public event onDipAdd diplomAdded;
        public event onDipDelete diplomDeleted;
        public event onDipUpdate diplomUpdated;
        public event onSupDelete supDeleted;
        public event onSupUpdate supUpdated;
        public event onSupAdd supAdded;
        //------------
        public virtual DbSet<Chairman> Chairmen { get; set; }
        public virtual DbSet<Comission> Comissions { get; set; }
        public virtual DbSet<Diplom> Diploms { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Reviewer> Reviewers { get; set; }
        public virtual DbSet<Setter> Setters { get; set; }
        public virtual DbSet<Speciality> Specialities { get; set; }
        public virtual DbSet<Supervisor> Supervisors { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diplom>()
                .Property(e => e.Form)
                .IsFixedLength();
                
        }
    }
}
