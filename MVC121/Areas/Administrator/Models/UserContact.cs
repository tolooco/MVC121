using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC121.Areas.Administrator.Models
{
    public class UserContact
    {
        public UserContact()
        {

        }
        [DisplayName("شماره ")]
        [Display(Name = "شماره ")]
        public int ID { get; set; }

        [Required(ErrorMessage = "نام را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("نام ")]
        [Display(Name = "نام ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "رایانامه را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("رایانامه")]
        [Display(Name = "رایانامه")]
        [EmailAddress]
        public string  Email { get; set; }

        [Required(ErrorMessage = "موضوع را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("موضوع")]
        [Display(Name = "موضوع")]
        public string Subject { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "مطلب را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName(" مطلب")]
        [Display(Name = " مطلب")]
        public string Message { get; set; }
    }
}