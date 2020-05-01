namespace DiplomsDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reviewer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reviewer()
        {
            Diploms = new HashSet<Diplom>();
        }

        [Key]
        [StringLength(50)]
        public string Reviewer_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diplom> Diploms { get; set; }
        
        public void Update(Reviewer r)
        {
            this.Reviewer_id = r.Reviewer_id;
        }
        public override string ToString()
        {
            return this.Reviewer_id;
        }
    }
}
