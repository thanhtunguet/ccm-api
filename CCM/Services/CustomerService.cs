using CCM.Core;
using CCM.Models;
using CCM.Repositories;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace CCM.Services;

public class CustomerService(CustomerRepository repository) : GenericService<Customer>(repository)
{
}