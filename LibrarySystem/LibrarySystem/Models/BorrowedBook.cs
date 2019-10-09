using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class BorrowedBook
    {
        public int BorrowedBookId { get; set; }
        /*Relationships*/
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int BookCopyId { get; set; }
        public BookCopy BookCopy { get; set; }

        [Required(ErrorMessage = "Borrowed date is mandatory")]
        [DataType(DataType.Date)]
        [Display(Name = "Borrowed Date")]
        public DateTime BorrowedDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Actual Return Date")]
        [CustomValidation(typeof(BorrowedBook), "VaidateActualReturnDate")]
        public DateTime? ActualReturnDate { get; set; }

        public DateTime ReturnDate
        {
        get{
                return BorrowedDate.AddDays(15);
           }
        }
        public double Fine
        {
            get
            {
                if(DateTime.Today > ReturnDate)
                {
                    int noofdays = (DateTime.Today - ReturnDate.Date).Days;
                    return (noofdays) * 0.5;

                }
                return 0;
            }
        }
        public static ValidationResult VaidateActualReturnDate(DateTime? actualReturnDate, ValidationContext context)
        {
            if(actualReturnDate == null)
            {
                return ValidationResult.Success;
            }
            var instance = context.ObjectInstance as BorrowedBook;
            if (instance.BorrowedDate <= actualReturnDate)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(errorMessage: $"Actual Return date cannot be before borrowed date");
        }
    }
}
