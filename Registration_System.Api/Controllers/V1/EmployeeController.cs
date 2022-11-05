using Microsoft.AspNetCore.Mvc;
using Registration_System.Business.Abstract;
using Registration_System.Entities.DTO_s.EmployeeDtos;

namespace Registration_System.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    public class EmployeeController : ApiBaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService) =>
            _employeeService = employeeService;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _employeeService.GetAllAsync());

        [HttpGet("get")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _employeeService.GetAsync(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] EmployeeCreateDto employeeCreateDto)
        {
            var result = await _employeeService.AddAsync(employeeCreateDto);
            if (result.Success) return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] EmployeeUpdateDto employeeUpdateDto)
        {
            var result = await _employeeService.Update(employeeUpdateDto);
            if (result.Success) return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeService.Delete(id);
            if (result.Success) return Ok(result);
            return BadRequest(result.Message);
        }
    }
}
