using Cooking.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Models.BindModels.Site
{
    public class AddProductsBM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public int Measures { get; set; }
        
    }
}
