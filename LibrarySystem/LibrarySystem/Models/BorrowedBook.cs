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
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        /*Independent Variables*/
        [DataType(DataType.Date)]
        public DateTime? BorrowedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ActualReturnDate { get; set; }
        
    }
}
