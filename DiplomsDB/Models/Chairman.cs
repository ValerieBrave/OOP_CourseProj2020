namespace DiplomsDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Chairman
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chairman()
        {
            Diploms = new HashSet<Diplom>();
        }

        [Key]
        [StringLength(50)]
        public string Chairman_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diplom> Diploms { get; set; }

        public void Update(Chairman ch)
        {
            this.Chairman_id = ch.Chairman_id;
        }
    }
}
