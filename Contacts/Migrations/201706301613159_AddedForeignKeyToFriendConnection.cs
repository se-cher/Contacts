namespace Contacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForeignKeyToFriendConnection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FriendConnections", "Contact_Id", "dbo.ContactModels");
            DropIndex("dbo.FriendConnections", new[] { "Contact_Id" });
            DropColumn("dbo.FriendConnections", "FriendId");
            RenameColumn(table: "dbo.FriendConnections", name: "Contact_Id", newName: "FriendId");
            AlterColumn("dbo.FriendConnections", "FriendId", c => c.Int(nullable: false));
            CreateIndex("dbo.FriendConnections", "FriendId");
            AddForeignKey("dbo.FriendConnections", "FriendId", "dbo.ContactModels", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FriendConnections", "FriendId", "dbo.ContactModels");
            DropIndex("dbo.FriendConnections", new[] { "FriendId" });
            AlterColumn("dbo.FriendConnections", "FriendId", c => c.Int());
            RenameColumn(table: "dbo.FriendConnections", name: "FriendId", newName: "Contact_Id");
            AddColumn("dbo.FriendConnections", "FriendId", c => c.Int(nullable: false));
            CreateIndex("dbo.FriendConnections", "Contact_Id");
            AddForeignKey("dbo.FriendConnections", "Contact_Id", "dbo.ContactModels", "Id");
        }
    }
}
