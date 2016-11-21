using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC121.Models.Utility
{
    public class Mount
    {
        public Mount()
        {

        }

        public int ID { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// ارتباط یک به چند با جدول حقوق
        /// </summary>
        public virtual System.Collections.Generic.IList<Salary> Salaries { get; set; }
    }
}