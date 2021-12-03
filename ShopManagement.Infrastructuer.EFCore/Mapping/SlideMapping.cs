using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.SliderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructuer.EFCore.Mapping
{
    public class SlideMapping : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("Slides");
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.PictureName).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(500).IsRequired();
            builder.Property(x => x.PictureTitel).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Heading).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Titel).HasMaxLength(255);
            builder.Property(x => x.Text).HasMaxLength(255);
            builder.Property(x => x.BtnText).HasMaxLength(50).IsRequired();
        }
    }
}
