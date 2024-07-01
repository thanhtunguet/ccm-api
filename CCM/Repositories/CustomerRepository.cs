using CCM.Core;
using CCM.Models;
using Microsoft.EntityFrameworkCore;

namespace CCM.Repositories;

public class CustomerRepository(CcmContext context) : GenericRepository<Customer>(context)
{
}