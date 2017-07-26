namespace Contacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedFriends : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FriendsModelContactModels", "FriendsModel_Id", "dbo.FriendsModels");
            DropForeignKey("dbo.FriendsModelContactModels", "ContactModel_Id", "dbo.ContactModels");
            DropIndex("dbo.FriendsModelContactModels", new[] { "FriendsModel_Id" });
            DropIndex("dbo.FriendsModelContactModels", new[] { "ContactModel_Id" });
            CreateTable(
                "dbo.FriendConnections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ForId = c.Int(nullable: false),
                        FriendId = c.Int(nullable: false),
                        Info = c.String(),
                        Contact_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactModels", t => t.Contact_Id)
                .ForeignKey("dbo.ContactModels", t => t.ForId, cascadeDelete: true)
                .Index(t => t.ForId)
                .Index(t => t.Contact_Id);
            
            DropTable("dbo.FriendsModels");
            DropTable("dbo.FriendsModelContactModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FriendsModelContactModels",
                c => new
                    {
                        FriendsModel_Id = c.Int(nullable: false),
                        ContactModel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FriendsModel_Id, t.ContactModel_Id });
            
            CreateTable(
                "dbo.FriendsModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstNameFriend = c.String(),
                        LastNameFriend = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.FriendConnections", "ForId", "dbo.ContactModels");
            DropForeignKey("dbo.FriendConnections", "Contact_Id", "dbo.ContactModels");
            DropIndex("dbo.FriendConnections", new[] { "Contact_Id" });
            DropIndex("dbo.FriendConnections", new[] { "ForId" });
            DropTable("dbo.FriendConnections");
            CreateIndex("dbo.FriendsModelContactModels", "ContactModel_Id");
            CreateIndex("dbo.FriendsModelContactModels", "FriendsModel_Id");
            AddForeignKey("dbo.FriendsModelContactModels", "ContactModel_Id", "dbo.ContactModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FriendsModelContactModels", "FriendsModel_Id", "dbo.FriendsModels", "Id", cascadeDelete: true);
        }
    }
}
