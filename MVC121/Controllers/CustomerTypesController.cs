using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC121.Models;

namespace MVC121.Controllers
{
    public class CustomerTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerTypes
        public ActionResult Index()
        {
            return View(db.CustomerTypes.ToList());
        }

        // GET: CustomerTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerType customerType = db.CustomerTypes.Find(id);
            if (customerType == null)
            {
                return HttpNotFound();
            }
            return View(customerType);
        }

        // GET: CustomerTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description")] CustomerType customerType)
        {
            if (ModelState.IsValid)
            {
                db.CustomerTypes.Add(customerType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerType);
        }

        // GET: CustomerTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerType customerType = db.CustomerTypes.Find(id);
            if (customerType == null)
            {
                return HttpNotFound();
            }
            return View(customerType);
        }

        // POST: CustomerTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description")] CustomerType customerType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerType);
        }

        // GET: CustomerTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerType customerType = db.CustomerTypes.Find(id);
            if (customerType == null)
            {
                return HttpNotFound();
            }
            return View(customerType);
        }

        // POST: CustomerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerType customerType = db.CustomerTypes.Find(id);
            db.CustomerTypes.Remove(customerType);
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
