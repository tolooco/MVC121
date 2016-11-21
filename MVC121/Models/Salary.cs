using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC121.Models
{
    public class Salary
    {
        #region  Configuration

        internal class Configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Salary>
        {
            public Configuration()
            {
                HasRequired(current => current.Personel)
                    .WithMany(personelid => personelid.Salaries)
                    .HasForeignKey(current => current.PersonelID)
                    .WillCascadeOnDelete(false);

                HasRequired(current => current.Mount)
                   .WithMany(mountid => mountid.Salaries)
                   .HasForeignKey(current => current.MountID)
                   .WillCascadeOnDelete(false);

                HasRequired(current => current.BaseSalry)
                  .WithMany(basesalryid => basesalryid.Salaries)
                  .HasForeignKey(current => current.BaseSalaryID)
                  .WillCascadeOnDelete(false);
            }
        }

        #endregion Configuration

        #region CTOR
        public Salary()
        {

        }
        #endregion CTOR

        #region Properties
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// ارتباط یک به چند با جدول ماه
        /// </summary>
        [DisplayName("شماره ماه ")]
        public int MountID { get; set; }

        [DisplayName("ماه ")]
        public virtual Models.Utility.Mount Mount { get; set; }

        //#######################################################

        [Required(ErrorMessage = "اضافه کار را وارد نمائید")]
        [DisplayName("تعداد ساعت اضافه کار ")]
        [TypeConverter("smallint")]
        public int EzafehKar { get; set; }

        [Required(ErrorMessage = "تعداد روز کاری را وارد نمائید")]
        [DisplayName("روز کاری ")]
        [TypeConverter("smallint")]
        public int WorkDay { get; set; }

        [Required(ErrorMessage = "تعداد روز کاری فعال را وارد نمائید")]
        [DisplayName("تعداد روز کاری فعال ")]
        [TypeConverter("smallint")]
        public int ActiveWorkDay { get; set; }

        [Required(ErrorMessage = "مبلغ پاداش را وارد نمائید")]
        [DisplayName("مبلغ پاداش ")]
        public double GiftSalary { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        [Required(ErrorMessage = "مبلغ مزایا را وارد نمائید")]
        [DisplayName("مبلغ مزایا ")]
        public double RewardSalary { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        [Required(ErrorMessage = "مبلغ پورسانت را وارد نمائید")]
        [DisplayName("مبلغ پورسانت ")]
        public double Porsant { get; set; }

        [Required(ErrorMessage = "ساعت مرخصی را وارد نمائید")]
        [DisplayName("ساعت مرخصی ")]
        public int RestTime { get; set; }

        [Required(ErrorMessage = "روز مرخصی را وارد نمائید")]
        [DisplayName("روز مرخصی ")]
        public int RestDay { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        [Required(ErrorMessage = "مبلغ مساعده را وارد نمائید")]
        [DisplayName("مبلغ مساعده ")]
        public double HelpSalary { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        [Required(ErrorMessage = "مبلغ جریمه را وارد نمائید")]
        [DisplayName("مبلغ جریمه ")]
        public double PenaltySalary { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        [Required(ErrorMessage = "مبلغ سفته را وارد نمائید")]
        [DisplayName("مبلغ سفته ")]
        public double SaftehPrice { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        [Required(ErrorMessage = "مبلغ بدهی سفته را وارد نمائید")]
        [DisplayName("مبلغ بدهی سفته ")]
        public double SaftehBedehi { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        [Required(ErrorMessage = "مبلغ بدهی را وارد نمائید")]
        [DisplayName("مبلغ بدهی ")]
        public double Bedehi { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        [Required(ErrorMessage = "مبلغ بن کالا را وارد نمائید")]
        [DisplayName("مبلغ بن کالا ")]
        public double PBon { get; set; }

        [DisplayName("توضیحات ")]
        public string Description { get; set; }

        #region Relation

        /// <summary>
        /// ارتباط یک به چند با جدول کارکنان
        /// </summary>
        [DisplayName("شماره پرسنل ")]
        public int PersonelID { get; set; }

        [DisplayName("پرسنل ")]
        public virtual Models.Personel Personel { get; set; }

        //#######################################################

        /// <summary>
        /// ارتباط یک به یک با جدول قوانین حقوق
        /// </summary>
        [DisplayName("شماره حقوق پایه ")]
        public int BaseSalaryID { get; set; }

        [DisplayName(" حقوق پایه ")]
        public virtual Models.BaseSalary BaseSalry { get; set; }
        #endregion Relation

        #endregion Properties

        #region Calculator
        /// <summary>
        /// محاسبه پایه حقوق
        /// </summary>
        [DisplayName("پایه حقوق ")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcBaseSalary1 { get { double? dblResult = ((WorkDay * BaseSalry.BaseSalaryDaily)); return dblResult; } }


        /// <summary>
        /// محاسبه ایاب ذهاب
        /// </summary>
        [DisplayName("محاسبه ایاب ذهاب ")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcNavSalary1 { get { double? dblResult = ((BaseSalry.NavSalary / 30) * ActiveWorkDay); return dblResult; } }

        /// <summary>
        /// محاسبه مطالبات مرخصی
        /// </summary>
        [DisplayName("محاسبه مطالبات مرخصی ")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcMMorakhasi1 { get { double? dblResult = ((BaseSalry.RestSalary - (RestDay * BaseSalry.BaseSalaryDaily) - (BaseSalry.BaseSalaryDaily / 8 * RestTime))); return dblResult; } }


        /// <summary>
        /// محاسبه اضافه کار
        /// </summary>
        [DisplayName("محاسبه اضافه کار ")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcEzafehkar1 { get { double? dblResult = ((BaseSalry.EzafehTimeSalary * EzafehKar)); return dblResult; } }


        /// <summary>
        /// محاسبه حق مسکن
        /// </summary>
        [DisplayName("محاسبه حق مسکن ")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcHomeSalary1 { get { double? dblResult = ((BaseSalry.HomeSalary)); return dblResult; } }

        /// <summary>
        /// محاسبه غیبت و کسر از حقوق
        /// </summary>
        [DisplayName("محاسبه غیبت و کسر از حقوق ")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcGheibat1 { get { double? dblResult = ((WorkDay - ActiveWorkDay) * BaseSalry.KasrGheibat); return dblResult; } }

        /// <summary>
        /// محاسبه مانده سفته
        /// </summary>
        [DisplayName("محاسبه مانده سفته ")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcMandehSafthe1 { get { double? dblResult = ((SaftehPrice - SaftehBedehi)); return dblResult; } }

        /// <summary>
        /// محاسبه کسورات
        /// </summary>
        [DisplayName("محاسبه کسورات ")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcKosorat1 { get { double? dblResult = ((PBon + CalcGheibat1 + CalcMandehSafthe1 + PenaltySalary + HelpSalary)); return dblResult; } }

        /// <summary>
        /// محاسبه پرداختها
        /// </summary>
        [DisplayName("محاسبه پرداختها ")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcPayments1
        {
            get
            {
                double? dblResult = ((Porsant + GiftSalary
                + BaseSalry.BonSalary + CalcNavSalary1 + RewardSalary + CalcMMorakhasi1 +
                BaseSalry.HomeSalary + CalcBaseSalary1 + CalcEzafehkar1)); return dblResult;
            }
        }

        /// <summary>
        /// محاسبه قابل پرداخت
        /// </summary>
        [DisplayName("محاسبه قابل پرداخت ")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcRealPayments1 { get { double? dblResult = (CalcPayments1 - CalcKosorat1); return dblResult; } }


        #endregion Calculator
    }
}