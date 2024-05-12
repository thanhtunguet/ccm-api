using CCM.Models;
using CCM.Repositories;

namespace CCM.Services;

public class CustomerService(CustomerRepository repository)
{
    public Task<List<Customer>> ListAllCustomersAsync()
    {
        return repository.ListAllAsync();
    }

    public Task<Customer> GetCustomerByIdAsync(ulong id)
    {
        return repository.GetByIdAsync(id);
    }

    public Task CreateCustomerAsync(Customer customer)
    {
        return repository.CreateAsync(customer);
    }

    public Task UpdateCustomerAsync(Customer customer)
    {
        return repository.UpdateAsync(customer);
    }

    public Task DeleteCustomerAsync(ulong id)
    {
        return repository.DeleteAsync(id);
    }

    public Task<int> CountCustomersAsync()
    {
        return repository.CountAsync();
    }
}