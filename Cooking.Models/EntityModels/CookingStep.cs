using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Models.EntityModels
{
    public class CookingStep
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public virtual Recipe Recept { get; set; }
    }
}
