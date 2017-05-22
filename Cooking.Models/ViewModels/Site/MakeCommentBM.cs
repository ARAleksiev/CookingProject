using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Models.ViewModels.Site
{
    public class MakeCommentBM
    {
        [Required]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false)]

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Content { get; set; }
    }
}
