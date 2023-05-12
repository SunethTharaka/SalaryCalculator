using SalaryCalculator.Infrastructure.Entities;

namespace SalaryCalculator.Infrastructure.Repositories
{
    public interface IIncomeTaxRateRepository
    {
        IEnumerable<IncomeTaxRate?> GetIncomeTaxRates();
    }
}