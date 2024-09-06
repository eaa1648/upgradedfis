using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class CompanyService
{
    private readonly ApplicationDbContext _context;

    public CompanyService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CompanyDto>> GetAllCompaniesAsync()
    {
        return await _context.Companies
                             .Select(c => new CompanyDto
                             {
                                 Id = c.Id,
                                 Name = c.Name,
                                 Email = c.Email,
                                 Password = c.Password
                             })
                             .ToListAsync();
    }

    public async Task<CompanyDto> GetCompanyByIdAsync(long id)
    {
        var company = await _context.Companies
                                    .AsNoTracking() // Performans için
                                    .Where(c => c.Id == id)
                                    .Select(c => new CompanyDto
                                    {
                                        Id = c.Id,
                                        Name = c.Name,
                                        Email = c.Email,
                                        Password = c.Password
                                    })
                                    .FirstOrDefaultAsync();

        return company;
    }

    public async Task AddCompanyAsync(CompanyDto companyDto)
    {
        var company = new Company
        {
            Name = companyDto.Name,
            Email = companyDto.Email,
            Password = companyDto.Password
        };

        _context.Companies.Add(company);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCompanyAsync(CompanyDto companyDto)
    {
        var existingCompany = await _context.Companies.FindAsync(companyDto.Id);
        if (existingCompany != null)
        {
            existingCompany.Name = companyDto.Name;
            existingCompany.Email = companyDto.Email;
            existingCompany.Password = companyDto.Password;

            _context.Companies.Update(existingCompany);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteCompanyAsync(long id)
    {
        var company = await _context.Companies.FindAsync(id);
        if (company != null)
        {
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }
    }
}
