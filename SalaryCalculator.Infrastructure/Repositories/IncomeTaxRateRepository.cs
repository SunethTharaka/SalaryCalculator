using SalaryCalculator.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Infrastructure.Repositories
{
    public class IncomeTaxRateRepository : IIncomeTaxRateRepository
    {
        private readonly SalaryDbContext _salaryDbContext;

        public IncomeTaxRateRepository(SalaryDbContext salaryDbContext)
        {
            _salaryDbContext = salaryDbContext;
        }

        public IEnumerable<IncomeTaxRate?> GetIncomeTaxRates()
        {
            return _salaryDbContext.IncomeTaxRates;
        }
    }
}
