namespace PetBoarding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Guid(nullable: false),
                        Status = c.String(maxLength: 50, unicode: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        Pet_PetID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Pets", t => t.Pet_PetID, cascadeDelete: true)
                .Index(t => t.Pet_PetID);
            
            CreateTable(
                "dbo.InvoiceItems",
                c => new
                    {
                        InvoiceItemID = c.Guid(nullable: false),
                        Description = c.String(maxLength: 200, unicode: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Invoice_InvoiceID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceItemID)
                .ForeignKey("dbo.Bookings", t => t.InvoiceItemID)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceID, cascadeDelete: true)
                .Index(t => t.InvoiceItemID)
                .Index(t => t.Invoice_InvoiceID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Guid(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Owner_ProfileID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceID)
                .ForeignKey("dbo.Profiles", t => t.Owner_ProfileID, cascadeDelete: true)
                .Index(t => t.Owner_ProfileID);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ProfileID = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 50, unicode: false),
                        LastName = c.String(maxLength: 50, unicode: false),
                        Phone = c.String(maxLength: 20, unicode: false),
                        Email = c.String(maxLength: 50, unicode: false),
                        Address1 = c.String(maxLength: 50, unicode: false),
                        Address2 = c.String(maxLength: 15, unicode: false),
                        City = c.String(maxLength: 50, unicode: false),
                        State = c.String(maxLength: 2, fixedLength: true, unicode: false),
                        Zip = c.String(maxLength: 5, fixedLength: true, unicode: false),
                        Registered = c.Boolean(),
                        RegistrationDate = c.DateTime(),
                        PreferredContactMethod = c.String(maxLength: 20, unicode: false),
                        CreatedDate = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        Position = c.String(maxLength: 20, unicode: false),
                        Wage = c.Decimal(precision: 18, scale: 2),
                        Active = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ProfileID);
            
            CreateTable(
                "dbo.PetOwnerships",
                c => new
                    {
                        PetOwnershipID = c.Guid(nullable: false),
                        Owner_ProfileID = c.Guid(nullable: false),
                        Pet_PetID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PetOwnershipID)
                .ForeignKey("dbo.Profiles", t => t.Owner_ProfileID, cascadeDelete: true)
                .ForeignKey("dbo.Pets", t => t.Pet_PetID, cascadeDelete: true)
                .Index(t => t.Owner_ProfileID)
                .Index(t => t.Pet_PetID);
            
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
                    })
                .PrimaryKey(t => t.PetID);
            
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
                        Employee_ProfileID = c.Guid(),
                        Pet_PetID = c.Guid(),
                    })
                .PrimaryKey(t => t.EmergencyContactID)
                .ForeignKey("dbo.Profiles", t => t.Employee_ProfileID)
                .ForeignKey("dbo.Pets", t => t.Pet_PetID)
                .Index(t => t.Employee_ProfileID)
                .Index(t => t.Pet_PetID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentMethod = c.String(maxLength: 25, unicode: false),
                        TransactionID = c.String(maxLength: 100, unicode: false),
                        Status = c.String(maxLength: 50, unicode: false),
                        Invoice_InvoiceID = c.Guid(nullable: false),
                        ProcessedByEmployee_ProfileID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceID, cascadeDelete: true)
                .ForeignKey("dbo.Profiles", t => t.ProcessedByEmployee_ProfileID, cascadeDelete: false)
                .Index(t => t.Invoice_InvoiceID)
                .Index(t => t.ProcessedByEmployee_ProfileID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Pet_PetID", "dbo.Pets");
            DropForeignKey("dbo.InvoiceItems", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "Owner_ProfileID", "dbo.Profiles");
            DropForeignKey("dbo.PetOwnerships", "Pet_PetID", "dbo.Pets");
            DropForeignKey("dbo.EmergencyContacts", "Pet_PetID", "dbo.Pets");
            DropForeignKey("dbo.Payments", "ProcessedByEmployee_ProfileID", "dbo.Profiles");
            DropForeignKey("dbo.Payments", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.EmergencyContacts", "Employee_ProfileID", "dbo.Profiles");
            DropForeignKey("dbo.PetOwnerships", "Owner_ProfileID", "dbo.Profiles");
            DropForeignKey("dbo.InvoiceItems", "InvoiceItemID", "dbo.Bookings");
            DropIndex("dbo.Payments", new[] { "ProcessedByEmployee_ProfileID" });
            DropIndex("dbo.Payments", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.EmergencyContacts", new[] { "Pet_PetID" });
            DropIndex("dbo.EmergencyContacts", new[] { "Employee_ProfileID" });
            DropIndex("dbo.PetOwnerships", new[] { "Pet_PetID" });
            DropIndex("dbo.PetOwnerships", new[] { "Owner_ProfileID" });
            DropIndex("dbo.Invoices", new[] { "Owner_ProfileID" });
            DropIndex("dbo.InvoiceItems", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.InvoiceItems", new[] { "InvoiceItemID" });
            DropIndex("dbo.Bookings", new[] { "Pet_PetID" });
            DropTable("dbo.Payments");
            DropTable("dbo.EmergencyContacts");
            DropTable("dbo.Pets");
            DropTable("dbo.PetOwnerships");
            DropTable("dbo.Profiles");
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceItems");
            DropTable("dbo.Bookings");
        }
    }
}
