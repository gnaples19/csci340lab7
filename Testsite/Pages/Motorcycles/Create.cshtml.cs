using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Testsite.Data;
using Testsite.Models;

namespace Testsite.Pages.Motorcycles
{
    public class CreateModel : PageModel
    {
        private readonly Testsite.Data.TestsiteContext _context;

        public CreateModel(Testsite.Data.TestsiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Motorcycle Motorcycle { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Motorcycle.Add(Motorcycle);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
