using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Models.EntityModels
{
    public class Article
    {
        public Article()
        {
            this.Comments = new HashSet<Comment>();
            this.Images = new HashSet<string>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public string DirectoryCUID { get; set; }
        public ICollection<string> Images { get; set; }
    }
}
