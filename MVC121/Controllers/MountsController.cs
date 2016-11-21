using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC121.Models;
using MVC121.Models.Utility;

namespace MVC121.Controllers
{
    public class MountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Mounts
        public ActionResult Index()
        {
            return View(db.Mounts.ToList());
        }

        // GET: Mounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mount mount = db.Mounts.Find(id);
            if (mount == null)
            {
                return HttpNotFound();
            }
            return View(mount);
        }

        // GET: Mounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Mount mount)
        {
            if (ModelState.IsValid)
            {
                db.Mounts.Add(mount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mount);
        }

        // GET: Mounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mount mount = db.Mounts.Find(id);
            if (mount == null)
            {
                return HttpNotFound();
            }
            return View(mount);
        }

        // POST: Mounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Mount mount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mount);
        }

        // GET: Mounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mount mount = db.Mounts.Find(id);
            if (mount == null)
            {
                return HttpNotFound();
            }
            return View(mount);
        }

        // POST: Mounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mount mount = db.Mounts.Find(id);
            db.Mounts.Remove(mount);
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
