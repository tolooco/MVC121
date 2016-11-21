using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVC121.Areas.Administrator.Models
{
    public class NewsLetter
    {
        public NewsLetter()
        {

        }

        [DisplayName("شماره ")]
        [Display(Name = "شماره ")]
        public int ID { get; set; }

        //*******

        //ارتباط یک به چند با جدول دسته بندی پست
        [DisplayName("شماره دسته بندی ")]
        [Display(Name = "شماره دسته بندی ")]
        public virtual int NewsLetterCategoryID { get; set; }

        [DisplayName("دسته بندی ")]
        [Display(Name = "دسته بندی ")]
        public virtual NewsLetterCategory NewsLetterCategory { get; set; }
        //*******

        [DisplayName("نام خبرنامه")]
        [Display(Name = "نام خبرنامه")]
        public string Name { get; set; }


        [Required(ErrorMessage = "نام نویسنده خبرنامه را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("نویسنده")]
        [Display(Name = "نویسنده")]
        public string Writer { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "متن خبرنامه را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("متن خبرنامه")]
        [Display(Name = "متن خبرنامه")]
        [DataType(DataType.Html, ErrorMessage = "فرمت متن باید اچ تی ام ال باشد")]
        public string FullBody { get; set; }

      
        [Required(ErrorMessage = ("تاریخ درج خبرنامه را وارد نمایید"))]
        [DisplayName("تاریخ درج خبرنامه")]
        public Nullable<System.DateTime> PublishTime { get; set; }

        [DisplayName("خبرنامه ارسال شده است؟")]
        public bool  ISSend { get; set; }
    }
}