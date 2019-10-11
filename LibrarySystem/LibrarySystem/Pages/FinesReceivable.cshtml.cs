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
    public class FinesReceivableModel : PageModel
    {
        private LibrarySystemContext _context;

        public FinesReceivableModel(LibrarySystemContext context)
        {
            _context = context;
        }
        public ICollection<BorrowedBook> Borrowedbooks { get; set; }
        public PageResult OnGet()
        {
            Borrowedbooks = _context.BorrowedBook
                                    .Include(m => m.Member)
                                    .Include(bc => bc.BookCopy)
                                    .ThenInclude(b => b.Book)
                                    .Where(bb => bb.Fine > 0)
                                    .ToList();

            return Page();
        }
    }
}