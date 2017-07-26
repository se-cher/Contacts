using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contacts.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        
        //[Required(ErrorMessage = "Введите Имя")]
        public string FirstName { get; set; }
        
        //[Required(ErrorMessage = "Введите Фамилию")]
        public string LastName { get; set; }
        
        //[Required(ErrorMessage = "Введите дату рождения")]
        public DateTime DateOfBirth { get; set; }

        public string NameImage { get; set; }

        public virtual ICollection<AddressModel> AddressModels { get; set; }

        public virtual ICollection<JobModel> JobModels { get; set; }
    }


    //public class FamilyMember
    //{
    //    public int Id { get; set; }
    //    public int ContactForId { get; set; }
    //    public int ContactId { get; set; }
    //    public string Info { get; set; }
    //    [ForeignKey("ContactId")]
    //    public virtual ContactModel ContactModel { get; set; }

    //    [ForeignKey("ContactForId")]
    //    public virtual ContactModel ContactModelFor { get; set; }
    //}
}