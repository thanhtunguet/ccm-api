using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCM.Models;

namespace CCM.Repositories
{
    public class CustomerRepository
    {
        private readonly CcmContext _context;

        public CustomerRepository(CcmContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> ListAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(ulong id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task CreateAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ulong id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Customers.CountAsync();
        }
    }
}