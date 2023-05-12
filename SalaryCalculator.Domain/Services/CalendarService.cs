using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Domain.Services
{
    public class CalendarService : ICalendarService
    {
        public int GetLastDateOfMonth(string monthString)
        {
            if (monthString is null)
            {
                throw new ArgumentNullException(nameof(monthString));
            }

            int month = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(monthString) + 1;
            return DateTime.DaysInMonth(DateTime.Now.Year, month);
        }
    }
}
