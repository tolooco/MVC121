using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC121.Areas.Administrator.Models;
using MVC121.Models;
using Infrastructure;

namespace MVC121.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        //با استفاده از ؟
        //میتوانید اکشن ذیل را با یک و یا حتی دو پارامتر ادمین آی دی و نیوزلتر آی دی و یا حتی یوزر آی در همراه کنید 
        //و چک کنید اگر این مقادیر نال بود چه مواردی ریترن گردد
        //و اگر نال نبود چه مقادیری ریترن گردد
        //بدین ترتیب اکشن شما فوق العاده قدرتمند و هوشمند میگردد 
        public ActionResult About()
        {
            //مثال آموزشی جهت استفاده از ویو مدل های تو در تو
            //ایجاد شی از ویو مدل مادر
            MVC121.Areas.Administrator.ViewModels.AdminNewsViewModels oANVM =
                new Areas.Administrator.ViewModels.AdminNewsViewModels();
            //ایجاد شی از ادمین ویو مدل
            MVC121.Areas.Administrator.ViewModels.AdminViewModels oAVM =
                new Areas.Administrator.ViewModels.AdminViewModels();
            //ایجاد شی از نیوز ویو مدل
            MVC121.Areas.Administrator.ViewModels.NewsViewModels oNVM =
                new Areas.Administrator.ViewModels.NewsViewModels();
            //مقدار دهی ادمین ویو مدل
            
            oAVM.Admin = db.Admins.First();
            oAVM.Comments = db.Comments.ToList();
            oAVM.PostCaegories = db.PostCategories.ToList();
            var varPosts =
            db.Posts
           .OrderByDescending(current => current.ID)
           .ToList();

            oAVM.Posts = varPosts;
            oAVM.Prices = db.PriceTypes.ToList();
            oAVM.Users = db.Users.ToList();
            //مقدار دهی نیوز ویو مدل
            oNVM.NewsLetter = db.NewsLetters.First();

            var varUsers =
            db.Users
           .OrderByDescending(current => current.Id)
           .ToList();

            oNVM.Users = varUsers;
            //اختصاص ویو مدل های مقدار دهی شده به ویو مدل مادر
            oANVM.AdminViewModel = oAVM;
            oANVM.NewsViewModel = oNVM;

            //ارسال ویو مدل مادر
            return View(oANVM);
        }
        //[TestforAjax]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult SendContact([Bind(Include = "ID,Name,Email,Subject,Message")] UserContact userContact)
        {
            if (ModelState.IsValid)
            {
                db.UserContacts.Add(userContact);
                db.SaveChanges();
                //ارسال رایانامه
                MVC121.Helpers.Utilities.Email.SendContact
                    (userContact.Name, userContact.Email, userContact.Subject, userContact.Message);
                return View();
            }

            return View("Error");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "اطلاعات تماس.";

            return View();
        }
    }
}