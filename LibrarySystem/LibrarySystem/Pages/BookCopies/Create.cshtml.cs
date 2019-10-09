using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibrarySystem.Models;

namespace LibrarySystem.Pages.BookCopies
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
        ViewData["BookId"] = new SelectList(_context.Book, "BookId", "Name");
            return Page();
        }

        [BindProperty]
        public BookCopy BookCopy { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BookCopy.Add(BookCopy);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}