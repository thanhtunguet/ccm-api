using CCM.Models;
using CCM.Repositories;

namespace CCM.Services;

public class CardService(CardRepository repository)
{
    public Task<List<Card>> ListAllCardsAsync()
    {
        return repository.ListAllAsync();
    }

    public Task<Card> GetCardByIdAsync(ulong id)
    {
        return repository.GetByIdAsync(id);
    }

    public Task CreateCardAsync(Card card)
    {
        return repository.CreateAsync(card);
    }

    public Task UpdateCardAsync(Card card)
    {
        return repository.UpdateAsync(card);
    }

    public Task DeleteCardAsync(ulong id)
    {
        return repository.DeleteAsync(id);
    }

    public Task<int> CountCardsAsync()
    {
        return repository.CountAsync();
    }
}