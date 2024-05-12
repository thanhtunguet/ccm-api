using CCM.Models;
using Microsoft.EntityFrameworkCore;

namespace CCM.Repositories;

public class CustomerRepository(CcmContext context)
{
    public async Task<List<Customer>> ListAllAsync()
    {
        return await context.Customers.ToListAsync();
    }

    public async Task<Customer> GetByIdAsync(ulong id)
    {
        return await context.Customers.FindAsync(id);
    }

    public async Task CreateAsync(Customer customer)
    {
        context.Customers.Add(customer);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer customer)
    {
        context.Entry(customer).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(ulong id)
    {
        var customer = await context.Customers.FindAsync(id);
        context.Customers.Remove(customer);
        await context.SaveChangesAsync();
    }

    public async Task<int> CountAsync()
    {
        return await context.Customers.CountAsync();
    }
}