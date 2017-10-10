using Cooking.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Models.ViewModels.Site
{
    public class IndexVM
    {
        public IEnumerable<SliderVM> RecipesCollections { get; set; }
    }
}
