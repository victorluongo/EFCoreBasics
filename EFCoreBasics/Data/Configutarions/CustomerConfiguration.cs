using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreBasics.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreBasics.Data.Configutarions
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Name).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("VARCHAR(80)");
            builder.Property(p => p.Phone).HasColumnType("VARCHAR(13)");

            builder.HasIndex(i => i.Email).HasDatabaseName("idx_customer_phone");
        }
    }
}