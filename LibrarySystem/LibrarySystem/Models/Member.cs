using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        [Required(ErrorMessage = "Please enter Identification Number")]
        [StringLength(20)]
        [Display(Name = "ID Number")]
        public string IDNumber { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [StringLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required (ErrorMessage = "Please enter last name")]
        [StringLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Type")]
        public string Type { get; set; }
        [Display(Name = "Department")]
        public string Department { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "Please Enter Date of birth")]
        public DateTime DateOfBirth { get; set; }
        [EmailAddress(ErrorMessage = "Please provide a valid Email")]
        [Required(ErrorMessage = "Please provide a Email Address")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        public ICollection<BorrowedBook> BorrowedBooks { get; set; }

        

    }
}
