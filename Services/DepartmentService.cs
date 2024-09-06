using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class DepartmentService
{
    private readonly ApplicationDbContext _context;

    public DepartmentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<DepartmentDto>> GetAllDepartmentsAsync()
    {
        return await _context.Departments
                             .Select(d => new DepartmentDto
                             {
                                 Id = d.Id,
                                 Name = d.Name
                             })
                             .ToListAsync();
    }

    public async Task<DepartmentDto> GetDepartmentByIdAsync(long id)
    {
        return await _context.Departments
                             .Where(d => d.Id == id)
                             .Select(d => new DepartmentDto
                             {
                                 Id = d.Id,
                                 Name = d.Name
                             })
                             .FirstOrDefaultAsync();
    }

    public async Task AddDepartmentAsync(DepartmentDto departmentDto)
    {
        var department = new Department
        {
            Name = departmentDto.Name
        };

        _context.Departments.Add(department);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateDepartmentAsync(DepartmentDto departmentDto)
    {
        var existingDepartment = await _context.Departments.FindAsync(departmentDto.Id);
        if (existingDepartment != null)
        {
            existingDepartment.Name = departmentDto.Name;

            _context.Departments.Update(existingDepartment);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteDepartmentAsync(long id)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department != null)
        {
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }
    }
}
