using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Pages.BorrowedBooks
{
    public class CreateModel : PageModel
    {
        private readonly LibrarySystem.Models.LibrarySystemContext _context;

        public CreateModel(LibrarySystem.Models.LibrarySystemContext context)
        {
            _context = context;
        }
        public ICollection<BookCopy> BookCopies { get; set; }
        public IActionResult OnGet()
        {
            /*BookCopies = _context.BookCopy.Include(bc => bc.borrowedBooks).FromSql("SELECT * FROM BookCopy").ToList();*/
            BookCopies = _context.BookCopy.Include(bc => bc.borrowedBooks).ToList();
            /*BookCopies = _context.BookCopy.SqlQuery("SELECT * FROM dbo.Blogs").ToList();*/
            ViewData["BookCopyId"] = new SelectList(BookCopies, "BookCopyId", "BookCopyId");
            ViewData["MemberId"] = new SelectList(_context.Member, "MemberId", "IDNumber");
            return Page();
        }

        [BindProperty]
        public BorrowedBook BorrowedBook { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BorrowedBook.Add(BorrowedBook);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}