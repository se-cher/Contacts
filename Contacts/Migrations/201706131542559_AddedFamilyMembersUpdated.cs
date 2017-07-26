namespace Contacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFamilyMembersUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FamilyMembers", "ContactModel_Id", "dbo.ContactModels");
            DropIndex("dbo.FamilyMembers", new[] { "ContactModel_Id" });
            DropColumn("dbo.FamilyMembers", "ContactId");
            RenameColumn(table: "dbo.FamilyMembers", name: "ContactModel_Id", newName: "ContactId");
            AlterColumn("dbo.FamilyMembers", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.FamilyMembers", "ContactId");
            AddForeignKey("dbo.FamilyMembers", "ContactId", "dbo.ContactModels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FamilyMembers", "ContactId", "dbo.ContactModels");
            DropIndex("dbo.FamilyMembers", new[] { "ContactId" });
            AlterColumn("dbo.FamilyMembers", "ContactId", c => c.Int());
            RenameColumn(table: "dbo.FamilyMembers", name: "ContactId", newName: "ContactModel_Id");
            AddColumn("dbo.FamilyMembers", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.FamilyMembers", "ContactModel_Id");
            AddForeignKey("dbo.FamilyMembers", "ContactModel_Id", "dbo.ContactModels", "Id");
        }
    }
}
