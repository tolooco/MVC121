using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC121.Models.Utility
{
    public class Years
    {
        public Years()
        {

        }

        public int ID { get; set; }
        public string Year { get; set; }

        /// <summary>
        /// ارتباط یک به چند با جدول پایه حقوق
        /// </summary>
        public virtual System.Collections.Generic.IList<BaseSalary> BaseSalaries { get; set; }

    }
}