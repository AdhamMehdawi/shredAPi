using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.API.Helpers.Shared;
using Shared.GeneralHelper.ViewModels.Employee;
using Shared.Services.EmployeeServices;
 
namespace Shared.API.Controllers.Employees
{
    [Route("api/[controller]"), Produces("application/json")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeServices _employeeServices;

        public EmployeesController(EmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpGet]
        //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeServices.GetAllEmployeesAsync();
            return new SharedResponseResult<IEnumerable<EmployeeVm>>(employees);
        }



        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeServices.GetEmployeeByIdAsync(id);
            return new SharedResponseResult<EmployeeVm>(employee);
        }
    }
}