using MyServerRenderedPortal.Models;
using System;
using System.Linq;

namespace MyServerRenderedPortal.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ShoeSizeContext context)
        {
            // Look for any students.
            if (!context.ShoeSizes.Any())
            {
                    var shoesizes = new ShoeSize[]
                {
                    new ShoeSize{Size = "extra small"},
                    new ShoeSize{Size = "small"},
                    new ShoeSize{Size = "medium"},
                    new ShoeSize{Size = "large"},
                    new ShoeSize{Size = "extra large"},
                    new ShoeSize{Size = "double extra large"},
                };

                context.ShoeSizes.AddRange(shoesizes);
                context.SaveChanges();
            }

            if (!context.Shoes.Any())
            {
                var shoe = new Shoe() { ShoeSizeID = 1, username = "chrisjohns604@gmail.com" };
                context.Shoes.Add(shoe);
                
                shoe = new Shoe() { ShoeSizeID = 1, username = "test1@chrisjohns604gmail.onmicrosoft.com" };
                context.Shoes.Add(shoe);

                shoe = new Shoe() { ShoeSizeID = 1, username = "test2@chrisjohns604gmail.onmicrosoft.com" };
                context.Shoes.Add(shoe);

                context.SaveChanges();
            }

        }
    }
}