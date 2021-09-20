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

            //  var model = new MyViewModel
            //  {
            SelectedShoeSizeId = 1; // dsn.NewsCategoriesID,

            ShoeSizes = new List<SelectListItem>()
            {


                new SelectListItem { Text = "extra small", Value = "1"},
                   new SelectListItem { Text = "small", Value = "2"},
                      new SelectListItem { Text = "medium", Value = "3"},
                         new SelectListItem { Text = "large", Value = "4"},
                            new SelectListItem { Text = "extra large", Value = "5"},

                //Categories = categories.Select(x => new SelectListItem
               // {
               //     Value = x.NewsCategoriesID.ToString(),
               //     Text = x.NewsCategoriesName
               // })

               


        };

            var shoesize =  _context.Shoes.FirstOrDefault(m => m.ID == 1);
            var shoesizeid = shoesize.ShoeSizeID;
            var shoe = _context.ShoeSizes.FirstOrDefault(s => s.ID == shoesizeid);
            shoesizestr = shoe.Size;



        }

        public void OnSave()
        {
            var r = Request.HttpContext.User;
            var claims = r.Claims.ToList();
            myclaims.AddRange(claims);

            //  var model = new MyViewModel
            //  {
            SelectedShoeSizeId = 1;

            ShoeSizes = new List<SelectListItem>()
            {


                new SelectListItem { Text = "extra small", Value = "1"},
                   new SelectListItem { Text = "small", Value = "2"},
                      new SelectListItem { Text = "medium", Value = "3"},
                         new SelectListItem { Text = "large", Value = "4"},
                            new SelectListItem { Text = "extra large", Value = "5"},

                //Categories = categories.Select(x => new SelectListItem
               // {
               //     Value = x.NewsCategoriesID.ToString(),
               //     Text = x.NewsCategoriesName
               // })
            };



        }
    }

}
