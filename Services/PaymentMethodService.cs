// PaymentMethodService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using upgradedfis.Models;

public class PaymentMethodService
{
    private readonly ApplicationDbContext _context;

    public PaymentMethodService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<PaymentMethodDto>> GetAllPaymentMethodsAsync()
    {
        return await _context.PaymentMethods
            .Select(pm => new PaymentMethodDto
            {
                Id = pm.Id,
                Name = pm.Name,
                Bills = pm.Bills.Select(b => new BillDto
                {
                    Id = b.Id,
                    CompanyId = b.CompanyId,
                    BillDate = b.BillDate,
                    BillDateDue = b.BillDateDue,
                    Amount = b.Amount,
                    Status = b.Status,
                    PaymentMethodId = b.PaymentMethodId
                }).ToList()
            })
            .ToListAsync();
    }

    public async Task<PaymentMethodDto> GetPaymentMethodByIdAsync(long id)
    {
        return await _context.PaymentMethods
            .Where(pm => pm.Id == id)
            .Select(pm => new PaymentMethodDto
            {
                Id = pm.Id,
                Name = pm.Name,
                Bills = pm.Bills.Select(b => new BillDto
                {
                    Id = b.Id,
                    CompanyId = b.CompanyId,
                    BillDate = b.BillDate,
                    BillDateDue = b.BillDateDue,
                    Amount = b.Amount,
                    Status = b.Status,
                    PaymentMethodId = b.PaymentMethodId
                }).ToList()
            })
            .FirstOrDefaultAsync();
    }

    public async Task AddPaymentMethodAsync(PaymentMethodDto paymentMethodDto)
    {
        var paymentMethod = new PaymentMethod
        {
            Name = paymentMethodDto.Name,
            // Initialize Bills if needed
        };

        _context.PaymentMethods.Add(paymentMethod);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePaymentMethodAsync(PaymentMethodDto paymentMethodDto)
    {
        var existingPaymentMethod = await _context.PaymentMethods.FindAsync(paymentMethodDto.Id);
        if (existingPaymentMethod != null)
        {
            existingPaymentMethod.Name = paymentMethodDto.Name;
            // Update Bills if needed

            _context.PaymentMethods.Update(existingPaymentMethod);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeletePaymentMethodAsync(long id)
    {
        var paymentMethod = await _context.PaymentMethods.FindAsync(id);
        if (paymentMethod != null)
        {
            _context.PaymentMethods.Remove(paymentMethod);
            await _context.SaveChangesAsync();
        }
    }
}
