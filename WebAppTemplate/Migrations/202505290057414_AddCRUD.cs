namespace WebAppTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCRUD : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InvoiceItems", "InvoiceItemID", "dbo.Bookings");
            DropIndex("dbo.InvoiceItems", new[] { "InvoiceItemID" });
            AddColumn("dbo.InvoiceItems", "Booking_BookingID", c => c.Guid(nullable: false));
            AddColumn("dbo.Invoices", "Issuedate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Invoices", "DueDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Profiles", "HireDate", c => c.DateTime());
            AddColumn("dbo.Profiles", "TerminationDate", c => c.DateTime());
            AddColumn("dbo.Payments", "PaymentDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.InvoiceItems", "Booking_BookingID");
            AddForeignKey("dbo.InvoiceItems", "Booking_BookingID", "dbo.Bookings", "BookingID", cascadeDelete: true);
            DropColumn("dbo.Profiles", "Registered");
            DropColumn("dbo.Profiles", "RegistrationDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "RegistrationDate", c => c.DateTime());
            AddColumn("dbo.Profiles", "Registered", c => c.Boolean());
            DropForeignKey("dbo.InvoiceItems", "Booking_BookingID", "dbo.Bookings");
            DropIndex("dbo.InvoiceItems", new[] { "Booking_BookingID" });
            DropColumn("dbo.Payments", "PaymentDate");
            DropColumn("dbo.Profiles", "TerminationDate");
            DropColumn("dbo.Profiles", "HireDate");
            DropColumn("dbo.Invoices", "DueDate");
            DropColumn("dbo.Invoices", "Issuedate");
            DropColumn("dbo.InvoiceItems", "Booking_BookingID");
            CreateIndex("dbo.InvoiceItems", "InvoiceItemID");
            AddForeignKey("dbo.InvoiceItems", "InvoiceItemID", "dbo.Bookings", "BookingID");
        }
    }
}
