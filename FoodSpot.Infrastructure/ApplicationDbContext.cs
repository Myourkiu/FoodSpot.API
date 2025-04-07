using FoodSpot.Domain.Models.Addresses;
using FoodSpot.Domain.Models.Restaurants;
using FoodSpot.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //delete cascade address - user
            modelBuilder.Entity<Address>()
            .HasOne(a => a.User)
            .WithMany()
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            //delete cascade address - state
            modelBuilder.Entity<Address>()
            .HasOne(a => a.State)
            .WithMany()
            .HasForeignKey(a => a.StateId)
            .OnDelete(DeleteBehavior.Cascade);

            //delete cascade address - city
            modelBuilder.Entity<Address>()
            .HasOne(a => a.City)
            .WithMany()
            .HasForeignKey(a => a.CityId)
            .OnDelete(DeleteBehavior.Cascade);

            //delete cascade restaurant - user
            modelBuilder.Entity<Restaurant>()
            .HasOne(a => a.User)
            .WithMany()
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            //delete cascade menuItem - restaurant
            modelBuilder.Entity<MenuItem>()
            .HasOne(a => a.Restaurant)
            .WithMany(r => r.MenuItems) 
            .HasForeignKey(a => a.RestaurantId)
            .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }
    }
}
