using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructuer.EFCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Code).HasMaxLength(15).IsRequired();
            builder.Property(x => x.ShortDescription).HasMaxLength(300).IsRequired();
            builder.Property(x => x.PictureName).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(255).IsRequired();
            builder.Property(x => x.PictureTitel).HasMaxLength(500).IsRequired();

            builder.Property(x => x.KeyWords).HasMaxLength(100).IsRequired();
            builder.Property(x => x.MetaDescription).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(500).IsRequired();


            builder.HasOne(c => c.Category).WithMany(m => m.Products).HasForeignKey(x => x.CategoryId);
            builder.HasMany(many => many.ProductPictures).WithOne(one => one.Product).HasForeignKey(f => f.ProdctId);
        }
    }
}
