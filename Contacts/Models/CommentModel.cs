using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contacts.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime DateComment { get; set; }
    }
}