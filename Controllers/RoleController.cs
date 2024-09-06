using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly RoleService _roleService;

    public RoleController(RoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
        var roles = await _roleService.GetAllRolesAsync();
        return Ok(roles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoleById(long id)
    {
        var role = await _roleService.GetRoleByIdAsync(id);
        if (role == null)
        {
            return NotFound();
        }
        return Ok(role);
    }

    [HttpPost]
    public async Task<IActionResult> AddRole([FromBody] Role role)
    {
        if (role == null)
        {
            return BadRequest();
        }

        await _roleService.AddRoleAsync(role);
        return CreatedAtAction(nameof(GetRoleById), new { id = role.Id }, role);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRole(long id, [FromBody] Role role)
    {
        if (role == null || role.Id != id)
        {
            return BadRequest();
        }

        var existingRole = await _roleService.GetRoleByIdAsync(id);
        if (existingRole == null)
        {
            return NotFound();
        }

        await _roleService.UpdateRoleAsync(role);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRole(long id)
    {
        var existingRole = await _roleService.GetRoleByIdAsync(id);
        if (existingRole == null)
        {
            return NotFound();
        }

        await _roleService.DeleteRoleAsync(id);
        return NoContent();
    }
}
