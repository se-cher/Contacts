namespace Contacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFamilyMembersUpdated2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FamilyMembers", "ContactForId", c => c.Int(nullable: false));
            CreateIndex("dbo.FamilyMembers", "ContactForId");
            AddForeignKey("dbo.FamilyMembers", "ContactForId", "dbo.ContactModels", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FamilyMembers", "ContactForId", "dbo.ContactModels");
            DropIndex("dbo.FamilyMembers", new[] { "ContactForId" });
            DropColumn("dbo.FamilyMembers", "ContactForId");
        }
    }
}
