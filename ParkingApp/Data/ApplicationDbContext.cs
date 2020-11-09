using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Models;

namespace ParkingApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Id = "1bd87b74-3b02-4126-98e3-b9acb0767fc6",
                Name = "Customer",
                NormalizedName = "CUSTOMER"
            }
            );
            builder.Entity<IdentityRole>()
           .HasData(
           new IdentityRole
           {
               Id = "77e60802-3e18-40cf-8999-79aa642defb1",
               Name = "Contractor",
               NormalizedName = "CONTRACTOR"
           }
           );


        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<StarRating> Ratings { get; set; }

    }
}
