using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC121.Areas.Administrator.ViewModels
{
    public class AdminNewsViewModels
    {
        public AdminNewsViewModels()
        {

        }

        public AdminViewModels AdminViewModel { get; set; }

        public NewsViewModels  NewsViewModel { get; set; }

        public MVC121.Areas.Administrator.Models.UserContact UserContact { get; set; }

    }
}