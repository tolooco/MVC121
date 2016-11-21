namespace MVC121.Helpers.Utilities
{
    public static class ApplicationEdit
    {
		//متد گت ولیو
        public static string GetValue(string key)
        {
            //برگرداندن متد دوم کلاس جاری
            return (GetValue(key, string.Empty));
        }

        /// <remarks>
        /// متد گت ولیو با دو پارامتر رشته ای کی و ولیو
        /// </remarks>
        public static string GetValue(string key, string defaultValue)
        {
            //اگر دیفالت ولیو نال بود امپتی رو برمیگردونه
            if (defaultValue == null)
            {
                defaultValue = string.Empty;
            }
            //در غیر اینصورت مقدارشو تریم میکنه برمیگردونه
            else
            {
                defaultValue = defaultValue.Trim();
            }

            //اگر کلید نال بود دیفالت ولیو رو برمیگردونیم
            if (key == null)
            {
                return (defaultValue);
            }

            key = key.Trim();

            //اگر کلید امپتی بود دیفالت ولیو رو برمیگردونیم
            if (key == string.Empty)
            {
                return (defaultValue);
            }

            try
            {
                string strData =
                    System.Configuration.ConfigurationManager.AppSettings[key];

                //اگر مقدار ولیو نال یا نال استرینگ بود بازم دیفالت ولیو رو برمیگردونه
                if (string.IsNullOrEmpty(strData))
                {
                    return (defaultValue);
                }

                return (strData.Trim());
            }
            catch
            {
                return (defaultValue);
            }
        }
    }
}
