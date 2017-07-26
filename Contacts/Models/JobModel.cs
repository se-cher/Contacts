using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.Models
{
    public class JobModel
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }

        public virtual ICollection<ContactModel> ContactModels { get; set; }
    }
}