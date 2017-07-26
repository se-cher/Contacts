using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Controllers
{
    public class ContactController : Controller
    {
        ContactContext db = new ContactContext();

        public ActionResult Index()
        {
            return View(db.ContactModels);
        }


        public ActionResult Birthday()
        {
            var today = DateTime.Now;

            var filter =
                from bird in db.ContactModels
                where bird.DateOfBirth.Day == today.Day && bird.DateOfBirth.Month == today.Month
                select bird;

            return View(filter);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = new ContactEditModel();
            model.ContactModel = db.ContactModels.FirstOrDefault(s => s.Id == id);
            model.JobModels = model.ContactModel.JobModels.ToArray();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ContactEditModel model)
        {
            var edit = db.ContactModels.FirstOrDefault(s => s.Id == model.ContactModel.Id);

            if (edit != null)
            {
                edit.FirstName = model.ContactModel.FirstName;
                edit.LastName = model.ContactModel.LastName;
                edit.DateOfBirth = model.ContactModel.DateOfBirth;
                edit.NameImage = model.ContactModel.NameImage;
                UpdateJobs(model.JobModels);
                UpdateAddress(model.AddressModels);
                UpdateFamily(model.FamilyMembers);
                UpdateFriend(model.FriendConnections);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        private void UpdateJobs(IEnumerable<JobModel> jobModels)
        {
            foreach (var job in jobModels)
            {
                var jobToUpdate = db.JobModels.Find(job.Id);
                if (jobToUpdate == null) continue;
                jobToUpdate.JobName = job.JobName;
                jobToUpdate.Address = job.Address;
                jobToUpdate.Position = job.Position;
            }
        }

        private void UpdateAddress(IEnumerable<AddressModel> addressModels)
        {
            foreach (var address in addressModels)
            {
                var addressToUpdate = db.AddressModels.Find(address.Id);
                if (addressToUpdate == null) continue;
                addressToUpdate.Country = address.Country;
                addressToUpdate.City = address.City;
                addressToUpdate.Street = address.Street;
                addressToUpdate.House = address.House;
                addressToUpdate.Apartment = address.Apartment;
                addressToUpdate.Phone = address.Phone;
            }
        }

        private void UpdateFamily(IEnumerable<FamilyMember> familyModels)
        {
            foreach (var family in familyModels)
            {
                var familyToUpdate = db.FamilyMembers.Find(family.Id);
                if (familyToUpdate == null) continue;
                familyToUpdate.ForId = family.ForId;
                familyToUpdate.ContactId = family.ContactId;
                familyToUpdate.StatusModelId = family.StatusModelId;
                familyToUpdate.Info = family.Info;
            }
        }

        private void UpdateFriend(IEnumerable<FriendConnection> friendModels)
        {
            foreach (var friend in friendModels)
            {
                var friendToUpdate = db.FriendConnections.Find(friend.Id);
                if (friendToUpdate == null) continue;
                friendToUpdate.ForId = friend.ForId;
                friendToUpdate.FriendId = friend.FriendId;
                friendToUpdate.Info = friend.Info;
            }
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var del = db.ContactModels.FirstOrDefault(s => s.Id == id);
            return View(del);
        }

        [HttpPost]
        public ActionResult Delete(ContactModel model, int id)
        {
            var del = db.ContactModels.FirstOrDefault(s => s.Id == id);
            if (del != null)
            {
                DeleteRelatedEntities(del);
                db.ContactModels.Remove(del);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        private void DeleteRelatedEntities(ContactModel del)
        {
            DeleteFriends(del.Id);
            DeleteFamilyMembers(del.Id);
            DeleteJob(del.JobModels);
            DeleteAddress(del.AddressModels);
        }

        private void DeleteAddress(IEnumerable<AddressModel> address)
        {
            if (address.Any())
            {
                db.AddressModels.RemoveRange(address);
            }
        }

        private void DeleteJob(IEnumerable<JobModel> jobs)
        {
           if(jobs.Any())
            {
                db.JobModels.RemoveRange(jobs);              
            }            
        }

        private void DeleteFamilyMembers(int id)
        {
            var family = db.FamilyMembers.Where(f => f.ForId == id || f.ContactId == id).ToList();
            db.FamilyMembers.RemoveRange(family);
            db.SaveChanges();
        }

        private void DeleteFriends(int id)
        {
            var friends = db.FriendConnections.Where(f => f.ForId == id || f.FriendId == id).ToList();
            db.FriendConnections.RemoveRange(friends);
            db.SaveChanges();
        }


        public ActionResult Details(int id)
        {
            var details = db.ContactModels.FirstOrDefault(s => s.Id == id);
            return View(details);
        }


        [HttpGet]
        public ActionResult AddContact()
        {
            IEnumerable<SelectListItem> contacts =
            db.ContactModels.Select(f => new SelectListItem() {
                                                 Value = f.Id.ToString(),
                                                 Text = f.FirstName + " " + f.LastName })
                           .ToList();
            ViewBag.Contacts = contacts;
            return View();
        }

        [HttpPost]
        public ActionResult AddContact(AddContactModel model)
        {
            if (ModelState.IsValid)//проверяет валидность введенных пользователем данных
            {
                string fileName = SaveImage(model.ImageFile);
                var address = new AddressModel
                {
                    Country = model.Country,
                    City = model.City,
                    Street = model.Street,
                    House = model.House,
                    Apartment = model.Apartment,
                    Phone = model.Phone
                };

                var job = new JobModel
                {
                    JobName = model.JobName,
                    Address = model.Address,
                    Position = model.Position
                };

                var newCont = new ContactModel()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    NameImage = fileName,
                    AddressModels = new List<AddressModel>() { address },
                    JobModels = new List<JobModel>() { job }
                };

                db.ContactModels.Add(newCont); //добавление 
                db.SaveChanges();//сохранение 

                AddFamilyMembers(model.FamilyContactId, newCont);
                AddFriendConnection(model.FriendId,newCont);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Contacts = db.ContactModels
                                 .Select(f => new SelectListItem()
                                         {
                                             Value = f.Id.ToString(),
                                             Text = f.FirstName + " " + f.LastName
                                         })
                                .ToList();
            return View(model);
        }

        private void AddFamilyMembers(int familyMemberId, ContactModel newCont)
        {
            var family = db.ContactModels.Find(familyMemberId);

            if (family != null)
            {
                db.FamilyMembers.Add(new FamilyMember()
                {
                    ForId = newCont.Id,
                    ContactId = family.Id,
                    Info = "Hello",
                    StatusModelId = 1,
                });
            }
        }

        private void AddFriendConnection(int friendId, ContactModel newCont)
        {
            var friend = db.ContactModels.Find(friendId);

            if (friend != null)
            {
                db.FriendConnections.Add(new FriendConnection()
                {
                    ForId = newCont.Id,
                    FriendId = friend.Id,
                    Info = "Hello"
                });
            }
        }

        private string SaveImage(HttpPostedFileBase imageFile)
        {
            if (imageFile == null)
            {
                return null;
            }
            Tuple<string, string> fileNames = GetFileName(imageFile);
            imageFile.SaveAs(fileNames.Item1);
            return fileNames.Item2;
        }

        private Tuple<string, string> GetFileName(HttpPostedFileBase imageFile)
        {
            string[] splittedName = imageFile.FileName.Split('.');
            string ext = null;
            if (splittedName.Length > 1)
            {
                ext = $".{splittedName[splittedName.Length - 1]}";
            }
            string imagePath = HttpContext.Server.MapPath("~/Content/Images");
            string fileName = $"{Guid.NewGuid().ToString()}{ext}";
            return new Tuple<string, string>($"{imagePath}\\{fileName}", fileName);
        }


        public ActionResult Address(int id)
        {
            var person = db.ContactModels.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            var model = new AddressesDetailsModel
            {
                Addresses = person.AddressModels.ToList(),
                FirstName = person.FirstName,
                LastName = person.LastName
            };
            return View(model);
        }


        public ActionResult Job(int id)
        {
            var person = db.ContactModels.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            var model = new JobDetailsModel
            {
                Jobs = person.JobModels.ToList(),
                FirstName = person.FirstName,
                LastName = person.LastName
            };
            return View(model);
        }


        public ActionResult Family(int id)
        {
            var person = db.ContactModels.FirstOrDefault(c=>c.Id==id);
            if (person == null)
            {
                return HttpNotFound();
            }
            var fm = db.FamilyMembers
                       .Where(f => f.ForId == id)
                       .Select(f => new FamilyMemberModel()
                {
                    FirstName = f.Contact.FirstName,
                    LastName = f.Contact.LastName,
                    Info = f.Info
                }).ToList();

            var model = new FamilyDetailsModel
            {
                Familys = fm,
                FirstNameFamily = person.FirstName,
                LastNameFamily = person.LastName
            };
            return View(model);
        }


        public ActionResult Friends(int id)
        {
            var person = db.ContactModels.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            var friends = db.FriendConnections.Where(f => f.ForId == id)
                .Select(f => new FriendsViewModel()
                {
                    FirstName = f.Friend.FirstName,
                    LastName = f.Friend.LastName,
                    Info = f.Info
                }).ToList();
            var model = new FriendsDetailsModel
            {
                Friends = friends,
                FirstName = person.FirstName,
                LastName = person.LastName
            };
            return View(model);
        }


        [HttpPost]
        public ActionResult FilterFirstName(FilterModelContact model) //создание фильтра
        {
            if (string.IsNullOrEmpty(model.FilterParam)) //проверяет заполнение поля
            {
                return RedirectToAction("Index", "Contact");
            }
            IEnumerable<ContactModel> filter = db.ContactModels
                                                    .Where(a => a.FirstName
                                                    .Contains(model.FilterParam))
                                                    .ToArray();
            return View("~/Views/Contact/Index.cshtml", filter);
        }


        [HttpPost]
        public ActionResult FilterLastName(FilterModelContact model) //создание фильтра
        {
            if (string.IsNullOrEmpty(model.FilterParamLastName)) //проверяет заполнение поля
            {
                return RedirectToAction("Index", "Contact");
            }
            IEnumerable<ContactModel> filter = db.ContactModels
                                                    .Where(a => a.LastName
                                                    .Contains(model.FilterParamLastName))
                                                    .ToArray();
            return View("~/Views/Contact/Index.cshtml", filter);
        }





        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}