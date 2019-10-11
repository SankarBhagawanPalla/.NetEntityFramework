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
    public class MemberandBorrowedBooksModel : PageModel
    {
        private LibrarySystemContext _context;

        public MemberandBorrowedBooksModel(LibrarySystemContext context)
        {
            _context = context;
        }
        public ICollection<Member> Members { get; set; }
        public PageResult OnGet()
        {

            Members = _context.Member
                                   .Include(est => est.BorrowedBooks)
                                   .ThenInclude(bb => bb.BookCopy)
                                   .ThenInclude(bc => bc.Book)
                                   .ToList();
            

            //var book = _context.Book
            //                    .Include(b => b.BookCopies)
            //                    .ThenInclude(bc => bc.borrowedBooks)
            //                    .ThenInclude(bb => bb.Member)
            //                    .ToList();


            return Page();

        }
    }
}