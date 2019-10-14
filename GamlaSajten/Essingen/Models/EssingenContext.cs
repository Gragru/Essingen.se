using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Essingen.Models
{
    public class EssingenContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public EssingenContext() : base("name=Model1")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Place>()
            .Property(p => p.Latitude)
            .HasPrecision(15, 6);

            modelBuilder.Entity<Place>()
            .Property(p => p.Longitude)
            .HasPrecision(15, 6);
        }


        public System.Data.Entity.DbSet<Essingen.Models.Place> Places { get; set; }

        public System.Data.Entity.DbSet<Essingen.Models.PlaceCategory> PlaceCategories { get; set; }
    }
}
