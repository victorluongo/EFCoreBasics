using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreBasics.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBasics.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Item> Items {get; set;}
        public DbSet<Invoice> Invoices {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=;Database=;User Id=;Password;MultipleActiveResultSets=true;Encrypt=YES;TrustServerCertificate=YES",
                p=> p.EnableRetryOnFailure(
                    maxRetryCount: 2, 
                    maxRetryDelay: TimeSpan.FromSeconds(5), 
                    errorNumbersToAdd: null)
                    .MigrationsHistoryTable("__EF_Migrations_History")
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }               
    }
}