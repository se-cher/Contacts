using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.Models
{
    public class FamilyDetailsModel
    {
        public string FirstNameFamily { get; set; }
        public string LastNameFamily { get; set; }
        public IEnumerable<FamilyMemberModel> Familys { get; set; }
    }

    //public class FamilyMemberModel
    //{
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string Info     { get; set; }
    //}
}