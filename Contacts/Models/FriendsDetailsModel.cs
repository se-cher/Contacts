using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.Models
{
    public class FriendsDetailsModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public IEnumerable<FriendsViewModel> Friends { get; set; }
    }
}