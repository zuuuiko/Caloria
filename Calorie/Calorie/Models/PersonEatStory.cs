namespace Calorie.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonEatStory")]
    public partial class PersonEatStory
    {
        [Key]
        public int StoryID { get; set; }

        public int PersonID { get; set; }

        public int DishID { get; set; }

        public float DishWeight { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public virtual Dish Dish { get; set; }

        public virtual Person Person { get; set; }
    }
}
