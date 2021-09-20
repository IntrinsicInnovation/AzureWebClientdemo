using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyServerRenderedPortal.Data;
using MyServerRenderedPortal.Models;

namespace MyServerRenderedPortal.Pages.Shoes
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
        public Shoe Shoe { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Shoes.Add(Shoe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
