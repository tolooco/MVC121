using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC121.Models
{
    public class Customer
    {
        #region Configuration
        internal class Configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Customer>
        {
            public Configuration()
            {
                HasRequired(current => current.CustomerType)
                    .WithMany(customertype => customertype.Customers)
                    .HasForeignKey(current => current.CustomerTypeID)
                    .WillCascadeOnDelete(false);
            }
        }
      
        #endregion Configuration

        public Customer()
        {

        }

        #region Properties

        [Key, Required(ErrorMessage = "آی دی راوارد نمائید")
          , DatabaseGenerated(DatabaseGeneratedOption.None)
          , DisplayName("آی دی خریدار")]
        public int ID { get; set; }

        [Required(ErrorMessage = ("نام خریدار را وارد نمائید")), MaxLength(121)
           , Column(TypeName = "NVarchar"), DisplayName("نام خریدار")]
        public string Title { get; set; }

        [Required(ErrorMessage = ("توضیحات را وارد نمائید")), MaxLength(121)
          , Column(TypeName = "NVarchar"), DisplayName("توضیحات")]
        public string Description { get; set; }

        [DisplayName("نام و آی دی خریدار")]
        public string DisplayName { get { string strResult = string.Format("{0}-{1}", ID, Title); return strResult; } }

        #endregion Properties


        #region Relation

        [DisplayName("آی دی دسته بندی دی خریدار")]
        public virtual int CustomerTypeID { get; set; }

        [DisplayName("دسته بندی دی خریدار")]
        public virtual CustomerType  CustomerType { get; set; }

        /////////////////////////////////////////////

        [DisplayName("اطلاعات تماس")]
        public virtual IList<Contact> Contacts { get; set; }

        #endregion Relation
    }
}