using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreCrud.Pages
{
    public class IndexModel : PageModel
    {
        private CoreCrudContext _context;

        public IndexModel(CoreCrudContext context)
        {
            _context = context;
        }

        public ICollection<Country> Countries { get; set; }
        public ICollection<Destination> FlightServiceUnavailableDestinations { get; set; }
        public ICollection<Destination> ExpensiveDestinations { get; set; }
        public ICollection<Destination> NextYearDestinations { get; set; }

        public Dictionary<Country, int> DestCount = new Dictionary<Country, int>(); 
        public void OnGet()
        {
            Countries = _context.Country.OrderBy(est => est.Name).ToList();
            foreach(var i in Countries)
            {
                int DestinationCount = _context.Destination.Where(x => x.Location.Name == i.Name).Count();
                DestCount.Add(i, DestinationCount);
            }
            FlightServiceUnavailableDestinations = _context.Destination.Where(x => x.IsFlightServiceAvailable == false).ToList();
            ExpensiveDestinations = _context.Destination.Where(x => x.TotalFair > 400).ToList();
            NextYearDestinations = _context.Destination.Where(x => x.TravelDate > new DateTime(2019, 12, 31, 0, 0, 0)).ToList();
        }
    }
}
