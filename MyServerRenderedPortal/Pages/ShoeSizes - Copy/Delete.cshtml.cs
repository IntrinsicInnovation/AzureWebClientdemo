using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyServerRenderedPortal.Data;
using MyServerRenderedPortal.Models;

namespace MyServerRenderedPortal.Pages.ShoeSizes
{
    public class DeleteModel : PageModel
    {
        private readonly MyServerRenderedPortal.Data.ShoeSizeContext _context;

        public DeleteModel(MyServerRenderedPortal.Data.ShoeSizeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ShoeSize ShoeSize { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShoeSize = await _context.ShoeSizes.FirstOrDefaultAsync(m => m.ID == id);

            if (ShoeSize == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShoeSize = await _context.ShoeSizes.FindAsync(id);

            if (ShoeSize != null)
            {
                _context.ShoeSizes.Remove(ShoeSize);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
