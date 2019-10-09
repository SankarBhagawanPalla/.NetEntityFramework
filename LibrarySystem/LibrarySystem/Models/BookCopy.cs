using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class BookCopy
    {
        [Display(Name ="Copy ID")]
        public int BookCopyId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter date of arrival")]
        [Display(Name = "Date of Arrival")]
        [CustomValidation(typeof(BookCopy), "VaidateArrivalDate")]
        public DateTime DateOfArrival { get; set; }
        [Required(ErrorMessage = "Please enter price of the book copy")]
        [Display(Name = "Price")]
        [Range(0, 500)]
        public long Price { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.-]{5}$")]
        [Display(Name = "Aisle Location")]
        public string BookAisleLocation { get; set; }
        public ICollection<BorrowedBook> borrowedBooks { get; set; }

        public string rating
        {
            get
            {
                if(0 <= Price && Price <= 50)
                {
                return "Economical";
                }
                if(51 <= Price && Price <= 100)
                {
                return "Reasonable"; 
                }
                return "Expensive";
            }

        }
        public static ValidationResult VaidateArrivalDate(DateTime arrivalDate, ValidationContext context)
        {
            if (arrivalDate <= DateTime.Today)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(errorMessage: $"Arrival date cannot be in future");
        }
    }
        
    
}
