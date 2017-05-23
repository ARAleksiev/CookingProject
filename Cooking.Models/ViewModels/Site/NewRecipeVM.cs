using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Cooking.Models.ViewModels.Site
{
    public class NewRecipeVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Dir { get; set; }

        [Display(Name = "Picture")]
        public string ProfilImgGUID { get; set; }
        public IEnumerable<RecipeTypeVM> Types { get; set; }
        [Display(Name = "Country/Region")]
        public string Country { get; set; }

        [Display(Name = "Foot Category")]
        public int SelectedTypesId { get; set; }

        public IEnumerable<SelectListItem> RecTypes
        {
            get { return new SelectList(Types, "Id", "Name"); }
        }

        [RegularExpression("[0-9]{1,}")]
        [Display(Name = "hours")]
        public int CookingHour { get; set; }

        [Range(0, 59, ErrorMessage = "Can only be between 0 .. 15")]
        [Display(Name = "minutes")]
        public int CookingMinutes { get; set; }

        [Range(1,50)]
        [Display(Name = "Serves")]
        public int Serves { get; set; }

    }
}
