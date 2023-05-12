using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SalaryCalculator.Domain.Services;
using SalaryCalculator.Infrastructure;
using SalaryCalculator.Infrastructure.Entities;
using SalaryCalculator.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Domain.Services.Tests
{
    [TestClass]
    public class SalaryServiceTests
    {
        private ICalendarService _calendarService;

        [TestInitialize]
        public void Setup()
        {
            _calendarService = new CalendarService();
        }


        [TestMethod]
        public void GetPaySlipInformation_ValidInputs_ReturnsValidOutputString()
        {
            //Arrange
            var salaryDto = new Model.SalaryDTO()
            { FirstName = "Smith", LastName = "John", AnnualSalary = 60050M, SupperRate = 9M, PayPeriod = "March" };

            List<IncomeTaxRate> taxRates = new List<IncomeTaxRate>
{
    new IncomeTaxRate { Id = 1, Description = "10.5%", MinValue = 0, MaxValue = 14000, Rate = 10.5m, IsActive = true },
    new IncomeTaxRate { Id = 2, Description = "17.5%", MinValue = 14000, MaxValue = 48000, Rate = 17.5m, IsActive = true },
    new IncomeTaxRate { Id = 3, Description = "30%", MinValue = 48000, MaxValue = 70000, Rate = 30m, IsActive = true },
    new IncomeTaxRate { Id = 4, Description = "33%", MinValue = 70000, MaxValue = 180000, Rate = 33m, IsActive = true },
    new IncomeTaxRate { Id = 5, Description = "39%", MinValue = 180000, MaxValue = decimal.MaxValue, Rate = 39m, IsActive = true }
};

            Mock<IIncomeTaxRateRepository> mockDBContext = new Mock<IIncomeTaxRateRepository>();
            mockDBContext.Setup(t => t.GetIncomeTaxRates()).Returns(taxRates);
            var _salaryService = new SalaryService(mockDBContext.Object, _calendarService);

            //Act
            var outputSting = _salaryService.GetPaySlipInformation(salaryDto);

            //Assert

            Assert.AreEqual("Smith John, 01 March - 31 March, 5004.17, 919.58, 4084.59, 450.38", outputSting);
        }

        [TestMethod]
        public void GetPaySlipInformation_NullInput_ThrowsException()
        {
            //Arrange
            Mock<IIncomeTaxRateRepository> mockDBContext = new Mock<IIncomeTaxRateRepository>();
            var _salaryService = new SalaryService(mockDBContext.Object, _calendarService);

            try
            {
                //Act
                var outputSting = _salaryService.GetPaySlipInformation(null);

                //Assert

                Assert.AreEqual("Smith John, 01 March - 31 March, 5004.17, 919.58, 4084.59, 450.38", outputSting);
            }
            catch (Exception ex)
            {
                Assert.IsTrue("Value cannot be null. (Parameter 'salaryDTO')" == ex.Message);
            }
        }

        [TestMethod]
        public void GetPaySlipInformation_ValidInputNoTaxRates_ThrowsException()
        {
            //Arrange
            var salaryDto = new Model.SalaryDTO()
            { FirstName = "Smith", LastName = "John", AnnualSalary = 60050M, SupperRate = 9M, PayPeriod = "March" };

            Mock<IIncomeTaxRateRepository> mockDBContext = new Mock<IIncomeTaxRateRepository>();
            var _salaryService = new SalaryService(mockDBContext.Object, _calendarService);

            try
            {
                //Act
                var outputSting = _salaryService.GetPaySlipInformation(salaryDto);

                //Assert

                Assert.AreEqual("Smith John, 01 March - 31 March, 5004.17, 919.58, 4084.59, 450.38", outputSting);
            }
            catch (Exception ex)
            {
                Assert.IsTrue("Please setup tax rates" == ex.Message);
            }
        }

    }
}