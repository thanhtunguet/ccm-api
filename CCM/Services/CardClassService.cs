using CCM.Models;
using CCM.Repositories;

namespace CCM.Services;

public class CardClassService(CardClassRepository repository)
{
    public Task<List<CardClass>> ListAllCardClassesAsync()
    {
        return repository.ListAllAsync();
    }

    public Task<CardClass> GetCardClassByIdAsync(ulong id)
    {
        return repository.GetByIdAsync(id);
    }

    public Task CreateCardClassAsync(CardClass cardClass)
    {
        return repository.CreateAsync(cardClass);
    }

    public Task UpdateCardClassAsync(CardClass cardClass)
    {
        return repository.UpdateAsync(cardClass);
    }

    public Task DeleteCardClassAsync(ulong id)
    {
        return repository.DeleteAsync(id);
    }

    public Task<int> CountCardClassesAsync()
    {
        return repository.CountAsync();
    }
}