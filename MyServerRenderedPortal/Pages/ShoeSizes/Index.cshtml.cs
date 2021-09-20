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
    public class IndexModel : PageModel
    {
        private readonly MyServerRenderedPortal.Data.ShoeSizeContext _context;

        public IndexModel(MyServerRenderedPortal.Data.ShoeSizeContext context)
        {
            _context = context;
        }

        public IList<ShoeSize> ShoeSize { get;set; }

     //   [BindProperty]
       // public Course Course { get; set; }



        public async Task OnGetAsync()
        {
            ShoeSize = await _context.ShoeSizes.ToListAsync();
        }
    }
}
