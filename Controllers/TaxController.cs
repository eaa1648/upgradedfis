// TaxController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using upgradedfis.Models;

[Route("api/[controller]")]
[ApiController]
public class TaxController : ControllerBase
{
    private readonly TaxService _taxService;

    public TaxController(TaxService taxService)
    {
        _taxService = taxService;
    }

    [HttpGet]
    public async Task<ActionResult<List<TaxDto>>> GetAllTaxes()
    {
        var taxes = await _taxService.GetAllTaxesAsync();
        return Ok(taxes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaxDto>> GetTaxById(long id)
    {
        var tax = await _taxService.GetTaxByIdAsync(id);
        if (tax == null)
        {
            return NotFound();
        }
        return Ok(tax);
    }

    [HttpPost]
    public async Task<ActionResult> AddTax([FromBody] TaxDto taxDto)
    {
        await _taxService.AddTaxAsync(taxDto);
        return CreatedAtAction(nameof(GetTaxById), new { id = taxDto.Id }, taxDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTax(long id, [FromBody] TaxDto taxDto)
    {
        if (id != taxDto.Id)
        {
            return BadRequest();
        }
        await _taxService.UpdateTaxAsync(taxDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTax(long id)
    {
        await _taxService.DeleteTaxAsync(id);
        return NoContent();
    }
}
