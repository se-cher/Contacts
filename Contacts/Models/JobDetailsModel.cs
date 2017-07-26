using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.Models
{
    public class JobDetailsModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<JobModel> Jobs { get; set; }
        
    }
}