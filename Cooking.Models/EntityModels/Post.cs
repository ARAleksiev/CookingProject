using System;
using System.Collections.Generic;

namespace Cooking.Models.EntityModels
{
    public class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public DateTime PostDate { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
