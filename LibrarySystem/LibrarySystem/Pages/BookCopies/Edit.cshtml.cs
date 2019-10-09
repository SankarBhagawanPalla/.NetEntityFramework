using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models;

namespace LibrarySystem.Pages.BookCopies
{
    public class EditModel : PageModel
    {
        private readonly LibrarySystem.Models.LibrarySystemContext _context;

        public EditModel(LibrarySystem.Models.LibrarySystemContext context)
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
           ViewData["BookId"] = new SelectList(_context.Book, "BookId", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookCopy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookCopyExists(BookCopy.BookCopyId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookCopyExists(int id)
        {
            return _context.BookCopy.Any(e => e.BookCopyId == id);
        }
    }
}
