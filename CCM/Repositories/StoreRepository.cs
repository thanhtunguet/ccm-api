using CCM.Core;
using CCM.Models;
using Microsoft.EntityFrameworkCore;

namespace CCM.Repositories;

public class StoreRepository(CcmContext context) : GenericRepository<Store>(context)
{
}