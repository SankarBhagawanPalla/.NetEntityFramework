using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibrarySystem.Models;

namespace LibrarySystem.Pages.BorrowedBooks
{
    public class CreateModel : PageModel
    {
        private readonly LibrarySystem.Models.LibrarySystemContext _context;

        public CreateModel(LibrarySystem.Models.LibrarySystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id");
        ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Id");
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