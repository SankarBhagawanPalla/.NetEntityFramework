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
    public class IndexModel : PageModel
    {
        private readonly LibrarySystem.Models.LibrarySystemContext _context;

        public IndexModel(LibrarySystem.Models.LibrarySystemContext context)
        {
            _context = context;
        }

        public IList<BorrowedBook> BorrowedBook { get;set; }

        public async Task OnGetAsync()
        {
            BorrowedBook = await _context.BorrowedBook
                .Include(b => b.Book)
                .Include(b => b.Member).ToListAsync();
        }
    }
}
