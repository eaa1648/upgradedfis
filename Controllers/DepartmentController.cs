using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly DepartmentService _departmentService;

    public DepartmentController(DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    public async Task<ActionResult<List<DepartmentDto>>> GetAllDepartments()
    {
        var departments = await _departmentService.GetAllDepartmentsAsync();
        return Ok(departments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DepartmentDto>> GetDepartmentById(long id)
    {
        var department = await _departmentService.GetDepartmentByIdAsync(id);
        if (department == null)
        {
            return NotFound();
        }
        return Ok(department);
    }

    [HttpPost]
    public async Task<ActionResult> AddDepartment([FromBody] DepartmentDto departmentDto)
    {
        if (departmentDto == null)
        {
            return BadRequest();
        }

        await _departmentService.AddDepartmentAsync(departmentDto);
        return CreatedAtAction(nameof(GetDepartmentById), new { id = departmentDto.Id }, departmentDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateDepartment(long id, [FromBody] DepartmentDto departmentDto)
    {
        if (id != departmentDto.Id)
        {
            return BadRequest();
        }
        await _departmentService.UpdateDepartmentAsync(departmentDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteDepartment(long id)
    {
        await _departmentService.DeleteDepartmentAsync(id);
        return NoContent();
    }
}
