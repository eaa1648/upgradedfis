// PaymentMethodController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using upgradedfis.Models;

[Route("api/[controller]")]
[ApiController]
public class PaymentMethodController : ControllerBase
{
    private readonly PaymentMethodService _paymentMethodService;

    public PaymentMethodController(PaymentMethodService paymentMethodService)
    {
        _paymentMethodService = paymentMethodService;
    }

    [HttpGet]
    public async Task<ActionResult<List<PaymentMethodDto>>> GetAllPaymentMethods()
    {
        var paymentMethods = await _paymentMethodService.GetAllPaymentMethodsAsync();
        return Ok(paymentMethods);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PaymentMethodDto>> GetPaymentMethodById(long id)
    {
        var paymentMethod = await _paymentMethodService.GetPaymentMethodByIdAsync(id);
        if (paymentMethod == null)
        {
            return NotFound();
        }
        return Ok(paymentMethod);
    }

    [HttpPost]
    public async Task<ActionResult> AddPaymentMethod([FromBody] PaymentMethodDto paymentMethodDto)
    {
        await _paymentMethodService.AddPaymentMethodAsync(paymentMethodDto);
        return CreatedAtAction(nameof(GetPaymentMethodById), new { id = paymentMethodDto.Id }, paymentMethodDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePaymentMethod(long id, [FromBody] PaymentMethodDto paymentMethodDto)
    {
        if (id != paymentMethodDto.Id)
        {
            return BadRequest();
        }
        await _paymentMethodService.UpdatePaymentMethodAsync(paymentMethodDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePaymentMethod(long id)
    {
        await _paymentMethodService.DeletePaymentMethodAsync(id);
        return NoContent();
    }
}
