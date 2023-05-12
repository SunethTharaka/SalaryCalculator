using SalaryCalculator.Domain.Model;
using SalaryCalculator.Infrastructure.Entities;

namespace SalaryCalculator.Domain.Services
{
    public interface ISalaryService
    {
        string GetPaySlipInformation(SalaryDTO salaryDTO);
    }
}