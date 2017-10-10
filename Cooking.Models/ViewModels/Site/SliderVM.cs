using Cooking.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Models.ViewModels.Site
{
    public class SliderVM
    {
        public string Heading { get; set; }
        public ICollection<Recipe> First { get; set; }
        public ICollection<Recipe> Second { get; set; }
    }
}
