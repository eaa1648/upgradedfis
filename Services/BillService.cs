using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class BillService
{
    private readonly ApplicationDbContext _context;

    public BillService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<BillDto>> GetAllBillsAsync()
    {
        return await _context.Bills
                             .Select(b => new BillDto
                             {
                                 Id = b.Id,
                                 CompanyId = b.CompanyId,
                                 BillDate = b.BillDate,
                                 BillDateDue = b.BillDateDue,
                                 Amount = b.Amount,
                                 Status = b.Status,
                                 PaymentMethodId = b.PaymentMethodId
                             })
                             .ToListAsync();
    }

    public async Task<BillDto> GetBillByIdAsync(long id)
    {
        return await _context.Bills
                             .Where(b => b.Id == id)
                             .Select(b => new BillDto
                             {
                                 Id = b.Id,
                                 CompanyId = b.CompanyId,
                                 BillDate = b.BillDate,
                                 BillDateDue = b.BillDateDue,
                                 Amount = b.Amount,
                                 Status = b.Status,
                                 PaymentMethodId = b.PaymentMethodId
                             })
                             .FirstOrDefaultAsync();
    }

    public async Task AddBillAsync(BillDto billDto)
    {
        var bill = new Bill
        {
            CompanyId = billDto.CompanyId,
            BillDate = billDto.BillDate,
            BillDateDue = billDto.BillDateDue,
            Amount = billDto.Amount,
            Status = billDto.Status,
            PaymentMethodId = billDto.PaymentMethodId
        };

        _context.Bills.Add(bill);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateBillAsync(BillDto billDto)
    {
        var existingBill = await _context.Bills.FindAsync(billDto.Id);
        if (existingBill != null)
        {
            existingBill.CompanyId = billDto.CompanyId;
            existingBill.BillDate = billDto.BillDate;
            existingBill.BillDateDue = billDto.BillDateDue;
            existingBill.Amount = billDto.Amount;
            existingBill.Status = billDto.Status;
            existingBill.PaymentMethodId = billDto.PaymentMethodId;

            _context.Bills.Update(existingBill);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteBillAsync(long id)
    {
        var bill = await _context.Bills.FindAsync(id);
        if (bill != null)
        {
            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();
        }
    }
}
