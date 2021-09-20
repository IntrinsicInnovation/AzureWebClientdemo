using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyServerRenderedPortal.Data;
using MyServerRenderedPortal.Models;

namespace MyServerRenderedPortal.Pages.Shoes
{
    public class EditModel : ShoePageModel
    {
        private readonly MyServerRenderedPortal.Data.ShoeSizeContext _context;

        public EditModel(MyServerRenderedPortal.Data.ShoeSizeContext context)
        {
            _context = context;
        }

        [BindProperty]
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

            PopulateShoeSizesDropDownList(_context, Shoe.ShoeSizeID);


            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Shoe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoeExists(Shoe.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return RedirectToPage("../Index");
        }

        private bool ShoeExists(int id)
        {
            return _context.Shoes.Any(e => e.ID == id);
        }
    }
}
