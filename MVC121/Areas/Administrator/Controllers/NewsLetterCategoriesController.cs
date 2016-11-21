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
    [Authorize(Roles = "Administrator")]
    public class NewsLetterCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administrator/NewsLetterCategories
        public ActionResult Index()
        {
            return View(db.NewsLetterCategories.ToList());
        }

        // GET: Administrator/NewsLetterCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsLetterCategory newsLetterCategory = db.NewsLetterCategories.Find(id);
            if (newsLetterCategory == null)
            {
                return HttpNotFound();
            }
            return View(newsLetterCategory);
        }

        // GET: Administrator/NewsLetterCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/NewsLetterCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] NewsLetterCategory newsLetterCategory)
        {
            if (ModelState.IsValid)
            {
                db.NewsLetterCategories.Add(newsLetterCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsLetterCategory);
        }

        // GET: Administrator/NewsLetterCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsLetterCategory newsLetterCategory = db.NewsLetterCategories.Find(id);
            if (newsLetterCategory == null)
            {
                return HttpNotFound();
            }
            return View(newsLetterCategory);
        }

        // POST: Administrator/NewsLetterCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] NewsLetterCategory newsLetterCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsLetterCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsLetterCategory);
        }

        // GET: Administrator/NewsLetterCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsLetterCategory newsLetterCategory = db.NewsLetterCategories.Find(id);
            if (newsLetterCategory == null)
            {
                return HttpNotFound();
            }
            return View(newsLetterCategory);
        }

        // POST: Administrator/NewsLetterCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsLetterCategory newsLetterCategory = db.NewsLetterCategories.Find(id);
            db.NewsLetterCategories.Remove(newsLetterCategory);
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
