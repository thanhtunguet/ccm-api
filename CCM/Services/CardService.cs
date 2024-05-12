using System.Collections.Generic;
using System.Threading.Tasks;
using CCM.Models;
using CCM.Repositories;

namespace CCM.Services
{
    public class CardService
    {
        private readonly CardRepository _repository;

        public CardService(CardRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Card>> ListAllCardsAsync()
        {
            return _repository.ListAllAsync();
        }

        public Task<Card> GetCardByIdAsync(ulong id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task CreateCardAsync(Card card)
        {
            return _repository.CreateAsync(card);
        }

        public Task UpdateCardAsync(Card card)
        {
            return _repository.UpdateAsync(card);
        }

        public Task DeleteCardAsync(ulong id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<int> CountCardsAsync()
        {
            return _repository.CountAsync();
        }
    }
}