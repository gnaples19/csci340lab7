using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Testsite.Data;
using Testsite.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Testsite.Pages.Motorcycles
{
    public class IndexModel : PageModel
    {
        private readonly Testsite.Data.TestsiteContext _context;

        public IndexModel(Testsite.Data.TestsiteContext context)
        {
            _context = context;
        }

        public IList<Motorcycle> Motorcycle { get;set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Motorcycle
                                            orderby m.Type
                                            select m.Type;

            var motorcycles = from m in _context.Motorcycle
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                motorcycles = motorcycles.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MotorcycleType))
            {
                motorcycles = motorcycles.Where(x => x.Type == MotorcycleType);
            }
            Types = new SelectList(await genreQuery.Distinct().ToListAsync());
            Motorcycle = await motorcycles.ToListAsync();
        }

        public IList<Motorcycle> Motorcycles { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Types { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MotorcycleType { get; set; }
    }
}
