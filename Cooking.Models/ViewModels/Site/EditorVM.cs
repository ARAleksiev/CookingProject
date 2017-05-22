using Cooking.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Models.ViewModels.Site
{
     public class EditorVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ReceptType Type { get; set; }
        public string ProfilImg { get; set; }
        public string DirectoryCUID { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<CookingStep> Steps { get; set; }
        public string Country { get; set; }
    }
}
