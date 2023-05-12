namespace SalaryCalculator.Domain.Model
{
    public class SalaryDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public decimal SupperRate { get; set; }
        public string PayPeriod { get; set; }
    }
}
