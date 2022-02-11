using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreBasics.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreBasics.Data.Configutarions
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoice");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Date).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(p => p.Info).HasColumnType("VARCHAR(512)");
            builder.Property(p => p.Rate).IsRequired();
            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.Status).HasConversion<string>().IsRequired();

            builder.HasIndex(i => i.Status).HasDatabaseName("idx_invoice_status");
        }
    }
}