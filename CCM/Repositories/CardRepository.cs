using CCM.Models;
using Microsoft.EntityFrameworkCore;

namespace CCM.Repositories;

public class CardRepository(CcmContext context)
{
    public async Task<List<Card>> ListAllAsync()
    {
        return await context.Cards.ToListAsync();
    }

    public async Task<Card> GetByIdAsync(ulong id)
    {
        return await context.Cards.FindAsync(id);
    }

    public async Task CreateAsync(Card card)
    {
        context.Cards.Add(card);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Card card)
    {
        context.Entry(card).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(ulong id)
    {
        var card = await context.Cards.FindAsync(id);
        context.Cards.Remove(card);
        await context.SaveChangesAsync();
    }

    public async Task<int> CountAsync()
    {
        return await context.Cards.CountAsync();
    }
}