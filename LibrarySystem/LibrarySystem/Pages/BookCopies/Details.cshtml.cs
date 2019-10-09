using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models;

namespace LibrarySystem.Pages.BookCopies
{
    public class DetailsModel : PageModel
    {
        private readonly LibrarySystem.Models.LibrarySystemContext _context;

        public DetailsModel(LibrarySystem.Models.LibrarySystemContext context)
        {
            _context = context;
        }

        public BookCopy BookCopy { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookCopy = await _context.BookCopy
                .Include(b => b.Book).FirstOrDefaultAsync(m => m.BookCopyId == id);

            if (BookCopy == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
