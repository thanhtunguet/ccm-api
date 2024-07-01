using CCM.Core;
using CCM.Models;
using Microsoft.EntityFrameworkCore;

namespace CCM.Repositories;

public class BankRepository(CcmContext context) : GenericRepository<Bank>(context)
{
}