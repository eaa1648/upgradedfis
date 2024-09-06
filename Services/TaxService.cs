// TaxService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using upgradedfis.Models;

public class TaxService
{
    private readonly ApplicationDbContext _context;

    public TaxService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaxDto>> GetAllTaxesAsync()
    {
        return await _context.Taxes
            .Select(t => new TaxDto
            {
                Id = t.Id,
                BillId = t.BillId,
                TaxType = t.TaxType,
                TaxRate = t.TaxRate,
                TaxAmount = t.TaxAmount,
                Desc = t.Desc
            })
            .ToListAsync();
    }

    public async Task<TaxDto> GetTaxByIdAsync(long id)
    {
        return await _context.Taxes
            .Where(t => t.Id == id)
            .Select(t => new TaxDto
            {
                Id = t.Id,
                BillId = t.BillId,
                TaxType = t.TaxType,
                TaxRate = t.TaxRate,
                TaxAmount = t.TaxAmount,
                Desc = t.Desc
            })
            .FirstOrDefaultAsync();
    }

    public async Task AddTaxAsync(TaxDto taxDto)
    {
        var tax = new Tax
        {
            BillId = taxDto.BillId,
            TaxType = taxDto.TaxType,
            TaxRate = taxDto.TaxRate,
            TaxAmount = taxDto.TaxAmount,
            Desc = taxDto.Desc
        };

        _context.Taxes.Add(tax);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTaxAsync(TaxDto taxDto)
    {
        var existingTax = await _context.Taxes.FindAsync(taxDto.Id);
        if (existingTax != null)
        {
            existingTax.BillId = taxDto.BillId;
            existingTax.TaxType = taxDto.TaxType;
            existingTax.TaxRate = taxDto.TaxRate;
            existingTax.TaxAmount = taxDto.TaxAmount;
            existingTax.Desc = taxDto.Desc;

            _context.Taxes.Update(existingTax);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteTaxAsync(long id)
    {
        var tax = await _context.Taxes.FindAsync(id);
        if (tax != null)
        {
            _context.Taxes.Remove(tax);
            await _context.SaveChangesAsync();
        }
    }
}
