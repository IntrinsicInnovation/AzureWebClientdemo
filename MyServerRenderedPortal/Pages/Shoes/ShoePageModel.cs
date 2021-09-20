using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MyServerRenderedPortal.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;



namespace MyServerRenderedPortal.Pages.Shoes
{
    public class ShoePageModel : PageModel
    { 
    
        public SelectList ShoeSizeSL { get; set; }

        public void PopulateShoeSizesDropDownList(ShoeSizeContext  _context,
            object selectedShoeSize = null)
        {
            var ssQuery = from ss in _context.ShoeSizes 
                                   select ss;

            ShoeSizeSL = new SelectList(ssQuery.AsNoTracking(),
                        "ID", "Size", selectedShoeSize);
        }
    }
}