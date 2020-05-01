namespace DiplomsDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Setter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Setter()
        {
            Diploms = new HashSet<Diplom>();
        }

        [Key]
        [StringLength(50)]
        public string Setter_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diplom> Diploms { get; set; }

        public void Update(Setter se)
        {
            this.Setter_id = se.Setter_id;
        }
        public override string ToString()
        {
            return this.Setter_id;
        }
    }
}
