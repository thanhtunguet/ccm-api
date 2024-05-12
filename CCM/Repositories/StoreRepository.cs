using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCM.Models;

namespace CCM.Repositories
{
    public class StoreRepository
    {
        private readonly CcmContext _context;

        public StoreRepository(CcmContext context)
        {
            _context = context;
        }

        public async Task<List<Store>> ListAllAsync()
        {
            return await _context.Stores.ToListAsync();
        }

        public async Task<Store> GetByIdAsync(ulong id)
        {
            return await _context.Stores.FindAsync(id);
        }

        public async Task CreateAsync(Store store)
        {
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Store store)
        {
            _context.Entry(store).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ulong id)
        {
            var store = await _context.Stores.FindAsync(id);
            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Stores.CountAsync();
        }
    }
}