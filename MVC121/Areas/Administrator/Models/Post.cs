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
    public class Post
    {
        #region Configuration
        internal class Configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Post>
        {
            public Configuration()
            {

                HasRequired(current => current.PostCategory)
                 .WithMany(postCategory => postCategory.Posts)
                 .HasForeignKey(current => current.PostCategoryID)
                 .WillCascadeOnDelete(false)
                 ;

                HasRequired(current => current.Admin)
                .WithMany(admin => admin.Posts)
                .HasForeignKey(current => current.AdminID)
                .WillCascadeOnDelete(false)
                ;

            }
        }

        #endregion Configuration

        public Post()
        {

        }


        [DisplayName("شماره پست")]
        [Display(Name = "شماره پست")]
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "نام مطلب را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("نام مطلب")]
        [Display(Name = "نام مطلب")]
        public string Name { get; set; }

        //ارتباط یک به چند با جدول ادمین
        [DisplayName("شماره ادمین")]
        [Display(Name = "شماره ادمین")]
        public virtual int AdminID { get; set; }

        [DisplayName("نام ادمین")]
        [Display(Name = "نام ادمین")]
        public virtual Admin Admin { get; set; }
        //*******

        //ارتباط یک به چند با جدول دسته بندی پست
        [DisplayName("شماره دسته بندی پست")]
        [Display(Name = "شماره دسته بندی پست")]
        public virtual int PostCategoryID { get; set; }

        [DisplayName("دسته بندی پست")]
        [Display(Name = "دسته بندی پست")]
        public virtual PostCategory PostCategory { get; set; }
        //*******

        //ارتباط چند به یک با جدول دیدگاه
        [DisplayName("دیدگاههای پست")]
        [Display(Name = "دیدگاههای پست")]
        public virtual IList<MVC121.Areas.Administrator.Models.Comment> Comments { get; set; }
        //*******

        [ScaffoldColumn(false)]
        [DisplayName("نام کاربری")]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }

        [Required(ErrorMessage = "نام نویسنده مطلب را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("اثری از")]
        [Display(Name = "اثری از")]
        public string PoetryWriter { get; set; }

      

        [Required(ErrorMessage = "خلاصه توضیحات مطلب را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("خلاصه توضیحات مطلب")]
        [Display(Name = "خلاصه توضیحات مطلب")]
        public string SmallBody { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "متن کامل مطلب را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("متن کامل مطلب")]
        [Display(Name = "متن کامل مطلب")]
        [DataType(DataType.Html,ErrorMessage ="فرمت متن باید اچ تی ام ال باشد")]
        public string FullBody { get; set; }

        [Required(ErrorMessage = "کلمه کلیدی مطلب را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("کلمه کلیدی مطلب")]
        [Display(Name = "کلمه کلیدی مطلب")]
        public string Keyword { get; set; }

        [Required(ErrorMessage = ("تاریخ درج مطلب را وارد نمایید"))]
        [DisplayName("تاریخ درج مطلب")]
        public Nullable<System.DateTime> PublishTime { get; set; }


        [DisplayName("پست فعال است؟")]
        [Display(Name = "پست فعال است؟")]
        public bool IsActive { get; set; }

        [DisplayName(" دیدگاه برای پست فعال است؟")]
        [Display(Name = "دیدگاه برای پست فعال است؟ ")]
        public bool IsCommentable { get; set; }

        [DisplayName("تصویر پست")]
        [Display(Name = "تصویر پست")]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }





    }
}