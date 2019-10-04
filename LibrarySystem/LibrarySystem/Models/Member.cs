using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        /*Add Borrowed Books*/
        public string EmailAddress { get; set; }

    }
}
