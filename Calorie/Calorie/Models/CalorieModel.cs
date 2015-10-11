namespace Calorie.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CalorieModel : DbContext
    {
        public CalorieModel()
            : base("name=CalorieModelContext")
        {
        }

        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<DishesProduct> DishesProducts { get; set; }
        public virtual DbSet<PersonEatStory> PersonEatStories { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>()
                .Property(e => e.DishName)
                .IsUnicode(false);

            modelBuilder.Entity<Dish>()
                .HasMany(e => e.DishesProducts)
                .WithRequired(e => e.Dish)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dish>()
                .HasMany(e => e.PersonEatStories)
                .WithRequired(e => e.Dish)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.PersonName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PersonEatStories)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.DishesProducts)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
        }
    }
}
