using CCM.Models;
using CCM.Repositories;

namespace CCM.Services;

public class BankService(BankRepository repository)
{
    public Task<List<Bank>> ListAllBanksAsync()
    {
        return repository.ListAllAsync(true);
    }

    public Task<int> CountBanksAsync()
    {
        return repository.CountAsync();
    }

    public Task<Bank> GetBankByIdAsync(ulong id)
    {
        return repository.GetByIdAsync(id, true);
    }

    public Task CreateBankAsync(Bank bank)
    {
        return repository.CreateAsync(bank);
    }

    public Task UpdateBankAsync(Bank bank)
    {
        return repository.UpdateAsync(bank);
    }

    public Task DeleteBankAsync(ulong id)
    {
        return repository.DeleteAsync(id);
    }
}