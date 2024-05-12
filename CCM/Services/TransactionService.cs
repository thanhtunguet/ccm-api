using System.Collections.Generic;
using System.Threading.Tasks;
using CCM.Repositories;
using CCM.Models;

namespace CCM.Services
{
    public class TransactionService
    {
        private readonly TransactionRepository _repository;

        public TransactionService(TransactionRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Transaction>> ListAllTransactionsAsync()
        {
            return _repository.ListAllAsync();
        }

        public Task<Transaction> GetTransactionByIdAsync(ulong id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task CreateTransactionAsync(Transaction transaction)
        {
            return _repository.CreateAsync(transaction);
        }

        public Task UpdateTransactionAsync(Transaction transaction)
        {
            return _repository.UpdateAsync(transaction);
        }

        public Task DeleteTransactionAsync(ulong id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<int> CountTransactionsAsync()
        {
            return _repository.CountAsync();
        }
    }
}