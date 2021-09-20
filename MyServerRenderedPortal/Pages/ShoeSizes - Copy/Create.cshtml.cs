using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyServerRenderedPortal.Data;
using MyServerRenderedPortal.Models;

namespace MyServerRenderedPortal.Pages.ShoeSizes
{
    public class CreateModel : PageModel
    {
        private readonly MyServerRenderedPortal.Data.ShoeSizeContext _context;

        public CreateModel(MyServerRenderedPortal.Data.ShoeSizeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ShoeSize ShoeSize { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ShoeSizes.Add(ShoeSize);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
