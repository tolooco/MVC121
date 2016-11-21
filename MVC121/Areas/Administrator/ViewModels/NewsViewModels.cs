using MVC121.Areas.Administrator.Models;
using MVC121.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC121.Areas.Administrator.ViewModels
{
    public class NewsViewModels
    {
        public NewsViewModels()
        {

        }

        public IList<ApplicationUser> Users { get; set; }
        public NewsLetter NewsLetter { get; set; }

    }
}