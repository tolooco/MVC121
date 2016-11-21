using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC121.Areas.Administrator.ViewModels
{
    public class AdminViewModels
    {
        public MVC121.Areas.Administrator.Models.Admin Admin { get; set; }

        public IList<MVC121.Areas.Administrator.Models.PostCategory> PostCaegories { get; set; }
        public IList<MVC121.Areas.Administrator.Models.Post> Posts { get; set; }
        public IList<MVC121.Areas.Administrator.Models.Comment> Comments { get; set; }

        public IList<MVC121.Models.PriceType> Prices { get; set; }

        public IList<MVC121.Models.ApplicationUser> Users { get; set; }
    }
}