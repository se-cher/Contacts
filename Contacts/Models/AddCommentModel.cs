using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contacts.Models
{
    public class AddCommentModel
    {
        [Required(ErrorMessage = "Введите Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите отзыв")]
        public string Text { get; set; }
    }
}