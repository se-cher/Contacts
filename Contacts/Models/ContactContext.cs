using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Contacts.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext() : base("DefaultConnection")
        { }

        public DbSet<ContactModel> ContactModels { get; set; }
        public DbSet<CommentModel> CommentModels { get; set; }
        public DbSet<HolidayModel> HolidayModels { get; set; }
        public DbSet<NoticeModel> NoticeModels { get; set; }
        public DbSet<JobModel> JobModels { get; set; }
        public DbSet<AddressModel> AddressModels { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<FriendConnection> FriendConnections { get; set; }

        public DbSet<StatusModel> StatusModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}