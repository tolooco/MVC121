namespace MVC121.Helpers.Utilities
{
    public static class Utility
    {
        /// <remarks>
        /// زمان جاری سرور تایم زون را بدست میاوریم
        /// </remarks>
        public static System.DateTime GetNow()
        {
            return (System.DateTime.Now.AddMinutes
                (ApplicationSettings.ServerTimeZoneDifference));
        }

        /// <remarks>
        /// متد ذیل یک تاریخ را به عنوان چک پوینت مشخص میکند
        /// </remarks>
        public static System.DateTime GetMinDateTime()
        {
            return (new System.DateTime(1981, 1, 21));
        }

        /// <remarks>
        /// متد ذیل یک جی یو آی دی برمیگرداند
        /// </remarks>
        public static string GetGuid()
        {
            return (System.Guid.NewGuid().ToString());
        }

        /// <remarks>
        /// متد ذیل یک جی یو آی دی بدون دش برمیگرداند
        /// </remarks>
        public static string GetGuidWithoutDash()
        {
            return (GetGuid().Replace("-", string.Empty));
        }

        /// <remarks>
        /// متد ذیل یک رشته میگیرد و با الگوریتم اس اچ ای وان رمز گزاری میکند
        /// </remarks>
        public static string GetSha1(string value)
        {
            if (value == null)
            {
                return (string.Empty);
            }

            value = value.Trim();
            if (value == string.Empty)
            {
                return (string.Empty);
            }

            return (System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(value, "SHA1"));
        }

        /// <remarks>
        /// متد ذیل یک رشته میگیرد و با الگوریتم ام دی فایو رمز گزاری میکند
        /// </remarks>
        public static string GetMd5(string value)
        {
            if (value == null)
            {
                return (string.Empty);
            }

            value = value.Trim();
            if (value == string.Empty)
            {
                return (string.Empty);
            }

            return (System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(value, "MD5"));
        }
    }
}