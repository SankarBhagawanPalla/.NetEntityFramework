using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibrarySystem.Pages
{
    public class AddBookCopyFormModel : PageModel
    {
        private LibrarySystemContext _context;

        public AddBookCopyFormModel(LibrarySystemContext context)
        {
            _context = context;
        }
        
        [BindProperty]
        public BookCopy bookCopy { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            bookCopy = new BookCopy();
            bookCopy.BookId = id.Value;
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var boCOpy = new BookCopy();
            boCOpy.BookId = bookCopy.BookId;
            boCOpy.DateOfArrival = bookCopy.DateOfArrival;
            boCOpy.Price = bookCopy.Price;
            boCOpy.BookAisleLocation = bookCopy.BookAisleLocation;
            _context.BookCopy.Add(boCOpy);
            await _context.SaveChangesAsync();

            return RedirectToPage("BookCopies/Index");
        }
    }
}