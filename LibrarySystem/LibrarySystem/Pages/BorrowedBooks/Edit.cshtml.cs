using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models;

namespace LibrarySystem.Pages.BorrowedBooks
{
    public class EditModel : PageModel
    {
        private readonly LibrarySystem.Models.LibrarySystemContext _context;

        public EditModel(LibrarySystem.Models.LibrarySystemContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id");
           ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BorrowedBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowedBookExists(BorrowedBook.BorrowedBookId))
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

        private bool BorrowedBookExists(int id)
        {
            return _context.BorrowedBook.Any(e => e.BorrowedBookId == id);
        }
    }
}
