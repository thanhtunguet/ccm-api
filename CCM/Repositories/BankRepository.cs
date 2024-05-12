using CCM.Models;
using Microsoft.EntityFrameworkCore;

namespace CCM.Repositories;

public class BankRepository(CcmContext context)
{
    public async Task<List<Bank>> ListAllAsync(bool includeCardClasses = false)
    {
        if (includeCardClasses)
            return await context.Banks.Include(b => b.CardClasses).ToListAsync();
        return await context.Banks.ToListAsync();
    }

    public async Task<Bank> GetByIdAsync(ulong id, bool includeCardClasses = false)
    {
        if (includeCardClasses)
            return await context.Banks.Include(b => b.CardClasses).FirstOrDefaultAsync(b => b.Id == id);
        return await context.Banks.FindAsync(id);
    }

    public async Task<int> CountAsync()
    {
        return await context.Banks.CountAsync();
    }

    public async Task CreateAsync(Bank bank)
    {
        context.Banks.Add(bank);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Bank bank)
    {
        context.Entry(bank).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(ulong id)
    {
        var bank = await context.Banks.FindAsync(id);
        context.Banks.Remove(bank);
        await context.SaveChangesAsync();
    }
}