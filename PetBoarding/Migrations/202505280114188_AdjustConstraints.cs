namespace PetBoarding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustConstraints : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Bookings", "Status", c => c.String(maxLength: 50));
            AlterColumn("dbo.InvoiceItems", "Description", c => c.String(maxLength: 200));
            AlterColumn("dbo.Profiles", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Profiles", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Profiles", "Phone", c => c.String(maxLength: 20));
            AlterColumn("dbo.Profiles", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Profiles", "Address1", c => c.String(maxLength: 50));
            AlterColumn("dbo.Profiles", "Address2", c => c.String(maxLength: 15));
            AlterColumn("dbo.Profiles", "City", c => c.String(maxLength: 50));
            AlterColumn("dbo.Profiles", "State", c => c.String(maxLength: 2));
            AlterColumn("dbo.Profiles", "Zip", c => c.String(maxLength: 5));
            AlterColumn("dbo.Profiles", "PreferredContactMethod", c => c.String(maxLength: 20));
            AlterColumn("dbo.Profiles", "Position", c => c.String(maxLength: 20));
            AlterColumn("dbo.Pets", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Pets", "Species", c => c.String(maxLength: 30));
            AlterColumn("dbo.Pets", "Breed", c => c.String(maxLength: 30));
            AlterColumn("dbo.Pets", "Sex", c => c.String(maxLength: 1));
            AlterColumn("dbo.Pets", "Color", c => c.String(maxLength: 30));
            AlterColumn("dbo.Pets", "Allergies", c => c.String(maxLength: 500));
            AlterColumn("dbo.Pets", "MedicalNotes", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Pets", "SpecialNeeds", c => c.String(maxLength: 500));
            AlterColumn("dbo.EmergencyContacts", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.EmergencyContacts", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.EmergencyContacts", "Relationship", c => c.String(maxLength: 20));
            AlterColumn("dbo.EmergencyContacts", "Phone", c => c.String(maxLength: 20));
            AlterColumn("dbo.EmergencyContacts", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Payments", "PaymentMethod", c => c.String(maxLength: 25));
            AlterColumn("dbo.Payments", "TransactionID", c => c.String(maxLength: 100));
            AlterColumn("dbo.Payments", "Status", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "Status", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Payments", "TransactionID", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Payments", "PaymentMethod", c => c.String(maxLength: 25, unicode: false));
            AlterColumn("dbo.EmergencyContacts", "Email", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.EmergencyContacts", "Phone", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.EmergencyContacts", "Relationship", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.EmergencyContacts", "LastName", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.EmergencyContacts", "FirstName", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Pets", "SpecialNeeds", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.Pets", "MedicalNotes", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.Pets", "Allergies", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.Pets", "Color", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.Pets", "Sex", c => c.String(maxLength: 1, fixedLength: true, unicode: false));
            AlterColumn("dbo.Pets", "Breed", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.Pets", "Species", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.Pets", "Name", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Profiles", "Position", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.Profiles", "PreferredContactMethod", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.Profiles", "Zip", c => c.String(maxLength: 5, fixedLength: true, unicode: false));
            AlterColumn("dbo.Profiles", "State", c => c.String(maxLength: 2, fixedLength: true, unicode: false));
            AlterColumn("dbo.Profiles", "City", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Profiles", "Address2", c => c.String(maxLength: 15, unicode: false));
            AlterColumn("dbo.Profiles", "Address1", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Profiles", "Email", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Profiles", "Phone", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.Profiles", "LastName", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Profiles", "FirstName", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.InvoiceItems", "Description", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Bookings", "Status", c => c.String(maxLength: 50, unicode: false));
            DropColumn("dbo.Pets", "DateOfBirth");
        }
    }
}
