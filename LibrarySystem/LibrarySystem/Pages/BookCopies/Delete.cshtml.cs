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
    public class DeleteModel : PageModel
    {
        private readonly LibrarySystem.Models.LibrarySystemContext _context;

        public DeleteModel(LibrarySystem.Models.LibrarySystemContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookCopy = await _context.BookCopy.FindAsync(id);

            if (BookCopy != null)
            {
                _context.BookCopy.Remove(BookCopy);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
