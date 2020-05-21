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
        public delegate void onOrdDelete(string id);
        public delegate void onOrdUpdate(string id);
        public delegate void onOrdAdd(string id);
        public delegate void onComDelete(string id);
        public delegate void onComUpdate(string id);
        public delegate void onComAdd(string id);
        public delegate void onRevDelete(string id);
        public delegate void onRevUpdate(string id);
        public delegate void onRevAdd(string id);
        public delegate void onSetDelete(string id);
        public delegate void onSetUpdate(string id);
        public delegate void onSetAdd(string id);
        public delegate void onSpecDelete(string id);
        public delegate void onSpecUpdate(string id);
        public delegate void onSpecAdd(string id);
        public delegate void onChaDelete(string id);
        public delegate void onChaUpdate(string id);
        public delegate void onChaAdd(string id);
        //------events
        public event onDipAdd diplomAdded;
        public event onDipDelete diplomDeleted;
        public event onDipUpdate diplomUpdated;
        public event onSupDelete supDeleted;
        public event onSupUpdate supUpdated;
        public event onSupAdd supAdded;
        public event onOrdDelete ordDeleted;
        public event onOrdUpdate ordUpdated;
        public event onOrdAdd ordAdded;
        public event onComDelete comDeleted;
        public event onComUpdate comUpdated;
        public event onComAdd comAdded;
        public event onRevDelete revDeleted;
        public event onRevUpdate revUpdated;
        public event onRevAdd revAdded;
        public event onSetDelete setDeleted;
        public event onSetUpdate setUpdated;
        public event onSetAdd setAdded;
        public event onSpecDelete specDeleted;
        public event onSpecUpdate specUpdated;
        public event onSpecAdd specAdded;
        public event onChaDelete chaDeleted;
        public event onChaUpdate chaUpdated;
        public event onChaAdd chaAdded;
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
