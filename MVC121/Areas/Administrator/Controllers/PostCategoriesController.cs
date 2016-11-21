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
    [Authorize(Roles = "Administrator")]
    public class PostCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PostCategories
        public ActionResult Index()
        {
            return View(db.PostCategories.ToList());
        }

        // GET: PostCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostCategory postCategory = db.PostCategories.Find(id);
            if (postCategory == null)
            {
                return HttpNotFound();
            }
            return View(postCategory);
        }

        // GET: PostCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Category")] PostCategory postCategory)
        {
            if (ModelState.IsValid)
            {
                db.PostCategories.Add(postCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postCategory);
        }

        // GET: PostCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostCategory postCategory = db.PostCategories.Find(id);
            if (postCategory == null)
            {
                return HttpNotFound();
            }
            return View(postCategory);
        }

        // POST: PostCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Category")] PostCategory postCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postCategory);
        }

        // GET: PostCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostCategory postCategory = db.PostCategories.Find(id);
            if (postCategory == null)
            {
                return HttpNotFound();
            }
            return View(postCategory);
        }

        // POST: PostCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostCategory postCategory = db.PostCategories.Find(id);
            db.PostCategories.Remove(postCategory);
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
