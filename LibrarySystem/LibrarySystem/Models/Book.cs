using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Book
    {
        public int Id { get; set; }
        public DateTime DateOfArrival { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public string Description { get; set; }

    }
}
