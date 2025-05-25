using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAppTemplate.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Bookings>  Bookings { get; set; }
        public DbSet<EmergencyContacts> EmergencyContacts { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<InvoiceItems> InvoiceItems { get; set; }
        public DbSet<Invoices> Invoices { get; set; }
        public DbSet<Owners> Owners { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<PetOwnership>  PetOwnership { get; set; }
        public DbSet<Pets> Pets { get; set; }
        public DbSet<User> User { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Owners>().ToTable("Owners");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Employees>().ToTable("Employees");
        }
        

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}