using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contacts.Models
{
    public class AddContactModel
    {
        //Общее
        [Required(ErrorMessage = "Введите Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите Фамилию")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введите дату рождения")]
        public DateTime DateOfBirth { get; set; }

        //[Required(ErrorMessage = "Выберите фото")]
        public HttpPostedFileBase ImageFile { get; set; }


        //Адрес
        [Required(ErrorMessage = "Введите Страну")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Введите Город")]
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }
        public string Phone { get; set; }


        //Работа
        [Required(ErrorMessage = "Введите Компанию")]
        public string JobName { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Введите Должность")]
        public string Position { get; set; }


        //Семья
        public int FamilyContactId { get; set; }
        public int FriendId { get; set; }
        //public int StatusModelId { get; set; }


        //Друзья
        //[Required(ErrorMessage = "Введите Имя")]
        //public string FirstNameFriend { get; set; }
        //[Required(ErrorMessage = "Введите Фамилию")]
        //public string LastNameFriend { get; set; }


        //public string Communications { get; set; }
    }
}