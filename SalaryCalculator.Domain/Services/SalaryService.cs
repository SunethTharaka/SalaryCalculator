using SalaryCalculator.Domain.Model;
using SalaryCalculator.Infrastructure.Entities;
using SalaryCalculator.Infrastructure.Repositories;

namespace SalaryCalculator.Domain.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly IIncomeTaxRateRepository _incomeTaxRateRepository;
        private readonly ICalendarService _calendarService;

        public SalaryService(IIncomeTaxRateRepository incomeTaxRateRepository, ICalendarService calendarService)
        {
            _incomeTaxRateRepository = incomeTaxRateRepository;
            _calendarService = calendarService;
        }

        public string GetPaySlipInformation(SalaryDTO salaryDTO)
        {
            if (salaryDTO is null)
            {
                throw new ArgumentNullException(nameof(salaryDTO));
            }

            var taxRates = _incomeTaxRateRepository.GetIncomeTaxRates();

            if (taxRates == null || !taxRates.Any())
            {
                throw new Exception("Please setup tax rates");
            }

            var payPeriod = $"01 {salaryDTO.PayPeriod} - {_calendarService.GetLastDateOfMonth(salaryDTO.PayPeriod)} {salaryDTO.PayPeriod}";
            decimal grossIncome = salaryDTO.AnnualSalary / 12;
            var incomeTax = CalculateIncomeTax(salaryDTO.AnnualSalary, taxRates.ToList()!);
            var super = grossIncome * salaryDTO.SupperRate / 100;
            var netIncome = grossIncome - incomeTax;

            return $"{salaryDTO.FirstName} {salaryDTO.LastName}, {payPeriod}, {grossIncome.ToString("0.00")}, {incomeTax.ToString("0.00")}, {netIncome.ToString("0.00")}, {super.ToString("0.00")}";
        }

        public decimal CalculateIncomeTax(decimal annualSalary, List<IncomeTaxRate> taxRates)
        {
            decimal taxAmount = 0;
            decimal taxableAmount = annualSalary;

            foreach (var rate in taxRates)
            {
                if (taxableAmount > 0)
                {
                    if (rate.IsActive && taxableAmount > rate.MinValue)
                    {
                        decimal taxableIncome = rate.MaxValue - rate.MinValue;
                        taxAmount += taxableIncome * rate.Rate / 100;
                        taxableAmount -= taxableIncome;
                    }
                    else
                    {
                        taxAmount += taxableAmount * rate.Rate / 100;
                        taxableAmount -= taxableAmount;
                    }
                }
            }

            return Math.Round(taxAmount / 12, 2);
        }
    }
}