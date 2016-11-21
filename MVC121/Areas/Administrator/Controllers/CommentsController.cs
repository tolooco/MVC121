using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC121.Areas.Administrator.Models;
using MVC121.Models.Utility;
using MVC121.Models;

namespace MVC121.Areas.Administrator.Controllers
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Post);
            return View(comments.ToList());
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int? id)
        {
            Comment comment = db.Comments.Find(id);

            comment.PublishTime = comment.PublishTime.Value.ToPersian();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.PostID = new SelectList(db.Posts, "ID", "Name");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,URL,Comments,PublishTime,IsCheked,PostID")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.PublishTime = comment.PublishTime.Value.ToMiladi();
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostID = new SelectList(db.Posts, "ID", "Name", comment.PostID);
            return View(comment);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            comment.PublishTime = comment.PublishTime.Value.ToPersian();

            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostID = new SelectList(db.Posts, "ID", "Name", comment.PostID);
            return View(comment);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,URL,Comments,PublishTime,IsCheked,PostID")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.PublishTime = comment.PublishTime.Value.ToMiladi();

                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostID = new SelectList(db.Posts, "ID", "Name", comment.PostID);
            return View(comment);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            comment.PublishTime = comment.PublishTime.Value.ToPersian();

            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
