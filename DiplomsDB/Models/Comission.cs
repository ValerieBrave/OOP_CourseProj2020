namespace DiplomsDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comission()
        {
            Diploms = new HashSet<Diplom>();
        }

        [Key]
        [StringLength(50)]
        public string Comission_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diplom> Diploms { get; set; }

        public void Update(Comission co)
        {
            this.Comission_id = co.Comission_id;
        }
        public override string ToString()
        {
            return this.Comission_id;
        }
    }
}
