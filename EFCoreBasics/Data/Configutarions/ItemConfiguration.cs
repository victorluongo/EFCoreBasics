using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreBasics.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreBasics.Data.Configutarions
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Description).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(p => p.SalesPrice).IsRequired();
            builder.Property(p => p.Type).HasConversion<string>();

            builder.HasIndex(i => i.Type).HasDatabaseName("idx_item_type");
        }
    }
}