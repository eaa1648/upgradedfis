using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class BillController : ControllerBase
{
    private readonly BillService _billService;

    public BillController(BillService billService)
    {
        _billService = billService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBills()
    {
        var bills = await _billService.GetAllBillsAsync();
        return Ok(bills);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBillById(long id)
    {
        var bill = await _billService.GetBillByIdAsync(id);
        if (bill == null)
        {
            return NotFound();
        }
        return Ok(bill);
    }

    [HttpPost]
    public async Task<IActionResult> AddBill([FromBody] BillDto billDto)
    {
        if (billDto == null)
        {
            return BadRequest();
        }

        await _billService.AddBillAsync(billDto);
        return CreatedAtAction(nameof(GetBillById), new { id = billDto.Id }, billDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBill(long id, [FromBody] BillDto billDto)
    {
        if (billDto == null || id != billDto.Id)
        {
            return BadRequest();
        }

        var existingBill = await _billService.GetBillByIdAsync(id);
        if (existingBill == null)
        {
            return NotFound();
        }

        await _billService.UpdateBillAsync(billDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBill(long id)
    {
        var existingBill = await _billService.GetBillByIdAsync(id);
        if (existingBill == null)
        {
            return NotFound();
        }

        await _billService.DeleteBillAsync(id);
        return NoContent();
    }
}
