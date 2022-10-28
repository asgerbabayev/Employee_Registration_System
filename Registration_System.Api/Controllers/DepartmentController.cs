using Microsoft.AspNetCore.Mvc;
using Registration_System.Business.Abstract;
using Registration_System.Entities.DTO_s.DepartmentDtos;

namespace Registration_System.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService) =>
            _departmentService = departmentService;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _departmentService.GetAllAsync());

        [HttpGet("get")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _departmentService.GetAsync(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] DepartmentCreateDto departmentCreateDto)
        {
            var result = await _departmentService.AddAsync(departmentCreateDto);
            if (result.Success) return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] DepartmentUpdateDto departmentUpdateDto)
        {
            var result = await _departmentService.Update(departmentUpdateDto);
            if (result.Success) return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _departmentService.Delete(id);
            if (result.Success) return Ok(result);
            return BadRequest(result.Message);
        }
    }
}
