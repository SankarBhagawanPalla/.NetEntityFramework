using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CoreCrud.Pages
{
    public class CountryProfileModel : PageModel
    {
        private CoreCrudContext _context;

        public CountryProfileModel(CoreCrudContext context)
        {
            _context = context;
        }
        public Country country { get; set; }
        private int CountryId;
        public IActionResult OnGet(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            country = _context.Country
                                   .Include(est => est.Destinations)
                                   .FirstOrDefault(est => est.Id == Id);

            return Page();
        }
    }
}