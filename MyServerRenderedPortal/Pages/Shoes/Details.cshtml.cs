using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyServerRenderedPortal.Data;
using MyServerRenderedPortal.Models;

namespace MyServerRenderedPortal.Pages.Shoes
{
    public class DetailsModel : PageModel
    {
        private readonly MyServerRenderedPortal.Data.ShoeSizeContext _context;

        public DetailsModel(MyServerRenderedPortal.Data.ShoeSizeContext context)
        {
            _context = context;
        }

        public Shoe Shoe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Shoe = await _context.Shoes.FirstOrDefaultAsync(m => m.ID == id);

            if (Shoe == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
