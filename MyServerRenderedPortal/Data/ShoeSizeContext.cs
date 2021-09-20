using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyServerRenderedPortal.Models;

namespace MyServerRenderedPortal.Data
{
    public class ShoeSizeContext : DbContext
    {
        public ShoeSizeContext (DbContextOptions<ShoeSizeContext> options)
            : base(options)
        {
        }

        public DbSet<ShoeSize> ShoeSizes { get; set; }
        public DbSet<Shoe> Shoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoeSize>().ToTable("ShoeSize");
            modelBuilder.Entity<Shoe>().ToTable("Shoe");


        }
      

    }
}
