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
        [Display(Name = "H:")]
        public int CookingHour { get; set; }

        [Display(Name ="m:")]
        public int CookingMinutes { get; set; }

    }
}
