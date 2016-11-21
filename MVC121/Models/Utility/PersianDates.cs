using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace MVC121.Models.Utility
{
    public static class PersianDates
    {
        public static DateTime ToPersian(this DateTime dateTime)
        {
            PersianCalendar PC = new PersianCalendar();
            int intYear = PC.GetYear(dateTime);
            int intMonth = PC.GetMonth(dateTime);
            int intDay = PC.GetDayOfMonth(dateTime);
            int intHour = PC.GetHour(dateTime);
            int intMinute = PC.GetMinute(dateTime);

            return new DateTime(intYear, intMonth, intDay, intHour, intMinute, 0);
        }

        public static DateTime ToMiladi(this DateTime dateTime)
        {
            PersianCalendar PC = new PersianCalendar();

            return PC.ToDateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0, 0);
        }

        public static PersianDateTime ToPersianDateTime(this DateTime dateTime)
        {
            return new PersianDateTime(dateTime);
        }

        public static PersianDateTime ToPersianDateTime(this string dateTime)
        {
            return new PersianDateTime(Convert.ToDateTime(dateTime));
        }
    }
}