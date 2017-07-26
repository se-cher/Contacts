namespace Contacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedFamilyMembers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FamilyModelContactModels", "FamilyModel_Id", "dbo.FamilyModels");
            DropForeignKey("dbo.FamilyModelContactModels", "ContactModel_Id", "dbo.ContactModels");
            DropIndex("dbo.FamilyModelContactModels", new[] { "FamilyModel_Id" });
            DropIndex("dbo.FamilyModelContactModels", new[] { "ContactModel_Id" });
            DropTable("dbo.FamilyModels");
            DropTable("dbo.FamilyModelContactModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FamilyModelContactModels",
                c => new
                    {
                        FamilyModel_Id = c.Int(nullable: false),
                        ContactModel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FamilyModel_Id, t.ContactModel_Id });
            
            CreateTable(
                "dbo.FamilyModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstNameFamily = c.String(),
                        LastNameFamily = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.FamilyModelContactModels", "ContactModel_Id");
            CreateIndex("dbo.FamilyModelContactModels", "FamilyModel_Id");
            AddForeignKey("dbo.FamilyModelContactModels", "ContactModel_Id", "dbo.ContactModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FamilyModelContactModels", "FamilyModel_Id", "dbo.FamilyModels", "Id", cascadeDelete: true);
        }
    }
}
