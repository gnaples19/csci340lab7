using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Testsite.Data;
using Testsite.Models;

namespace Testsite.Pages.Motorcycles
{
    public class DetailsModel : PageModel
    {
        private readonly Testsite.Data.TestsiteContext _context;

        public DetailsModel(Testsite.Data.TestsiteContext context)
        {
            _context = context;
        }

        public Motorcycle Motorcycle { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Motorcycle = await _context.Motorcycle.FirstOrDefaultAsync(m => m.ID == id);

            if (Motorcycle == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
