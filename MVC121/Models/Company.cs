using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC121.Models
{
    public class Company
    {
        public Company()
        {
           
        }

        #region Properties

        [Key,Required(ErrorMessage ="آی دی راوارد نمائید")
            ,DatabaseGenerated(DatabaseGeneratedOption.None)
            ,DisplayName("آی دی شرکت")]
        public int ID { get; set; }

        [Required(ErrorMessage =("نام شرکت را وارد نمائید")),MaxLength(121)
            ,Column(TypeName ="NVarchar"), DisplayName("نام شرکت")]
        public string  Title { get; set; }

        [Required(ErrorMessage = ("نام دسته بندی محصول را وارد نمائید")), MaxLength(100)
           , Column(TypeName = "NVarchar"),DisplayName("دسته بندی محصولات")]
        public string  Category { get; set; }

        [DisplayName("نام و فعالیت شرکت")]
        public string DisplayName { get { string strResult = string.Format("{0}-{1}-{2}", ID, Title, Category);return strResult; } }

        #endregion Properties

        #region Relation
        [DisplayName("اطلاعات تماس")]
        public virtual IList<Contact> Contacts { get; set; }
        ////////////////////////////////////////////
        [DisplayName("محصولات")]
        public virtual IList<Product> Products { get; set; }
        #endregion Relation
    }
}