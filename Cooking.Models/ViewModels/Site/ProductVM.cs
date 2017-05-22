using Cooking.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Models.ViewModels.Site
{
     public class ProductVM
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public Measures Measures { get; set; }

    }
}
