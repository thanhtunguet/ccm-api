using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using CCM.Models;

namespace CCM.Repositories
{
    public class BankRepository
    {
        private readonly CcmContext _context;

        public BankRepository(CcmContext context)
        {
            _context = context;
        }

        public async Task<List<Bank>> ListAllAsync(bool includeCardClasses = false)
        {
            if (includeCardClasses)
            {
                return await _context.Banks.Include(b => b.CardClasses).ToListAsync();
            }
            else
            {
                return await _context.Banks.ToListAsync();
            }
        }

        public async Task<Bank> GetByIdAsync(ulong id, bool includeCardClasses = false)
        {
            if (includeCardClasses)
            {
                return await _context.Banks.Include(b => b.CardClasses).FirstOrDefaultAsync(b => b.Id == id);
            }
            else
            {
                return await _context.Banks.FindAsync(id);
            }
        }

        public async Task<int> CountAsync()
        {
            return await _context.Banks.CountAsync();
        }

        public async Task CreateAsync(Bank bank)
        {
            _context.Banks.Add(bank);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Bank bank)
        {
            _context.Entry(bank).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ulong id)
        {
            var bank = await _context.Banks.FindAsync(id);
            _context.Banks.Remove(bank);
            await _context.SaveChangesAsync();
        }
    }
}