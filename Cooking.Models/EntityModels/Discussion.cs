using System;
using System.Collections.Generic;

namespace Cooking.Models.EntityModels
{
    public class Discussion
    {
        public Discussion()
        {
            this.Posts = new HashSet<Post>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual ApplicationUser Creator { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
