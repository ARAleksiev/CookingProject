using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Models.EntityModels
{
    public class Vote
    {
        public int Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Recipe Recept { get; set; }
    }
}
