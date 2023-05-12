namespace SalaryCalculator.Domain.Services
{
    public interface ICalendarService
    {
        int GetLastDateOfMonth(string monthString);
    }
}