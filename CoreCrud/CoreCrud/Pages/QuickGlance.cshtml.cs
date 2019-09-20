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
    public class QuickGlanceModel : PageModel
    {
        private CoreCrudContext _context;

        public QuickGlanceModel(CoreCrudContext context)
        {
            _context = context;
        }
        public ICollection<Destination> Destinations { get; set; }
        public void OnGet()
        {
            Destinations = _context.Destination.Include(x => x.Location).OrderBy(x => x.Location.Name).ToList();


        }
    }
}