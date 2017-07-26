using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contacts.Controllers
{
    public class HolidayController : Controller
    {
        ContactContext db = new ContactContext();

        public ActionResult Index()
        {
            return View(db.HolidayModels);
        }


        public ActionResult Holiday()
        {
            var today = DateTime.Now;

            var filter =
                from holi in db.HolidayModels
                where holi.DateHoliday.Day == today.Day && holi.DateHoliday.Month == today.Month
                select holi;

            return View(filter);
        }




        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}