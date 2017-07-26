using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.Models
{
    public class AddressesDetailsModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<AddressModel> Addresses { get; set; }
    }
}