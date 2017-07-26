using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contacts.Models
{
    public class HolidayModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime DateHoliday { get; set; }
    }
}