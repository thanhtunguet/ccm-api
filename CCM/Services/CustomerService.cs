using System.Collections.Generic;
using System.Threading.Tasks;
using CCM.Models;
using CCM.Repositories;

namespace CCM.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _repository;

        public CustomerService(CustomerRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Customer>> ListAllCustomersAsync()
        {
            return _repository.ListAllAsync();
        }

        public Task<Customer> GetCustomerByIdAsync(ulong id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task CreateCustomerAsync(Customer customer)
        {
            return _repository.CreateAsync(customer);
        }

        public Task UpdateCustomerAsync(Customer customer)
        {
            return _repository.UpdateAsync(customer);
        }

        public Task DeleteCustomerAsync(ulong id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<int> CountCustomersAsync()
        {
            return _repository.CountAsync();
        }
    }
}