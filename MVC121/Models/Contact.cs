using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC121.Models
{
    public class Contact
    {

        #region Configuration
        internal class Configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Contact>
        {
            public Configuration()
            {
                HasRequired(current => current.Company)
                    .WithMany(company => company.Contacts)
                    .HasForeignKey(current => current.CompanyID)
                    .WillCascadeOnDelete(false);

                HasRequired(current => current.Customer)
                   .WithMany(customer => customer.Contacts)
                   .HasForeignKey(current => current.CustomerID)
                   .WillCascadeOnDelete(false);
            }
        }

        #endregion Configuration

        public Contact()
        {

        }

        #region Properties
        [Key, Required(ErrorMessage = "آی دی راوارد نمائید")
       , DatabaseGenerated(DatabaseGeneratedOption.None)
       , DisplayName("آی دی مشخصات تماس")]
        public int ID { get; set; }

        [Required(ErrorMessage = ("نام کشور را وارد نمائید")), MaxLength(121)
          , Column(TypeName = "NVarchar"), DisplayName("نام کشور")]
        public string  Country { get; set; }

        [Required(ErrorMessage = ("نام استان را وارد نمائید")), MaxLength(121)
        , Column(TypeName = "NVarchar"), DisplayName("نام استان")]
        public string State { get; set; }

        [Required(ErrorMessage = ("نام شهر را وارد نمائید")), MaxLength(121)
         , Column(TypeName = "NVarchar"), DisplayName("نام شهر")]
        public string City { get; set; }

        [Required(ErrorMessage = ("آدرس را وارد نمائید")), MaxLength(1210)
       , Column(TypeName = "NVarchar"), DisplayName("آدرس")]
        public string Address { get; set; }

        [Required(ErrorMessage = ("شماره ثابت را وارد نمائید")), MaxLength(14)
        , Column(TypeName = "NVarchar"), DisplayName("شماره ثابت")]
        public string Phone { get; set; }

        [Required(ErrorMessage = ("شماره همراه را وارد نمائید")), MaxLength(14)
        , Column(TypeName = "NVarchar"), DisplayName("شماره همراه ")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = ("نمابر را وارد نمائید")), MaxLength(14)
        , Column(TypeName = "NVarchar"), DisplayName("نمابر")]
        public string Fax { get; set; }

        [Required(ErrorMessage = ("رایانامه را وارد نمائید")), MaxLength(121)
       , Column(TypeName = "NVarchar"), DisplayName("رایانامه")]
        public string Email { get; set; }

        #endregion Properties

        #region Relation
        [DisplayName("آی دی خریدار")]
        public virtual int CustomerID { get; set; }

        [DisplayName("خریدار")]
        public virtual Customer  Customer { get; set; }

        /////////////////////////////////////////////////

        [DisplayName("آی دی شرکت")]
        public virtual int CompanyID { get; set; }

        [DisplayName("شرکت")]
        public virtual Company Company { get; set; }

        #endregion Relation

    }
}