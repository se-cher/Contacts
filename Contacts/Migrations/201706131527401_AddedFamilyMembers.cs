namespace Contacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFamilyMembers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FamilyMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        Info = c.String(),
                        ContactModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactModels", t => t.ContactModel_Id)
                .Index(t => t.ContactModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FamilyMembers", "ContactModel_Id", "dbo.ContactModels");
            DropIndex("dbo.FamilyMembers", new[] { "ContactModel_Id" });
            DropTable("dbo.FamilyMembers");
        }
    }
}
