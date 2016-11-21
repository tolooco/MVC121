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
    public class NewsLettersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administrator/NewsLetters
        public ActionResult Index()
        {
            var newsLetters = db.NewsLetters.Include(n => n.NewsLetterCategory);
            return View(newsLetters.ToList());
        }

        // GET: Administrator/NewsLetters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsLetter newsLetter = db.NewsLetters.Find(id);
            if (newsLetter == null)
            {
                return HttpNotFound();
            }
            return View(newsLetter);
        }

        // GET: Administrator/NewsLetters/Create
        public ActionResult Create()
        {
            ViewBag.NewsLetterCategoryID = new SelectList(db.NewsLetterCategories, "ID", "Name");
            return View();
        }

        // POST: Administrator/NewsLetters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NewsLetterCategoryID,Name,Writer,FullBody,PublishTime")] NewsLetter newsLetter)
        {
            if (ModelState.IsValid)
            {
                db.NewsLetters.Add(newsLetter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NewsLetterCategoryID = new SelectList(db.NewsLetterCategories, "ID", "Name", newsLetter.NewsLetterCategoryID);
            return View(newsLetter);
        }

        // GET: Administrator/NewsLetters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsLetter newsLetter = db.NewsLetters.Find(id);
            if (newsLetter == null)
            {
                return HttpNotFound();
            }
            ViewBag.NewsLetterCategoryID = new SelectList(db.NewsLetterCategories, "ID", "Name", newsLetter.NewsLetterCategoryID);
            return View(newsLetter);
        }

        // POST: Administrator/NewsLetters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NewsLetterCategoryID,Name,Writer,FullBody,PublishTime")] NewsLetter newsLetter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsLetter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NewsLetterCategoryID = new SelectList(db.NewsLetterCategories, "ID", "Name", newsLetter.NewsLetterCategoryID);
            return View(newsLetter);
        }

        // GET: Administrator/NewsLetters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsLetter newsLetter = db.NewsLetters.Find(id);
            if (newsLetter == null)
            {
                return HttpNotFound();
            }
            return View(newsLetter);
        }

        // POST: Administrator/NewsLetters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsLetter newsLetter = db.NewsLetters.Find(id);
            db.NewsLetters.Remove(newsLetter);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Send(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsLetter newsLetter = db.NewsLetters.Find(id);

            if (newsLetter == null)
            {
                return HttpNotFound();
            }

            MVC121.Areas.Administrator.ViewModels.NewsViewModels oNews =
                new ViewModels.NewsViewModels();

            var varUsers =
            db.Users
           .OrderByDescending(current => current.Id)
           .ToList();

            oNews.Users = varUsers;
            oNews.NewsLetter = newsLetter;
            oNews.NewsLetter.ISSend = true;
            db.Entry(newsLetter).State = EntityState.Modified;
            db.SaveChanges();
            ViewBag.NewsLetterCategoryID = new SelectList(db.NewsLetterCategories, "ID", "Name", newsLetter.NewsLetterCategoryID);
            return View(oNews);
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
