using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC121.Areas.Administrator.Models
{
    public class Admin
    {
        public Admin()
        {

        }

        [DisplayName("شماره پست")]
        [Display(Name = "شماره پست")]
        public int ID { get; set; }

        [Required(ErrorMessage = "نام ادمین را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("نام ")]
        [Display(Name = "نام ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "نام خانوادگی ادمین را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("نام خانوادگی ")]
        [Display(Name = "نام خانوادگی ")]
        public string  Family { get; set; }

        [Required(ErrorMessage = "سن را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("سن")]
        [Display(Name = "سن")]
        public string Age { get; set; }

        [Required(ErrorMessage = "مدرک تحصیلی اول را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("مدرک تحصیلی اول")]
        [Display(Name = "مدرک تحصیلی اول")]
        public string Licence1 { get; set; }

        [DisplayName("مدرک تحصیلی دوم")]
        [Display(Name = "مدرک تحصیلی دوم")]
        public string Licence2 { get; set; }

        [DisplayName("مدرک تحصیلی سوم")]
        [Display(Name = "مدرک تحصیلی سوم")]
        public string Licence3 { get; set; }

        [Required(ErrorMessage = "مهارت اول را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("مهارت اول")]
        [Display(Name = "مهارت اول")]
        public string Prof1 { get; set; }

        [DisplayName("مهارت دوم")]
        [Display(Name = "مهارت دوم")]
        public string Prof2 { get; set; }

        [DisplayName("مهارت سوم")]
        [Display(Name = "مهارت سوم")]
        public string Prof3 { get; set; }

        [Required(ErrorMessage = "علاقمندی اول را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("علاقمندی اول")]
        [Display(Name = "علاقمندی اول")]
        public string Fav1 { get; set; }

        [DisplayName("علاقمندی دوم")]
        [Display(Name = "علاقمندی دوم")]
        public string Fav2 { get; set; }

        [DisplayName("علاقمندی سوم")]
        [Display(Name = "علاقمندی سوم")]
        public string Fav3 { get; set; }

        [Required(ErrorMessage = "رایانامه را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("رایانامه")]
        [Display(Name = "رایانامه")]
        public string Email { get; set; }

        [DisplayName("موبایل")]
        [Display(Name = "موبایل")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "تلفن را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("تلفن")]
        [Display(Name = "تلفن")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "آدرس را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("آدرس")]
        [Display(Name = "آدرس")]
        public string Address { get; set; }


        [DisplayName("پست")]
        [Display(Name = "پست")]
        public virtual IList<MVC121.Areas.Administrator.Models.Post> Posts { get; set; }
        //*******

    }
}