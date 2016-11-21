using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC121.Models
{

    public class PriceType
    {

        #region Configuration
        internal class Configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<PriceType>
        {
            public Configuration()
            {

                HasRequired(current => current.CustomerType)
                 .WithMany(customertype => customertype.PriceTypes)
                 .HasForeignKey(current => current.CustomerTypeID)
                 .WillCascadeOnDelete(false)
                 ;

                HasRequired(current => current.Products)
                .WithMany(products => products.PriceTypes)
                .HasForeignKey(current => current.ProductID)
                .WillCascadeOnDelete(false)
                ;

            }
        }

        #endregion Configuration

        #region Ctor
        public PriceType()
        {

        }
        #endregion Ctor

        #region Properties

        [Key, Required(ErrorMessage = "آی دی راوارد نمائید")
       , DatabaseGenerated(DatabaseGeneratedOption.None)
       , DisplayName("آی دی قیمت گذاری ")]
        public int ID { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "قیمت درب کارخانه را وارد نمائید")]
        [System.ComponentModel.DataAnnotations.DisplayFormat
            (ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        [DisplayName("درب کارخانه")]
        public double Factory { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "قیمت مصرف کننده را وارد نمائید")]
        [System.ComponentModel.DataAnnotations.DisplayFormat
            (ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        [DisplayName("مصرف کننده")]
        public double Final { get; set; }


        [System.ComponentModel.DataAnnotations.DisplayFormat
            (ApplyFormatInEditMode = false, DataFormatString = "{0:#0 درصد }")]
        [DisplayName("تخفیف خرید")]
        public float? TakhfifKharid { get; set; }

        [System.ComponentModel.DataAnnotations.DisplayFormat
           (ApplyFormatInEditMode = false, DataFormatString = "{0:#0 درصد }")]
        [DisplayName("اشانتیون خرید")]
        public float? Eshantion { get; set; }

        [System.ComponentModel.DataAnnotations.DisplayFormat
          (ApplyFormatInEditMode = false, DataFormatString = "{0:#0 درصد }")]
        [DisplayName("مارجین")]
        public float? Marjin { get; set; }

        [System.ComponentModel.DataAnnotations.DisplayFormat
          (ApplyFormatInEditMode = false, DataFormatString = "{0:#0 درصد }")]
        [DisplayName("پروموشن")]
        public float? Promotion { get; set; }

        [System.ComponentModel.DataAnnotations.DisplayFormat
         (ApplyFormatInEditMode = false, DataFormatString = "{0:#0 درصد }")]
        [DisplayName("تبلیغات")]
        public float? Tablighat { get; set; }

        [System.ComponentModel.DataAnnotations.DisplayFormat
        (ApplyFormatInEditMode = false, DataFormatString = "{0:#0 درصد }")]
        [DisplayName("ریبیت")]
        public float? Rebate { get; set; }

        [System.ComponentModel.DataAnnotations.DisplayFormat
        (ApplyFormatInEditMode = false, DataFormatString = "{0:#0 درصد }")]
        [DisplayName("تخفیف نقدی فروش")]
        public float? TakhfifForosh { get; set; }

        [System.ComponentModel.DataAnnotations.DisplayFormat
        (ApplyFormatInEditMode = false, DataFormatString = "{0:#0 درصد }")]
        [DisplayName("ارزش افزوده")]
        public float? ArzeshAfzodeh { get; set; }


        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "تاریخ شروع مصوب را وارد نمائید")]
        [DisplayName("شروع مصوب")]
        public Nullable<System.DateTime> StartDateLicence { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "تاریخ پایان مصوب را وارد نمائید")]
        [DisplayName("پایان مصوب")]
        public Nullable<System.DateTime> EndDateLicence { get; set; }


        [DisplayName("شروع پروموشن")]
        public Nullable<System.DateTime> StartDatePro { get; set; }


        [DisplayName("پایان مصوب")]
        public Nullable<System.DateTime> EndDatePro { get; set; }

        #endregion Properties

        #region Relation

        [DisplayName("آی دی محصول")]
        public virtual int ProductID { get; set; }

        [DisplayName("محصول")]
        public virtual Product Products { get; set; }
  
        /// <summary>
        /// 
        /// </summary>
        
        [DisplayName("آی دی گروه فروشگاه")]
        public virtual int CustomerTypeID { get; set; }

        [DisplayName(" گروه فروشگاه")]
        public virtual CustomerType CustomerType { get; set; }

        #endregion Relation

        #region Calculators

        [DisplayName("محاسبه  قیمت مصرف کننده بدون ارزش افزوده")]
        [System.ComponentModel.DataAnnotations.DisplayFormat
        (ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcFinalWithArzesh
        {
            get
            {
                double? dblResult =
                     (Final * 100 / (100 + ArzeshAfzodeh));
                return (dblResult);
            }
        }


        [DisplayName(" محاسبه قیمت مصوب با ارزش افزوده")]
        [System.ComponentModel.DataAnnotations.DisplayFormat
             (ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcLicencePriceWithArzesh
        {
            get
            {
                double? dblLicence = ((Final * Marjin) / 100);
                double? dblResult =
                     ((Final - dblLicence));
                return (dblResult);
            }
        }

        [DisplayName(" محاسبه قیمت مصوب بدون ارزش افزوده")]
        [System.ComponentModel.DataAnnotations.DisplayFormat
            (ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcLicencePriceWithoutArzesh
        {
            get
            {
                double? dblLicence = ((CalcFinalWithArzesh * Marjin) / 100);
                double? dblResult =
                     ((CalcFinalWithArzesh - dblLicence));
                return (dblResult);
            }
        }

        [DisplayName("محاسبه قیمت پروموشن با ارزش افزوده")]
        [System.ComponentModel.DataAnnotations.DisplayFormat
            (ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcPromotionWithArzesh
        {
            get
            {
                double? dblPromotion = ((CalcLicencePriceWithArzesh * Promotion) / 100);
                double? strResult =
                     (CalcLicencePriceWithArzesh - dblPromotion);
                return (strResult);
            }
        }

        [DisplayName("محاسبه قیمت پروموشن بدون ارزش افزوده")]
        [System.ComponentModel.DataAnnotations.DisplayFormat
          (ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcPromotionWithoutArzesh
        {
            get
            {
                double? dblPromotion = ((CalcLicencePriceWithoutArzesh * Promotion) / 100);
                double? strResult =
                     (CalcLicencePriceWithoutArzesh - dblPromotion);
                return (strResult);
            }
        }

        [DisplayName("محاسبه قیمت ریبیت با ارزش افزوده")]
        [System.ComponentModel.DataAnnotations.DisplayFormat
           (ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcRebateWithArzesh
        {
            get
            {
                double? dblRebate = ((CalcLicencePriceWithArzesh * Rebate) / 100);
                double? strResult =
                     (CalcLicencePriceWithArzesh - dblRebate);
                return (strResult);
            }
        }

        [DisplayName("محاسبه قیمت ریبیت بدون ارزش افزوده")]
        [System.ComponentModel.DataAnnotations.DisplayFormat
          (ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcRebateWithoutArzesh
        {
            get
            {
                double? dblRebate = ((CalcLicencePriceWithoutArzesh * Rebate) / 100);
                double? strResult =
                     (CalcLicencePriceWithoutArzesh - dblRebate);
                return (strResult);
            }
        }

        [DisplayName("محاسبه خالص خرید")]
        [System.ComponentModel.DataAnnotations.DisplayFormat
            (ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcKhalesKharid
        {
            get
            {
                double? dblEshantion = Factory / (100 + Eshantion);
                double? dblEshantionPer = dblEshantion * 100;
                double? dblTakhfifKharid = ((dblEshantionPer - (dblEshantionPer * (TakhfifKharid)) / 100));
                double? dblResult =
                     (dblTakhfifKharid);
                return (dblResult);
            }
        }


        [DisplayName("محاسبه خالص فروش")]
        [System.ComponentModel.DataAnnotations.DisplayFormat
            (ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcKhalesForosh
        {
            get
            {
                double? dblLicence = ((Final * Marjin) / 100);
                double? dblPromotion = ((CalcLicencePriceWithArzesh * Promotion) / 100);
                double? dblRebate = ((CalcLicencePriceWithArzesh * Rebate) / 100);
                double? dblTakhfifNaghdi = ((Final * TakhfifForosh) / 100);
                double? dblTakhfifTablighat = ((Final * Tablighat) / 100);

                double? dblTakhfifat = (dblPromotion+dblRebate + dblTakhfifNaghdi + dblTakhfifTablighat + dblLicence);

                double? dblResult = Final - dblTakhfifat;

                return (dblResult);
            }
        }

        [DisplayName("محاسبه سود و زیان")]
        [System.ComponentModel.DataAnnotations.DisplayFormat
           (ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcSodeForosh
        {
            get
            {
                double? dblResult =
                     ((CalcKhalesForosh - CalcKhalesKharid));
                return (dblResult);
            }
        }

        #endregion Calculators

    }
}