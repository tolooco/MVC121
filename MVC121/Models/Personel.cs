using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC121.Models
{
    public class Personel
    {

        #region Ctor
        public Personel()
        {

        }

        #endregion Ctor

        #region Properties
        [Key]
        [Required]
        [DisplayName("شماره")]
        public int ID { get; set; }


        [DisplayName("شماره پرسنلی")]
        public int PID { get; set; }

        [DisplayName("کد ملی")]
        public int NID { get; set; }


        [Required(ErrorMessage = ("نام و نام خانوادگی را وارد نمایید"))]
        [StringLength(50, ErrorMessage = "این فیلد باید حداکثر ۵۰ کاراکتر باشد")]
        [TypeConverter("NVarchar(121)")]
        [DisplayName("نام و نام خانوادگی")]
        public string FullName { get; set; }


        [Required(ErrorMessage = ("رایانامه را وارد نمایید"))]
        [StringLength(100, ErrorMessage = "این فیلد باید حداکثر ۱۰۰ کاراکتر باشد")]
        [TypeConverter("NVarchar(121)")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        [DisplayName("رایانامه")]
        public string Email { get; set; }

        [Required(ErrorMessage = ("تاریخ تولد را وارد نمایید"))]
        [DisplayName("تاریخ تولد")]
        public Nullable<System.DateTime> BirthDate { get; set; }

        [Required(ErrorMessage = ("موبایل را وارد نمایید"))]
        [StringLength(100, ErrorMessage = "این فیلد باید حداکثر ۱۰۰ کاراکتر باشد")]
        [DisplayName("موبایل")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = ("شماره بانک را وارد نمایید"))]
        [StringLength(100, ErrorMessage = "این فیلد باید حداکثر ۱۰۰ کاراکتر باشد")]
        [DisplayName("شماره بانک")]
        public string BankID { get; set; }

        /// <summary>
        /// ارتباط یک به چند با جدول حقوق
        /// </summary>
        public virtual System.Collections.Generic.IList<Salary> Salaries { get; set; }

        #endregion Properties
    }
}