using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC121.Models
{
    public class CustomerType
    {

        public CustomerType()
        {

        }

        #region Properties

        [Key, Required(ErrorMessage = "آی دی راوارد نمائید")
          , DatabaseGenerated(DatabaseGeneratedOption.None)
          , DisplayName("آی دی دسته بندی خریدار")]
        public int ID { get; set; }

        [Required(ErrorMessage = ("نام دسته بندی خریدار را وارد نمائید")), MaxLength(121)
           , Column(TypeName = "NVarchar"), DisplayName("نام دسته بندی خریدار")]
        public string  Title { get; set; }

        [MaxLength(121)
           , Column(TypeName = "NVarchar"), DisplayName("توضیحات")]
        public string  Description { get; set; }

        [DisplayName("نام و آی دی دسته بندی خریدار")]
        public string DisplayName { get { string strResult = string.Format("{0}-{1}", ID, Title); return strResult; } }

        #endregion Properties

        #region Relation

        [DisplayName("خریداران")]
        public virtual IList<Customer> Customers { get; set; }
        /////////////////////////////////////////////
        [DisplayName("قیمت گذاری")]
        public virtual IList<PriceType> PriceTypes { get; set; }

        #endregion Relation
    }
}