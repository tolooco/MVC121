using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC121.Models
{
    public class ProductCategory
    {

        #region Properties
        [Key, Required(ErrorMessage = "آی دی راوارد نمائید")
        , DatabaseGenerated(DatabaseGeneratedOption.None)
        , DisplayName("آی دی گروه محصول")]
        public int ID { get; set; }

        [Required(ErrorMessage = ("گروه محصول را وارد نمائید")), MaxLength(121)
           , Column(TypeName = "NVarchar"), DisplayName("گروه محصول")]
        public string Title { get; set; }
        #endregion Properties


        #region Relation
        [DisplayName("محصولات")]
        public virtual IList<Product> Products { get; set; }
        #endregion Relation



    }
}