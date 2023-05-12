using Microsoft.EntityFrameworkCore;
using SalaryCalculator.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Infrastructure
{
    public class SalaryDbContext : DbContext
    {
        public SalaryDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IncomeTaxRate>().HasData(
                new IncomeTaxRate
                {
                    Id = 1,
                    Name = "L1",
                    Description = "Up to $14,000",
                    MinValue = 0,
                    MaxValue = 14000,
                    Rate = 10.5M,
                    IsActive = true
                },
                 new IncomeTaxRate
                 {
                     Id = 2,
                     Name = "L2",
                     Description = "Over $14,000 and up to $48,000",
                     MinValue = 14000,
                     MaxValue = 48000,
                     Rate = 17.5M,
                     IsActive = true
                 },
                 new IncomeTaxRate
                 {
                     Id = 3,
                     Name = "L3",
                     Description = "Over $48,000 and up to $70,000 ",
                     MinValue = 48000,
                     MaxValue = 70000,
                     Rate = 30M,
                     IsActive = true
                 },
                 new IncomeTaxRate
                 {
                     Id = 4,
                     Name = "L4",
                     Description = "Over $70,000 and up to $180,000 ",
                     MinValue = 70000,
                     MaxValue = 180000,
                     Rate = 33M,
                     IsActive = true
                 },
                 new IncomeTaxRate
                 {
                     Id = 5,
                     Name = "L5",
                     Description = "Income over $180,000",
                     MinValue = 180000,
                     MaxValue = 180000,
                     Rate = 39M,
                     IsActive = true
                 }
                );
        }

        public DbSet<IncomeTaxRate> IncomeTaxRates { get; set; }
    }
}
