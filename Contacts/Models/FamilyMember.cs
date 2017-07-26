using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contacts.Models
{
    public class FamilyMember
    {
        public int Id { get; set; }

        public int ForId { get; set; }

        public int ContactId { get; set; }

        public int StatusModelId { get; set; }

        public string Info { get; set; }
        
        public virtual ContactModel Contact { get; set; }

        public virtual ContactModel For { get; set; }

        public virtual StatusModel Status { get; set; }
    }
}