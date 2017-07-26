using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.Models
{
    public class ContactEditModel
    {
        public ContactModel ContactModel { get; set; }
        public JobModel[] JobModels { get; set; }
        public AddressModel[] AddressModels { get; set; }
        public FamilyMember[] FamilyMembers { get; set; }
        public FriendConnection[] FriendConnections { get; set; }
    }
}