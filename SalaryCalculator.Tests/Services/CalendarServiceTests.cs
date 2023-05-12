using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalaryCalculator.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Domain.Services.Tests
{
    [TestClass()]
    public class CalendarServiceTests
    {
        [TestMethod()]
        public void GetLastDateOfMonth_ValidInput_ReturnsValidOutput()
        {
            //Arrange
            var _calendarService = new CalendarService();

            //Act
            var output = _calendarService.GetLastDateOfMonth("March");

            //Assert
            Assert.AreEqual(31, output);
        }

        [TestMethod()]
        public void GetLastDateOfMonth_NullInput_ThrowsException()
        {
            //Arrange
            var _calendarService = new CalendarService();

            try
            {
                //Act
                var output = _calendarService.GetLastDateOfMonth(null);

                //Assert
            }
            catch (Exception ex)
            {
                Assert.IsTrue("Value cannot be null. (Parameter 'monthString')" == ex.Message);
            }
        }

        [TestMethod()]
        public void GetLastDateOfMonth_InvalidInput_ThrowsException()
        {
            //Arrange
            var _calendarService = new CalendarService();

            try
            {
                //Act
                var output = _calendarService.GetLastDateOfMonth("Test");

                //Assert
                Assert.AreEqual(31, output);
            }
            catch (Exception ex)
            {
                Assert.IsTrue("Month must be between one and twelve. (Parameter 'month')\r\nActual value was 0." == ex.Message);
            }
        }
    }
}