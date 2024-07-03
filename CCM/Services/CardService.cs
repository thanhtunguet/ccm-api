using CCM.Core;
using CCM.Filters;
using CCM.Models;
using CCM.Repositories;

namespace CCM.Services;

public class CardService(CardRepository repository) : GenericService<Card>(repository)
{
    public async Task<IEnumerable<Card>> ListAllAsync(CardFilter filter)
    {
        return await repository.ListAllAsync(filter);
    }

    public async Task<int> CountAllAsync(CardFilter filter)
    {
        return await repository.CountAllAsync(filter);
    }
}