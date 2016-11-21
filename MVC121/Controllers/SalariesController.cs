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
    public class SalariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Salaries
        public ActionResult Index()
        {
            var salaries = db.Salaries.Include(s => s.BaseSalry).Include(s => s.Mount).Include(s => s.Personel);
            return View(salaries.ToList());
        }

        // GET: Salaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salary salary = db.Salaries.Find(id);
            if (salary == null)
            {
                return HttpNotFound();
            }
            return View(salary);
        }

        // GET: Salaries/Create
        public ActionResult Create()
        {
            ViewBag.BaseSalaryID = new SelectList(db.BaseSalaries, "ID", "LevelPrice");
            ViewBag.MountID = new SelectList(db.Mounts, "ID", "Name");
            ViewBag.PersonelID = new SelectList(db.Personels, "ID", "FullName");
            return View();
        }

        // POST: Salaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MountID,EzafehKar,WorkDay,ActiveWorkDay,GiftSalary,RewardSalary,Porsant,RestTime,RestDay,HelpSalary,PenaltySalary,SaftehPrice,SaftehBedehi,Bedehi,PBon,Description,PersonelID,BaseSalaryID")] Salary salary)
        {
            if (ModelState.IsValid)
            {
                db.Salaries.Add(salary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BaseSalaryID = new SelectList(db.BaseSalaries, "ID", "LevelPrice", salary.BaseSalaryID);
            ViewBag.MountID = new SelectList(db.Mounts, "ID", "Name", salary.MountID);
            ViewBag.PersonelID = new SelectList(db.Personels, "ID", "FullName", salary.PersonelID);
            return View(salary);
        }

        // GET: Salaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salary salary = db.Salaries.Find(id);
            if (salary == null)
            {
                return HttpNotFound();
            }
            ViewBag.BaseSalaryID = new SelectList(db.BaseSalaries, "ID", "LevelPrice", salary.BaseSalaryID);
            ViewBag.MountID = new SelectList(db.Mounts, "ID", "Name", salary.MountID);
            ViewBag.PersonelID = new SelectList(db.Personels, "ID", "FullName", salary.PersonelID);
            return View(salary);
        }

        // POST: Salaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MountID,EzafehKar,WorkDay,ActiveWorkDay,GiftSalary,RewardSalary,Porsant,RestTime,RestDay,HelpSalary,PenaltySalary,SaftehPrice,SaftehBedehi,Bedehi,PBon,Description,PersonelID,BaseSalaryID")] Salary salary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BaseSalaryID = new SelectList(db.BaseSalaries, "ID", "LevelPrice", salary.BaseSalaryID);
            ViewBag.MountID = new SelectList(db.Mounts, "ID", "Name", salary.MountID);
            ViewBag.PersonelID = new SelectList(db.Personels, "ID", "FullName", salary.PersonelID);
            return View(salary);
        }

        // GET: Salaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salary salary = db.Salaries.Find(id);
            if (salary == null)
            {
                return HttpNotFound();
            }
            return View(salary);
        }

        // POST: Salaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salary salary = db.Salaries.Find(id);
            db.Salaries.Remove(salary);
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
