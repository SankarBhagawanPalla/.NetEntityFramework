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
    public class BookBorrowalHistoryModel : PageModel
    {

        private LibrarySystemContext _context;

        public BookBorrowalHistoryModel(LibrarySystemContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            SearchCompleted = false;
        }
        [BindProperty]
        public string search { get; set; }

        public bool SearchCompleted { get; set; }

        public ICollection<Book> SearchResults { get; set; }

        public void OnPost()
        {
            // PERFORM SEARCH
            if (string.IsNullOrWhiteSpace(search))
            {
                
                return;
            }
            SearchResults = _context.Book
                                    .Include(x => x.BookCopies)
                                    .ThenInclude(bc => bc.borrowedBooks)
                                    .ThenInclude(bb => bb.Member)
                                    .Where(x => x.Name.ToLower().Equals(search.ToLower()))
                                    .OrderBy(x => x.Name)
                                    .ToList();
                                    

            
            SearchCompleted = true;
        }
    }
}