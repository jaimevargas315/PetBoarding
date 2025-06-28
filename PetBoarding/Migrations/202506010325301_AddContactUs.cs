namespace PetBoarding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactUs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactUsSubmissions",
                c => new
                    {
                        ContactUsSubmissionId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ContactUsSubmissionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactUsSubmissions");
        }
    }
}
