using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Models.EntityModels
{
    public class Recipe
    {
        public Recipe()
        {
            this.Comments = new HashSet<Comment>();
            this.Products = new HashSet<Product>();
            this.Steps = new HashSet<CookingStep>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public double Rating { get; set; }
        public virtual ReceptType Type { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CookingStep> Steps { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public string ProfilImg{ get; set; }
        public string DirectoryCUID { get; set; }
        public string Country { get; set; }
        public int Serves { get; set; }
        public int CookingHour { get; set; }
        public int CookingMinutes { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
