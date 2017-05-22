using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Cooking.Models.BindModels.Site
{
    public class CookStepBM
    {
        [Required]
        public int RecipeId { get; set; }
        [Required]
        public string Description { get; set; }
        public HttpPostedFileBase fileUpload { get; set; }
    }
}
