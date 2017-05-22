using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Models.BindModels.Site
{
    public class EditDelCookStep
    {
        [Required]
        public int RecipeId { get; set; }
        [Required]
        public int CookStepId { get; set; }
    }
}
