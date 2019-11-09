using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Real_Estate_Listing.Models
{
    public class Real_Estate_ListingContext : DbContext
    {
        public Real_Estate_ListingContext (DbContextOptions<Real_Estate_ListingContext> options)
            : base(options)
        {
        }

        public DbSet<Real_Estate_Listing.Models.Property> Property { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>().HasData(
                new Property
                {
                    Id = 1,
                    Name = "Greenfield apartments",
                    Address = "222 senator"
                });

            modelBuilder.Entity<Property>().HasData(
                new Property
                {
                    Id = 2,
                    Name = "Senator apartments",
                    Address = "222 senator"
                });

            modelBuilder.Entity<Property>().HasData(
                new Property
                {
                    Id = 3,
                    Name = "Jefferson apartments",
                    Address = "222 senator"
                });

            modelBuilder.Entity<Property>().HasData(
                new Property
                {
                    Id = 4,
                    Name = "lowell apartments",
                    Address = "222 senator"
                });

            modelBuilder.Entity<Property>().HasData(
                new Property
                {
                    Id = 5,
                    Name = "Forum apartments",
                    Address = "222 senator"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
