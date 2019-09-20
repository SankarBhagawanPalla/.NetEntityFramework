﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }

        public float USDConversionrate { get; set; }


        public ICollection<Destination> Destinations { get; set; }
    }
}
