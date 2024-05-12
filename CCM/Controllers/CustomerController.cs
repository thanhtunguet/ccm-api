using CCM.Models;
using CCM.Routes;
using CCM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCM.Controllers;

[ApiController]
[Route(CustomerRoute.ApiPrefix)]
public class CustomerController : ControllerBase
{
    private readonly CustomerService _service;

    public CustomerController(CustomerService service)
    {
        _service = service;
    }

    [HttpPost(CustomerRoute.List)]
    public Task<List<Customer>> GetAllCustomers()
    {
        return _service.ListAllCustomersAsync();
    }

    [HttpPost(CustomerRoute.GetById)]
    public Task<Customer> GetCustomerById(ulong id)
    {
        return _service.GetCustomerByIdAsync(id);
    }

    [HttpPost(CustomerRoute.Create)]
    public Task CreateCustomer(Customer customer)
    {
        return _service.CreateCustomerAsync(customer);
    }

    [HttpPost(CustomerRoute.Update)]
    public Task UpdateCustomer(ulong id, Customer customer)
    {
        customer.Id = id; // Ensure the provided id matches the entity id
        return _service.UpdateCustomerAsync(customer);
    }

    [HttpPost(CustomerRoute.Delete)]
    public Task DeleteCustomer(ulong id)
    {
        return _service.DeleteCustomerAsync(id);
    }

    [HttpPost(CustomerRoute.Count)]
    public Task<int> GetCustomerCount()
    {
        return _service.CountCustomersAsync();
    }
}