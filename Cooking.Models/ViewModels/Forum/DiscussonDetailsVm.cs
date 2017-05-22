using Cooking.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Models.ViewModels.Forum
{
    public class DiscussonDetailsVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public UserVm User { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
