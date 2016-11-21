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
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            Administrator.ViewModels.AdminViewModels oAVM = new ViewModels.AdminViewModels();
            oAVM.Admin = db.Admins.First();
            oAVM.Comments = db.Comments.ToList();
            oAVM.PostCaegories = db.PostCategories.ToList();
            oAVM.Posts = db.Posts.ToList();
            oAVM.Prices = db.PriceTypes.ToList();
            oAVM.Users = db.Users.ToList();
            return View(oAVM);
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
