using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCM.Models;

namespace CCM.Repositories
{
    public class CardRepository
    {
        private readonly CcmContext _context;

        public CardRepository(CcmContext context)
        {
            _context = context;
        }

        public async Task<List<Card>> ListAllAsync()
        {
            return await _context.Cards.ToListAsync();
        }

        public async Task<Card> GetByIdAsync(ulong id)
        {
            return await _context.Cards.FindAsync(id);
        }

        public async Task CreateAsync(Card card)
        {
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Card card)
        {
            _context.Entry(card).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ulong id)
        {
            var card = await _context.Cards.FindAsync(id);
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Cards.CountAsync();
        }
    }
}