using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictuerAgg;
using ShopManagement.Domain.SliderAgg;
using ShopManagement.Infrastructuer.EFCore.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructuer.EFCore
{
    public class ShopContext:DbContext
    {

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }    
        public DbSet<ProductPicture>ProductPictures { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public ShopContext(DbContextOptions<ShopContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductCategoryMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
