using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please provide a Country name")]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }
        [Display(Name = "Continent")]
        public string Continent { get; set; }
        [Range(0, 550, ErrorMessage = "Enter between 0 and 550")]
        [Display(Name = "USD Conversion rate")]
        public float USDConversionrate { get; set; }


        public ICollection<Destination> Destinations { get; set; }
    }
}
