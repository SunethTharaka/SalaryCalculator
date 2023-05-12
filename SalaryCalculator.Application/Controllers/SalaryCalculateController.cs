using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalaryCalculator.Domain.Model;
using SalaryCalculator.Domain.Services;

namespace SalaryCalculator.Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalaryCalculateController : ControllerBase
    {
        private readonly ISalaryService _salaryService;

        public SalaryCalculateController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpPost]
        public async Task<JsonResult> GetSalarySlip([FromBody] SalaryDTO salaryDTO)
        {
            return new JsonResult(_salaryService.GetPaySlipInformation(salaryDTO));
        }
    }
}
