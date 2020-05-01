namespace DiplomsDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Supervisor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supervisor()
        {
            Diploms = new HashSet<Diplom>();
        }

        [Key]
        [StringLength(50)]
        public string Supervisor_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diplom> Diploms { get; set; }

        public void Update(Supervisor su)
        {
            this.Supervisor_id = su.Supervisor_id;
        }
        public override string ToString()
        {
            return this.Supervisor_id;
        }
    }
}
