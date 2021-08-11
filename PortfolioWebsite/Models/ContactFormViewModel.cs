using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BartlomiejJagielloLab4ZadDom.Models
{
    // View used to contact the portfolio owner
    public class ContactFormViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        
        [Display(Name = "E-mail")]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Text")]
        public string Text { get; set; }
    }
}
