using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVC121.Models
{
    public class BaseSalary
    {
        #region CTOR
        public BaseSalary()
        {

        }
        #endregion CTOR

        #region Properties
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// ارتباط یک به چند با جدول سال
        /// </summary>
       
        [DisplayName("سال")]
        public int YearID { get; set; }
        
        [DisplayName("سال")]
        public virtual Utility.Years Year { get; set; }

        
        /// <summary>
        /// ارتباط یک به چند با جدول حقوق
        /// </summary>
        public virtual System.Collections.Generic.IList<Salary> Salaries { get; set; }


        [Required(ErrorMessage = "پایه حقوق یک روز را وارد نمائید")]
        [DisplayName("پایه حقوق یک روز")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double BaseSalaryDaily { get; set; }


        [Required(ErrorMessage = "حق مسکن را وارد نمائید")]
        [DisplayName("حق مسکن")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double HomeSalary { get; set; }


        [Required(ErrorMessage = "ایاب ذهاب را وارد نمائید")]
        [DisplayName("ایاب ذهاب")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double NavSalary { get; set; }

        [Required(ErrorMessage = "بن کارگری را وارد نمائید")]
        [DisplayName("بن کارگری")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double BonSalary { get; set; }

        [Required(ErrorMessage = "مبلغ اضافه کار ساعتی را وارد نمائید")]
        [DisplayName("مبلغ اضافه کار ساعتی")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double EzafehTimeSalary { get; set; }

        [Required(ErrorMessage = "مبلغ مرخصی را وارد نمائید")]
        [DisplayName("مبلغ مرخصی")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double RestSalary { get; set; }

        [Required(ErrorMessage = "مبلغ کسر مرخصی را وارد نمائید")]
        [DisplayName("مبلغ کسر مرخصی")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double KasrGheibat { get; set; }

        [Required(ErrorMessage = "سطح درآمد را وارد نمائید")]
        [DisplayName("سطح درآمد")]
        public string LevelPrice { get; set; }

        #endregion Properties
    }
}