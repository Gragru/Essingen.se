namespace Essingen.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=Model1")
        {
        }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<PlaceCategory> PlaceCategories { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Place>()
            .Property(p => p.Latitude)
            .HasPrecision(15, 6);

            modelBuilder.Entity<Place>()
            .Property(p => p.Longitude)
            .HasPrecision(15, 6);
        }
    }
}
