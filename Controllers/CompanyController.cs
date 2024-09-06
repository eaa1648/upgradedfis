using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly CompanyService _companyService;

    public CompanyController(CompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CompanyDto>>> GetAllCompanies()
    {
        var companies = await _companyService.GetAllCompaniesAsync();
        return Ok(companies);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CompanyDto>> GetCompanyById(long id)
    {
        var company = await _companyService.GetCompanyByIdAsync(id);
        if (company == null)
        {
            return NotFound();
        }
        return Ok(company);
    }

    [HttpPost]
    public async Task<ActionResult> AddCompany([FromBody] CompanyDto companyDto)
    {
        if (companyDto == null)
        {
            return BadRequest();
        }

        await _companyService.AddCompanyAsync(companyDto);
        return CreatedAtAction(nameof(GetCompanyById), new { id = companyDto.Id }, companyDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCompany(long id, [FromBody] CompanyDto companyDto)
    {
        if (id != companyDto.Id)
        {
            return BadRequest();
        }
        await _companyService.UpdateCompanyAsync(companyDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCompany(long id)
    {
        await _companyService.DeleteCompanyAsync(id);
        return NoContent();
    }
}
