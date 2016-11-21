using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC121.Areas.Administrator.Models
{
    public class NewsLetterCategory
    {
        public NewsLetterCategory()
        {

        }

        [DisplayName("شماره دسته بندی")]
        [Display(Name = "شماره دسته بندی")]
        public int ID { get; set; }

        [Required(ErrorMessage = "دسته بندی خبرنامه را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("دسته بندی خبرنامه")]
        [Display(Name = "دسته بندی خبرنامه")]
        public string Name { get; set; }

        [DisplayName("خبرنامه")]
        [Display(Name = "خبرنامه")]
        public virtual IList<MVC121.Areas.Administrator.Models.NewsLetter> NewsLetters { get; set; }
    }
}