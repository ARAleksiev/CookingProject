using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Models.EntityModels
{
    public class Favorite
    {
        public int Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
