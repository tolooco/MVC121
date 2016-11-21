using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC121.Areas.Administrator.Models;
using MVC121.Models;

namespace MVC121.Areas.Administrator.Controllers
{
    public class UserContactsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(db.UserContacts.ToList());
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserContact userContact = db.UserContacts.Find(id);
            if (userContact == null)
            {
                return HttpNotFound();
            }
            return View(userContact);
        }

        // GET: Administrator/UserContacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/UserContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,Subject,Message")] UserContact userContact)
        {
            if (ModelState.IsValid)
            {
                db.UserContacts.Add(userContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userContact);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserContact userContact = db.UserContacts.Find(id);
            if (userContact == null)
            {
                return HttpNotFound();
            }
            return View(userContact);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Subject,Message")] UserContact userContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userContact);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserContact userContact = db.UserContacts.Find(id);
            if (userContact == null)
            {
                return HttpNotFound();
            }
            return View(userContact);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserContact userContact = db.UserContacts.Find(id);
            db.UserContacts.Remove(userContact);
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
