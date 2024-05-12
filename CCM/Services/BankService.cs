using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using CCM.Models;
using CCM.Repositories;

namespace CCM.Services
{
    public class BankService
    {
        private readonly BankRepository _repository;

        public BankService(BankRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Bank>> ListAllBanksAsync()
        {
            return _repository.ListAllAsync(includeCardClasses: true);
        }

        public Task<int> CountBanksAsync()
        {
            return _repository.CountAsync();
        }

        public Task<Bank> GetBankByIdAsync(ulong id)
        {
            return _repository.GetByIdAsync(id, includeCardClasses: true);
        }

        public Task CreateBankAsync(Bank bank)
        {
            return _repository.CreateAsync(bank);
        }

        public Task UpdateBankAsync(Bank bank)
        {
            return _repository.UpdateAsync(bank);
        }

        public Task DeleteBankAsync(ulong id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}