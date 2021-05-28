using Microsoft.EntityFrameworkCore;
using ProgressiveTaxCalculator.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DomainManager.Models;

namespace ProgressiveTaxCalculator.DB
{
    public class ProgressiveTaxCalculatorContext : DbContext
    {
        public DbSet<CalculatedTaxHistory> CalculatedTaxHistories { get; set; }
        public ProgressiveTaxCalculatorContext(DbContextOptions<ProgressiveTaxCalculatorContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map entities to tables  
            modelBuilder.Entity<CalculatedTaxHistory>().ToTable("CalculatedTaxHistory");
        }
    }
}
