using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Cooking.Models.BindModels.Site
{
    public class NewRecipeBM
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int SelectedTypesId { get; set; }

        public string Country { get; set; }

        public HttpPostedFileBase fileUpload { get; set; }

        [Required]
        public int CookingHour { get; set; }

        [Required]
        public int CookingMinutes { get; set; }

        [Required]
        public int Serves { get; set; }
    }
}
