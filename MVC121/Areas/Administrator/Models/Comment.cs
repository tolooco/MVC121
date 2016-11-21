using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace MVC121.Areas.Administrator.Models
{
    public class Comment
    {
        public Comment()
        {
            
        }

        [DisplayName("شماره دیدگاه")]
        [Display(Name = "شماره دیدگاه")]
        public int ID { get; set; }

        [Required(ErrorMessage = "نام را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("نام*")]
        [Display(Name = "نام* ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "رایانامه را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("رایانامه*")]
        [Display(Name = "رایانامه*")]
        public string Email { get; set; }

        [DisplayName("آدرس سایت")]
        [Display(Name = "آدرس سایت")]
        public string URL { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "رایانامه را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("دیدگاه*")]
        [Display(Name = "دیدگاه*")]
        public string Comments { get; set; }

        [DisplayName("تاریخ درج دیدگاه")]
        public Nullable<System.DateTime> PublishTime { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("دیدگاه مورد تائید است؟")]
        [Display(Name = "دیدگاه مورد تائید است؟")]
        public bool? IsCheked { get; set; }

        //ارتباط یک به چند با جدول پست
        [DisplayName("شماره پست")]
        [Display(Name = "شماره پست")]
        public virtual int PostID { get; set; }

        [DisplayName("پست")]
        [Display(Name = "پست")]
        public virtual Post Post { get; set; }

        
        //*******
    }
}