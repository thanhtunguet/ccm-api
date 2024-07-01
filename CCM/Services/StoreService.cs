using CCM.Core;
using CCM.Models;
using CCM.Repositories;

namespace CCM.Services;

public class StoreService(StoreRepository repository) : GenericService<Store>(repository)
{
}