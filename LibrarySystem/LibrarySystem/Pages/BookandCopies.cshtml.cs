using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Pages
{
    public class BookandCopiesModel : PageModel
    {
        private LibrarySystemContext _context;

        public BookandCopiesModel(LibrarySystemContext context)
        {
            _context = context;
        }
        public ICollection<Book> Books { get; set; }
        public PageResult OnGet()
        {
            Books = _context.Book
                            .Include(b => b.BookCopies)
                            .ThenInclude(bc => bc.borrowedBooks)
                            .ThenInclude(bb => bb.Member)
                            .ToList();
            return Page();

        }
    }
}