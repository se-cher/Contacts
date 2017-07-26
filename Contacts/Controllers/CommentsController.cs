using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contacts.Controllers
{
    public class CommentsController : Controller
    {
        ContactContext db = new ContactContext();

        public ActionResult Index()
        {
            return View(db.CommentModels);
        }


        [HttpGet]
        public ActionResult AddComment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddComment(AddCommentModel model)
        {
            if (ModelState.IsValid)
            {
                var newComment = new CommentModel()
                {
                    Name = model.Name,
                    Text = model.Text,
                    DateComment = DateTime.Now
                };

                db.CommentModels.Add(newComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}