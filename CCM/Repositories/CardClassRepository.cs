using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCM.Models;

namespace CCM.Repositories
{
    public class CardClassRepository
    {
        private readonly CcmContext _context;

        public CardClassRepository(CcmContext context)
        {
            _context = context;
        }

        public async Task<List<CardClass>> ListAllAsync()
        {
            return await _context.CardClasses.ToListAsync();
        }

        public async Task<CardClass> GetByIdAsync(ulong id)
        {
            return await _context.CardClasses.FindAsync(id);
        }

        public async Task CreateAsync(CardClass cardClass)
        {
            _context.CardClasses.Add(cardClass);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CardClass cardClass)
        {
            _context.Entry(cardClass).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ulong id)
        {
            var cardClass = await _context.CardClasses.FindAsync(id);
            _context.CardClasses.Remove(cardClass);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.CardClasses.CountAsync();
        }
    }
}