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
        public int LocationId { get; set; }
        public Country Location { get; set; }

    }
}
