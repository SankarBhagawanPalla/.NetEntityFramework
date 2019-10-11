using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibrarySystem.Pages
{
    public class IndexModel : PageModel
    {
        private LibrarySystemContext _context;

        public IndexModel(LibrarySystemContext context)
        {
            _context = context;
        }
        public ICollection<BorrowedBook> Borrowedbooks { get; set; }
        public void OnGet()
        {
            Borrowedbooks = _context.BorrowedBook
                                           .Where(x => x.BorrowedDate > new DateTime(2019, 1, 1, 0, 0, 0)
                                           .ToList();
                                            

        }
    }
}
