using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC121.Models
{
    public class Product
    {
        #region Configuration
        internal class Configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Product>
        {
            public Configuration()
            {
                HasRequired(current => current.Company)
                    .WithMany(company => company.Products)
                    .HasForeignKey(current => current.CompanyID)
                    .WillCascadeOnDelete(false);

                HasRequired(current => current.ProductCategory)
                   .WithMany(customer => customer.Products)
                   .HasForeignKey(current => current.ProductCategoryID)
                   .WillCascadeOnDelete(false);
            }
        }

        #endregion Configuration


        #region Properties
        [Key, Required(ErrorMessage = "آی دی راوارد نمائید")
       , DatabaseGenerated(DatabaseGeneratedOption.None)
       , DisplayName("آی دی محصول")]
        public int ID { get; set; }

        [Required(ErrorMessage = ("بارکد را وارد نمائید")),
         DisplayName("بارکد")]
        public Int64 Barcode { get; set; }

        [Required(ErrorMessage = ("نام محصول را وارد نمائید")), MaxLength(121)
        , Column(TypeName = "NVarchar"), DisplayName("نام محصول")]
        public string Title { get; set; }

        [Required(ErrorMessage =("وزن محصول را وارد نمائید")),DisplayName("وزن محصول")]
        public int Wight { get; set; }

        [Required(ErrorMessage = ("تعداد در بسته را وارد نمائید")), DisplayName("تعداد در بسته")]
        public int CountNumber { get; set; }


        #endregion Properties


        #region Relation

        [DisplayName("آی دی شرکت")]
        public virtual int  CompanyID { get; set; }
        [DisplayName("شرکت")]
        public virtual Company Company { get; set; }

        //////////////////////////////////////
        [DisplayName("آی دی گروه محصول")]
        public virtual int ProductCategoryID { get; set; }
        [DisplayName("گروه محصول")]
        public virtual ProductCategory ProductCategory { get; set; }

        //////////////////////////////////////
        [DisplayName("قیمت گذاری")]
        public virtual IList<PriceType> PriceTypes { get; set; }

        #endregion Relation

    }
}