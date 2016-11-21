namespace MVC121.Helpers.Utilities
{
    public static class Email
    {
        //#######################################################################

        //متد ارسال ایمیل بعد از ثبت نام
        public static void SendEmailAfterRegistration
            (string userId,string userName, string password, string code)
        {
            //استفاده از قالب موجود در ای پی پی دیتا
            string strRootRelativePathName =
                "~/App_Data/LocalizedEmailTemplates/UserEmailVerification.htm";

            //ایجاد یک رشته و مراحل تبدیل مراحل نسبی به فیزیکی
            string strPathName =
                System.Web.HttpContext.Current.Server.MapPath(strRootRelativePathName);

            //استفاده از متد رید کلاس فایل برای خواندن مسیر فیزیکی
            string strEmailBody = File.Read(strPathName);

            //جایگزینی مقادیر موجود در فایل خوانده شده با مقادیر داده شده
            strEmailBody = strEmailBody
                            .Replace("[USER_ID]", userId)
                            .Replace("[USER_NAME]", userName)
                            .Replace("[PASSWORD]", password)
                            .Replace("[CODE]", code);
            //ایجاد یک شی از میل آدرس با 3 پارامتر
            System.Net.Mail.MailAddress oMailAddress =
                new System.Net.Mail.MailAddress(userName, userName, System.Text.Encoding.UTF8);
            //استفاده از متد سند کلاس میل مسیج
            MailMessage.Send
                (oMailAddress, "تائید رایانامه!", strEmailBody, System.Net.Mail.MailPriority.High);
        }


        //#######################################################################


        /// متد ارسال کلید تائید به کاربراگر هنگام ثبت نام عمل تائیدیه انجام نشد و اقدام به لاگین نمود
        public static void Sendcode(string userId,string userName, string code)
        {
            SendEmailAfterRegistration(userId,userName,"", code);
        }

        //#######################################################################


        //متد ارسال ایمیل فراموشی گذرواژه
        public static void SendEmailForgotPassword
            (string userId, string userName, string code)
        {
            //استفاده از قالب موجود در ای پی پی دیتا
            string strRootRelativePathName =
                "~/App_Data/LocalizedEmailTemplates/ForgotPasswordUserEmail.htm";

            //ایجاد یک رشته و مراحل تبدیل مراحل نسبی به فیزیکی
            string strPathName =
                System.Web.HttpContext.Current.Server.MapPath(strRootRelativePathName);

            //استفاده از متد رید کلاس فایل برای خواندن مسیر فیزیکی
            string strEmailBody = File.Read(strPathName);

            //جایگزینی مقادیر موجود در فایل خوانده شده با مقادیر داده شده
            strEmailBody = strEmailBody
                            .Replace("[USER_ID]", userId)
                            .Replace("[USER_NAME]", userName)
                            .Replace("[CODE]", code);
            //ایجاد یک شی از میل آدرس با 3 پارامتر
            System.Net.Mail.MailAddress oMailAddress =
                new System.Net.Mail.MailAddress(userName,userName, System.Text.Encoding.UTF8);
            //استفاده از متد سند کلاس میل مسیج
            MailMessage.Send
                (oMailAddress, "بازیابی گذرواژه!", strEmailBody, System.Net.Mail.MailPriority.High);
        }

        //#######################################################################
        //متد ارسال خبرنامه
        public static void SendNewsLetter
            (string userId, string email,string category,string name,string content)
        {
            //استفاده از قالب موجود در ای پی پی دیتا
            string strRootRelativePathName =
                "~/App_Data/LocalizedEmailTemplates/News.htm";

            //ایجاد یک رشته و مراحل تبدیل مراحل نسبی به فیزیکی
            string strPathName =
                System.Web.HttpContext.Current.Server.MapPath(strRootRelativePathName);

            //استفاده از متد رید کلاس فایل برای خواندن مسیر فیزیکی
            string strEmailBody = File.Read(strPathName);

            //جایگزینی مقادیر موجود در فایل خوانده شده با مقادیر داده شده
            strEmailBody = strEmailBody
                            .Replace("[USER_NAME]", email)
                            .Replace("[CAT]", category)
                            .Replace("[NAME]", name)
                            .Replace("[CONTENT]", content);
            //ایجاد یک شی از میل آدرس با 3 پارامتر
            System.Net.Mail.MailAddress oMailAddress =
                new System.Net.Mail.MailAddress(email,email,System.Text.Encoding.UTF8);
            //استفاده از متد سند کلاس میل مسیج
            MailMessage.Send
                (oMailAddress, "خبرنامه!", strEmailBody,System.Net.Mail.MailPriority.High);
        }

        //#######################################################################

        //متد ارسال تماس با ما
        public static void SendContact
            (string name, string email, string subject, string message)
        {
            //استفاده از قالب موجود در ای پی پی دیتا
            string strRootRelativePathName =
                "~/App_Data/LocalizedEmailTemplates/Contact.htm";

            //ایجاد یک رشته و مراحل تبدیل مراحل نسبی به فیزیکی
            string strPathName =
                System.Web.HttpContext.Current.Server.MapPath(strRootRelativePathName);

            //استفاده از متد رید کلاس فایل برای خواندن مسیر فیزیکی
            string strEmailBody = File.Read(strPathName);

            //جایگزینی مقادیر موجود در فایل خوانده شده با مقادیر داده شده
            strEmailBody = strEmailBody
                            .Replace("[NAME]", name)
                            .Replace("[MAIL]", email)
                            .Replace("[SUBJECT]", subject)
                            .Replace("[MESSAGE]", message);
            //ایجاد یک شی از میل آدرس با 3 پارامتر
            System.Net.Mail.MailAddress oMailAddress =
                new System.Net.Mail.MailAddress(email,email,System.Text.Encoding.UTF8);
            //استفاده از متد سند کلاس میل مسیج
            MailMessage.Send
                (oMailAddress, "تماس با ما!", strEmailBody, System.Net.Mail.MailPriority.High);
        }

        //#######################################################################

    }

}