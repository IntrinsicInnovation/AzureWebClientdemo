using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MyServerRenderedPortal.Data;


namespace MyServerRenderedPortal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<System.Security.Claims.Claim> myclaims = new List<System.Security.Claims.Claim>();

        public int SelectedShoeSizeId { get; set; }
        public IEnumerable<SelectListItem> ShoeSizes { get; set; }
        private readonly ShoeSizeContext _context;

        public string shoesizestr;

        public string username;

        public IndexModel(ILogger<IndexModel> logger, ShoeSizeContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            var r = Request.HttpContext.User;
            var claims = r.Claims.ToList();
            myclaims.AddRange(claims);

            username = myclaims.Where(c => c.Type == "preferred_username").FirstOrDefault().Value;

          

            var shoesize =  _context.Shoes.FirstOrDefault(m => m.username == username);
            var shoesizeid = shoesize.ShoeSizeID;
            var shoe = _context.ShoeSizes.FirstOrDefault(s => s.ID == shoesizeid);
            shoesizestr = shoe.Size;

        }

    
    }

}
