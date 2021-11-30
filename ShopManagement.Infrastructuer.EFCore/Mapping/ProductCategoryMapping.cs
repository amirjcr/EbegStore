using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructuer.EFCore.Mapping
{
    internal class ProductCategoryMapping:IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(600);
            builder.Property(p => p.PictureAlt).HasMaxLength(500);
            builder.Property(p => p.PictureName).HasMaxLength(1000);
            builder.Property(p => p.PictureTitle).HasMaxLength(500);
            builder.Property(p => p.KeyWord).HasMaxLength(80).IsRequired();
            builder.Property(p=>p.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Slug).HasMaxLength(350).IsRequired();
        }
    }
}
