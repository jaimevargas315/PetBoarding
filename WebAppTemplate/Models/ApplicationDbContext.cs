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
        
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<EmergencyContacts> EmergencyContacts { get; set; }
        public DbSet<InvoiceItems> InvoiceItems { get; set; }
        public DbSet<Invoices> Invoices { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<PetOwnership> PetOwnerships { get; set; }
        public DbSet<Pets> Pets { get; set; }
        public DbSet<Profiles> Profiles { get; set; }
        public DbSet<ContactUsSubmissions> contactUsSubmissions { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false) { }       

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}