using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Models.EntityModels
{
    public class ReceptType
    {
        public ReceptType()
        {
            this.Recipes = new HashSet<Recipe>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
