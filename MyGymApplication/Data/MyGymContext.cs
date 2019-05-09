using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MyGymApplication.Models;
using MyGymApplication.Models.GymModels;

namespace MyGymApplication.Data
{
    public class MyGymContext : DbContext
    {
        public MyGymContext() : base("DefaultConnection")
        {}

        public DbSet<MembershipPackage> MembershipPackages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<ExerciseClass> ExerciseClasses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<TrackMyWeight> TrackMyWeights { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<EmailForm> EmailFormModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        
        
}
}