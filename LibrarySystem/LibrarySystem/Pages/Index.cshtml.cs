using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibrarySystem.Pages
{
    public class IndexModel : PageModel
    {
        private LibrarySystemContext _context;

        public IndexModel(LibrarySystemContext context)
        {
            _context = context;
        }
        public ICollection<BorrowedBook> Borrowedbooks { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<BookCopy> BookCopies { get; set; }
        public ICollection<Member> Members { get; set; }


        public void OnGet()
        {
            Borrowedbooks = _context.BorrowedBook.ToList();
            Books = _context.Book.ToList();
            BookCopies = _context.BookCopy.ToList();
            Members = _context.Member.ToList();



        }
    }
}
