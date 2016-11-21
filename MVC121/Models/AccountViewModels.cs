using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC121.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage ="تکمیل فیلد رایانامه الزامی است")]
        [Display(Name = "رایانامه")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required(ErrorMessage = "تکمیل فیلد پرووایدر الزامی است")]
        public string Provider { get; set; }

        [Required(ErrorMessage = "تکمیل فیلد کد الزامی است")]
        [Display(Name = "کد")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "مرور گر را به خاطر بسپار؟")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessage = "تکمیل فیلد رایانامه الزامی است")]
        [Display(Name = "رایانامه")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "تکمیل فیلد رایانامه الزامی است")]
        [Display(Name = "رایانامه")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "تکمیل فیلد گذرواژه الزامی است")]
        [DataType(DataType.Password)]
        [Display(Name = "گذرواژه")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار؟")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "تکمیل فیلد رایانامه الزامی است")]
        [EmailAddress]
        [Display(Name = "رایانامه")]
        public string Email { get; set; }

        [Required(ErrorMessage = "تکمیل فیلد گذرواژه الزامی است")]
        [StringLength(100, ErrorMessage = "گذرواژه حداقل 6 کاراکتر باید باشد.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "گذرواژه")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تائید گذرواژه")]
        [Compare("Password", ErrorMessage = "گذرواژه و تائید آن یکسان نیست.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "تکمیل فیلد رایانامه الزامی است")]
        [EmailAddress]
        [Display(Name = "رایانامه")]
        public string Email { get; set; }

        [Required(ErrorMessage = "تکمیل فیلد گذرواژه الزامی است")]
        [StringLength(100, ErrorMessage = " گذرواژه حداقل 6 کاراکتر باید باشد.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "گذرواژه")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تائید گذرواژه")]
        [Compare("Password", ErrorMessage = " گذرواژه و تائید آن یکسان نیست.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "تکمیل فیلد رایانامه الزامی است")]
        [EmailAddress]
        [Display(Name = "رایانامه")]
        public string Email { get; set; }
    }
}
