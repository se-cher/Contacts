using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contacts.Models
{
    public class NoticeModel
    {
        public int Id { get; set; }
        public string Text { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime DateNotice { get; set; }
    }
}