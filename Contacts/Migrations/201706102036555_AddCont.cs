namespace Contacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCont : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        House = c.String(),
                        Apartment = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        NameImage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FamilyModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstNameFamily = c.String(),
                        LastNameFamily = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FriendsModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstNameFriend = c.String(),
                        LastNameFriend = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobName = c.String(),
                        Address = c.String(),
                        Position = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CommentModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Text = c.String(),
                        DateComment = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HolidayModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateHoliday = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NoticeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        DateNotice = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactModelAddressModels",
                c => new
                    {
                        ContactModel_Id = c.Int(nullable: false),
                        AddressModel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ContactModel_Id, t.AddressModel_Id })
                .ForeignKey("dbo.ContactModels", t => t.ContactModel_Id, cascadeDelete: true)
                .ForeignKey("dbo.AddressModels", t => t.AddressModel_Id, cascadeDelete: true)
                .Index(t => t.ContactModel_Id)
                .Index(t => t.AddressModel_Id);
            
            CreateTable(
                "dbo.FamilyModelContactModels",
                c => new
                    {
                        FamilyModel_Id = c.Int(nullable: false),
                        ContactModel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FamilyModel_Id, t.ContactModel_Id })
                .ForeignKey("dbo.FamilyModels", t => t.FamilyModel_Id, cascadeDelete: true)
                .ForeignKey("dbo.ContactModels", t => t.ContactModel_Id, cascadeDelete: true)
                .Index(t => t.FamilyModel_Id)
                .Index(t => t.ContactModel_Id);
            
            CreateTable(
                "dbo.FriendsModelContactModels",
                c => new
                    {
                        FriendsModel_Id = c.Int(nullable: false),
                        ContactModel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FriendsModel_Id, t.ContactModel_Id })
                .ForeignKey("dbo.FriendsModels", t => t.FriendsModel_Id, cascadeDelete: true)
                .ForeignKey("dbo.ContactModels", t => t.ContactModel_Id, cascadeDelete: true)
                .Index(t => t.FriendsModel_Id)
                .Index(t => t.ContactModel_Id);
            
            CreateTable(
                "dbo.JobModelContactModels",
                c => new
                    {
                        JobModel_Id = c.Int(nullable: false),
                        ContactModel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JobModel_Id, t.ContactModel_Id })
                .ForeignKey("dbo.JobModels", t => t.JobModel_Id, cascadeDelete: true)
                .ForeignKey("dbo.ContactModels", t => t.ContactModel_Id, cascadeDelete: true)
                .Index(t => t.JobModel_Id)
                .Index(t => t.ContactModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobModelContactModels", "ContactModel_Id", "dbo.ContactModels");
            DropForeignKey("dbo.JobModelContactModels", "JobModel_Id", "dbo.JobModels");
            DropForeignKey("dbo.FriendsModelContactModels", "ContactModel_Id", "dbo.ContactModels");
            DropForeignKey("dbo.FriendsModelContactModels", "FriendsModel_Id", "dbo.FriendsModels");
            DropForeignKey("dbo.FamilyModelContactModels", "ContactModel_Id", "dbo.ContactModels");
            DropForeignKey("dbo.FamilyModelContactModels", "FamilyModel_Id", "dbo.FamilyModels");
            DropForeignKey("dbo.ContactModelAddressModels", "AddressModel_Id", "dbo.AddressModels");
            DropForeignKey("dbo.ContactModelAddressModels", "ContactModel_Id", "dbo.ContactModels");
            DropIndex("dbo.JobModelContactModels", new[] { "ContactModel_Id" });
            DropIndex("dbo.JobModelContactModels", new[] { "JobModel_Id" });
            DropIndex("dbo.FriendsModelContactModels", new[] { "ContactModel_Id" });
            DropIndex("dbo.FriendsModelContactModels", new[] { "FriendsModel_Id" });
            DropIndex("dbo.FamilyModelContactModels", new[] { "ContactModel_Id" });
            DropIndex("dbo.FamilyModelContactModels", new[] { "FamilyModel_Id" });
            DropIndex("dbo.ContactModelAddressModels", new[] { "AddressModel_Id" });
            DropIndex("dbo.ContactModelAddressModels", new[] { "ContactModel_Id" });
            DropTable("dbo.JobModelContactModels");
            DropTable("dbo.FriendsModelContactModels");
            DropTable("dbo.FamilyModelContactModels");
            DropTable("dbo.ContactModelAddressModels");
            DropTable("dbo.NoticeModels");
            DropTable("dbo.HolidayModels");
            DropTable("dbo.CommentModels");
            DropTable("dbo.JobModels");
            DropTable("dbo.FriendsModels");
            DropTable("dbo.FamilyModels");
            DropTable("dbo.ContactModels");
            DropTable("dbo.AddressModels");
        }
    }
}
