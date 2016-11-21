namespace MVC121.Helpers.Utilities
{
    public static class ApplicationSettings
    {
       
        // تعریف یک متغیر اینت یعنی متغییر نالیبله و در این صورت مجهز به یک پراپرتی هز ولیو میشود که یا تورو و یا فالس است
        private static int? _activateUserAfterRegistration;
        //تعریف متغیر استاتیک بولین بررسی اینکه آیا کاربر فعال هست یا خیر
        public static bool ActivateUserAfterRegistration
        {
            get
            {
                //اگر مقدار نداشت برو از وب کانفیگ بخون
                if (_activateUserAfterRegistration.HasValue == false)
                {
                    _activateUserAfterRegistration = 1;

                    try
                    {
                        _activateUserAfterRegistration =
                            System.Convert.ToInt32(ApplicationEdit.GetValue("ActivateUserAfterRegistration", "1"));
                    }
                    finally
                    {
                    }
                }

                //اگر مقدار یک داشت 
                if (_activateUserAfterRegistration.Value == 1)
                {
                    //تورو برمیگرداند
                    return (true);
                }
                else
                {
                    //فالس برمیگرداند
                    return (false);
                }
            }
        }
        //تعریف یک فیلد نالیبل برای اینکه زمان سرور رو بدست بیاوریم
        private static int? _serverTimeZoneDifference;
        //تعریف یک پراپرتی اینت استاتیک
        public static int ServerTimeZoneDifference
        {
            get
            {
                //اگر فیلد مقدار نداشت
                if (_serverTimeZoneDifference.HasValue == false)
                {
                    //زمان ریست میشود
                    _serverTimeZoneDifference = 0;
                    try
                    {
                        //با استفاده از گت ولیو زمان را بدست میاوریم
                        _serverTimeZoneDifference =
                            System.Convert.ToInt32(ApplicationEdit.GetValue("ServerTimeZoneDifference", "0"));
                    }
                        //خطا
                    catch { }
                }

                //ارسال زمان سرور به برنامه
                return (_serverTimeZoneDifference.Value);
            }
        }
       


    }
}