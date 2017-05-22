using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Models.BindModels.Site
{
    public class EditDelProductBM
    {
        [Required]
        public int recipeid { get; set; }

        [Required]
        public int productid { get; set; }
    }
}
