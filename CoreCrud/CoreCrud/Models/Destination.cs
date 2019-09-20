using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        [DataType(DataType.Date)]
        public DateTime? TravelDate { get; set; }
        public bool IsFlightServiceAvailable { get; set; }
        public decimal TotalFair { get; set; }

        public int Rating
        {
            get
            {
                if (TotalFair < 150)
                {
                    return 5;
                }
                if (150 <= TotalFair && TotalFair < 250)
                {
                    return 4;
                }
                if (250 <= TotalFair && TotalFair < 300)
                {
                    return 3;
                }
                if (300 <= TotalFair && TotalFair < 350)
                {
                    return 2;
                }
                if (350 <= TotalFair)
                {
                    return 1;
                }
                return 0;
            }
        }
        public int LocationId { get; set; }
        public Country Location { get; set; }

    }
}
