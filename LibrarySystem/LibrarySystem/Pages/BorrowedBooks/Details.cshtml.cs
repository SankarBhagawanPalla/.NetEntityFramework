using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models;

namespace LibrarySystem.Pages.BorrowedBooks
{
    public class DetailsModel : PageModel
    {
        private readonly LibrarySystem.Models.LibrarySystemContext _context;

        public DetailsModel(LibrarySystem.Models.LibrarySystemContext context)
        {
            _context = context;
        }

        public BorrowedBook BorrowedBook { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BorrowedBook = await _context.BorrowedBook
                .Include(b => b.Book)
                .Include(b => b.Member).FirstOrDefaultAsync(m => m.BorrowedBookId == id);

            if (BorrowedBook == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
