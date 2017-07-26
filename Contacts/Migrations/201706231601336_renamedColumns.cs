namespace Contacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamedColumns : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.FamilyMembers", name: "ContactForId", newName: "ForId");
            RenameIndex(table: "dbo.FamilyMembers", name: "IX_ContactForId", newName: "IX_ForId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.FamilyMembers", name: "IX_ForId", newName: "IX_ContactForId");
            RenameColumn(table: "dbo.FamilyMembers", name: "ForId", newName: "ContactForId");
        }
    }
}
