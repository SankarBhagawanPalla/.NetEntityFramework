using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate_Listing.Models
{
    public class Property
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime? SoldDate { get; set; }
        public string SoldTo { get; set; }

        public string IsPropertySold
        {
            get
            {
                if( SoldDate != null)
                {
                    return "No";
                }
                else
                {
                    return "Yes";
                }
            }
        }
    }
}
