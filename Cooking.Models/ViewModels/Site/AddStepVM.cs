using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Models.ViewModels.Site
{
    public class AddStepVM
    {
        public int RecipeId { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
    }
}
