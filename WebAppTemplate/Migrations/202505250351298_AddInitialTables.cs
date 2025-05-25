namespace WebAppTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInitialTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Guid(nullable: false),
                        PetID = c.Guid(nullable: false),
                        Status = c.String(maxLength: 50, unicode: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Pets", t => t.PetID, cascadeDelete: true)
                .Index(t => t.PetID);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        PetID = c.Guid(nullable: false),
                        Name = c.String(maxLength: 50, unicode: false),
                        Species = c.String(maxLength: 30, unicode: false),
                        Breed = c.String(maxLength: 30, unicode: false),
                        Sex = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        Color = c.String(maxLength: 30, unicode: false),
                        IsNeuteredOrSpayed = c.Boolean(nullable: false),
                        Allergies = c.String(maxLength: 500, unicode: false),
                        MedicalNotes = c.String(unicode: false, storeType: "text"),
                        SpecialNeeds = c.String(maxLength: 500, unicode: false),
                        EmergencyContactID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PetID)
                .ForeignKey("dbo.EmergencyContacts", t => t.EmergencyContactID, cascadeDelete: true)
                .Index(t => t.EmergencyContactID);
            
            CreateTable(
                "dbo.EmergencyContacts",
                c => new
                    {
                        EmergencyContactID = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 50, unicode: false),
                        LastName = c.String(maxLength: 50, unicode: false),
                        Relationship = c.String(maxLength: 20, unicode: false),
                        Phone = c.String(maxLength: 20, unicode: false),
                        Email = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.EmergencyContactID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 50, unicode: false),
                        LastName = c.String(maxLength: 50, unicode: false),
                        Phone = c.String(maxLength: 20, unicode: false),
                        Email = c.String(maxLength: 50, unicode: false),
                        Address1 = c.String(maxLength: 50, unicode: false),
                        Address2 = c.String(maxLength: 15, unicode: false),
                        City = c.String(maxLength: 50, unicode: false),
                        State = c.String(maxLength: 2, fixedLength: true, unicode: false),
                        Zip = c.String(maxLength: 5, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.InvoiceItems",
                c => new
                    {
                        InvoiceItemID = c.Guid(nullable: false),
                        BookingID = c.Guid(nullable: false),
                        InvoiceID = c.Guid(nullable: false),
                        Description = c.String(maxLength: 200, unicode: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.InvoiceItemID)
                .ForeignKey("dbo.Bookings", t => t.BookingID, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.InvoiceID, cascadeDelete: true)
                .Index(t => t.BookingID, unique: true)
                .Index(t => t.InvoiceID, unique: true);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Guid(nullable: false),
                        OwnerID = c.Guid(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.InvoiceID)
                .ForeignKey("dbo.Owners", t => t.OwnerID)
                .Index(t => t.OwnerID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.Guid(nullable: false),
                        InvoiceID = c.Guid(nullable: false),
                        ProcessedByEmployeeID = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentMethod = c.String(maxLength: 25, unicode: false),
                        TransactionID = c.String(maxLength: 100, unicode: false),
                        Status = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.Invoices", t => t.InvoiceID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.ProcessedByEmployeeID)
                .Index(t => t.InvoiceID)
                .Index(t => t.ProcessedByEmployeeID);
            
            CreateTable(
                "dbo.PetOwnerships",
                c => new
                    {
                        PetOwnershipID = c.Guid(nullable: false),
                        UserID = c.Guid(nullable: false),
                        PetID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PetOwnershipID)
                .ForeignKey("dbo.Pets", t => t.PetID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.PetID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        UserID = c.Guid(nullable: false),
                        Position = c.String(maxLength: 20, unicode: false),
                        Wage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        UserID = c.Guid(nullable: false),
                        Registered = c.Boolean(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                        PreferredContactMethod = c.String(maxLength: 20, unicode: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Owners", "UserID", "dbo.Users");
            DropForeignKey("dbo.Employees", "UserID", "dbo.Users");
            DropForeignKey("dbo.PetOwnerships", "UserID", "dbo.Users");
            DropForeignKey("dbo.PetOwnerships", "PetID", "dbo.Pets");
            DropForeignKey("dbo.Payments", "ProcessedByEmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Payments", "InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "OwnerID", "dbo.Owners");
            DropForeignKey("dbo.InvoiceItems", "InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.InvoiceItems", "BookingID", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "PetID", "dbo.Pets");
            DropForeignKey("dbo.Pets", "EmergencyContactID", "dbo.EmergencyContacts");
            DropIndex("dbo.Owners", new[] { "UserID" });
            DropIndex("dbo.Employees", new[] { "UserID" });
            DropIndex("dbo.PetOwnerships", new[] { "PetID" });
            DropIndex("dbo.PetOwnerships", new[] { "UserID" });
            DropIndex("dbo.Payments", new[] { "ProcessedByEmployeeID" });
            DropIndex("dbo.Payments", new[] { "InvoiceID" });
            DropIndex("dbo.Invoices", new[] { "OwnerID" });
            DropIndex("dbo.InvoiceItems", new[] { "InvoiceID" });
            DropIndex("dbo.InvoiceItems", new[] { "BookingID" });
            DropIndex("dbo.Pets", new[] { "EmergencyContactID" });
            DropIndex("dbo.Bookings", new[] { "PetID" });
            DropTable("dbo.Owners");
            DropTable("dbo.Employees");
            DropTable("dbo.PetOwnerships");
            DropTable("dbo.Payments");
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceItems");
            DropTable("dbo.Users");
            DropTable("dbo.EmergencyContacts");
            DropTable("dbo.Pets");
            DropTable("dbo.Bookings");
        }
    }
}
