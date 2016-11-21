using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVC121.Areas.Administrator.Models
{
    public class DownLoadFileInformation
    {

        public DownLoadFileInformation()
        {

        }

        [DisplayName("شماره فایل")]
        [Display(Name = "شماره فایل")]
        [Key]
        public int FileID { get; set; }

        [DisplayName("نام فایل")]
        [Display(Name = "نام فایل")]
        public string FilePathName { get; set; }

        [DisplayName("فایل VIP است؟")]
        [Display(Name = "فایل VIP است؟")]
        public bool IsVIP { get; set; }

        [DisplayName(" فایل فروشی است؟")]
        [Display(Name = "فایل فروشی است؟ ")]
        public bool IsPaymentUser { get; set; }

        [DisplayName("قیمت فایل")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? PriceFile { get; set; }

        //این پراپرتی در دیتا بیس ثبت نمیگردد و برای مشخص نمودن حجم فایل است
        [NotMapped]
        public string Length { get; set; }

    }
}