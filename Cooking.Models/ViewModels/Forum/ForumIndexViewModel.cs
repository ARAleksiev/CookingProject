using System;
using System.Collections.Generic;
using Cooking.Models.EntityModels;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Models.ViewModels.Forum
{
    public class ForumIndexViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public int PostCount { get; set; }
    }
}
