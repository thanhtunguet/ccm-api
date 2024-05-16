using CCM.Models;
using Microsoft.EntityFrameworkCore;

namespace CCM.Repositories;

public class CardClassRepository(CcmContext context)
{
    public async Task<List<CardClass>> ListAllAsync()
    {
        return await context.CardClasses.Include((cardClass) => cardClass.Bank).ToListAsync();
    }

    public async Task<CardClass> GetByIdAsync(ulong id)
    {
        return await context.CardClasses.Include((cardClass) => cardClass.Bank).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateAsync(CardClass cardClass)
    {
        context.CardClasses.Add(cardClass);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CardClass cardClass)
    {
        context.Entry(cardClass).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(ulong id)
    {
        var cardClass = await context.CardClasses.FindAsync(id);
        context.CardClasses.Remove(cardClass);
        await context.SaveChangesAsync();
    }

    public async Task<int> CountAsync()
    {
        return await context.CardClasses.CountAsync();
    }
}