using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibrarySystem.Pages
{
    public class MemberSearchModel : PageModel
    {
        private LibrarySystemContext _context;

        public MemberSearchModel(LibrarySystemContext context)
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

        public ICollection<Member> SearchResults { get; set; }

        public void OnPost()
        {
            // PERFORM SEARCH
            if (string.IsNullOrWhiteSpace(search))
            {

                return;
            }
            SearchResults = _context.Member
                                    .Where(x => x.FirstName.ToLower().Contains(search.ToLower()))
                                    .OrderBy(x => x.FirstName)
                                    .ToList();



            SearchCompleted = true;
        }
    }
    
    
}