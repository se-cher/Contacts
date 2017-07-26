namespace Contacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFamilyStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FamilyMembers", "StatusModelId", c => c.Int(nullable: false));
            CreateIndex("dbo.FamilyMembers", "StatusModelId");
            AddForeignKey("dbo.FamilyMembers", "StatusModelId", "dbo.StatusModels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FamilyMembers", "StatusModelId", "dbo.StatusModels");
            DropIndex("dbo.FamilyMembers", new[] { "StatusModelId" });
            DropColumn("dbo.FamilyMembers", "StatusModelId");
        }
    }
}
