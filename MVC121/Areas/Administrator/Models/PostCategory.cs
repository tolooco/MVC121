using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVC121.Areas.Administrator.Models
{
    public class PostCategory
    {
        public PostCategory()
        {

        }

        [DisplayName("شماره دسته بندی")]
        [Display(Name = "شماره دسته بندی")]
        public int ID { get; set; }

        [Required(ErrorMessage = "دسته بندی مطالب را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("دسته بندی مطالب")]
        [Display(Name = "دسته بندی مطالب")]
        public string Category { get; set; }

        [DisplayName("پست")]
        [Display(Name = "پست")]
        public virtual IList<MVC121.Areas.Administrator.Models.Post> Posts { get; set; }
    }
}