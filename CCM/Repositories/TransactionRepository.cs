using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCM.Models;

namespace CCM.Repositories
{
    public class TransactionRepository
    {
        private readonly CcmContext _context;

        public TransactionRepository(CcmContext context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> ListAllAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction> GetByIdAsync(ulong id)
        {
            return await _context.Transactions.FindAsync(id);
        }

        public async Task CreateAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Transaction transaction)
        {
            _context.Entry(transaction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ulong id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Transactions.CountAsync();
        }
    }
}
