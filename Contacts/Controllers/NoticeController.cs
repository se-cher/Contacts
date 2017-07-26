using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contacts.Controllers
{
    public class NoticeController : Controller
    {
        ContactContext db = new ContactContext();

        public ActionResult Index()
        {
            return View(db.NoticeModels);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AddNoticeModel model)
        {
            if (ModelState.IsValid)
            {
                var addNotice = new NoticeModel()
                {
                    Text = model.Text,
                };
                DateTime parsedData = GetDateTimeFromText(model);
                addNotice.DateNotice = parsedData;

                db.NoticeModels.Add(addNotice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        private DateTime GetDateTimeFromText(AddNoticeModel model)
        {
            DateTime parsedDate;
            string fullString = $"{model.Date} {model.Time}";
            string pattern = "dd/MM/yyyy HH:mm";
            DateTime.TryParseExact(fullString, pattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
            return parsedDate;
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var edit = db.NoticeModels.FirstOrDefault(s => s.Id == id);
            return View(edit);
        }

        [HttpPost]
        public ActionResult Edit(NoticeModel model)
        {
            var notice = db.NoticeModels.FirstOrDefault(s => s.Id == model.Id);
            if (notice != null)
            {
                notice.Text = model.Text;
                notice.DateNotice = model.DateNotice;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var del = db.NoticeModels.FirstOrDefault(s => s.Id == id);
            return View(del);
        }

        [HttpPost]
        public ActionResult Delete(NoticeModel model)
        {
            var del = db.NoticeModels.FirstOrDefault(s => s.Id == model.Id);
            db.NoticeModels.Remove(del);
            db.SaveChanges();

            return RedirectToAction("Index");
        }




        //public ActionResult PostDate(NoticePostModel model)
        //{
        //    if (ModelState.IsValid == false)
        //    {
        //        return View(model);
        //    }
        //    var notice = new NoticeModel();
           
            
        //    return View();
        //}


        public ActionResult Notice()
        {
            var today = DateTime.Now;

            var filter =
                from noti in db.NoticeModels
                where noti.DateNotice.Day == today.Day && noti.DateNotice.Month == today.Month &&
                      noti.DateNotice.Hour == today.Hour && noti.DateNotice.Minute == today.Minute
                select noti;

            return View(filter);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}