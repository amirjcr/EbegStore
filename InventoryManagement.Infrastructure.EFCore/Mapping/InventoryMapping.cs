using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.EFCore.Mapping
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inentory");
            builder.HasKey(x => x.Id);


            builder.OwnsMany(many => many.Operation, modelbuilder =>
            {
                modelbuilder.ToTable("InvenotryOperations");
                modelbuilder.HasKey(x => x.Id);
                modelbuilder.Property(x => x.Description).HasMaxLength(1000);
                
                modelbuilder.WithOwner(x => x.Inventory).HasForeignKey(f => f.InventoryId);
            });
        }
    }
}
