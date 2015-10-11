namespace Calorie.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Persons")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            PersonEatStories = new HashSet<PersonEatStory>();
        }

        public int PersonID { get; set; }

        [Required]
        [StringLength(20)]
        public string PersonName { get; set; }

        public float PersonWeight { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonEatStory> PersonEatStories { get; set; }
    }
}
