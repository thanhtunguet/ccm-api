using System.Collections.Generic;
using System.Threading.Tasks;
using CCM.Models;
using CCM.Repositories;

namespace CCM.Services
{
    public class CardClassService
    {
        private readonly CardClassRepository _repository;

        public CardClassService(CardClassRepository repository)
        {
            _repository = repository;
        }

        public Task<List<CardClass>> ListAllCardClassesAsync()
        {
            return _repository.ListAllAsync();
        }

        public Task<CardClass> GetCardClassByIdAsync(ulong id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task CreateCardClassAsync(CardClass cardClass)
        {
            return _repository.CreateAsync(cardClass);
        }

        public Task UpdateCardClassAsync(CardClass cardClass)
        {
            return _repository.UpdateAsync(cardClass);
        }

        public Task DeleteCardClassAsync(ulong id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<int> CountCardClassesAsync()
        {
            return _repository.CountAsync();
        }
    }
}