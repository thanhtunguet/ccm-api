using CCM.Models;
using CCM.Routes;
using CCM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCM.Controllers;

[ApiController]
[Route(BankRoute.ApiPrefix)]
public class BankController(BankService service) : ControllerBase
{
    [HttpPost(BankRoute.List)]
    public Task<List<Bank>> GetAllBanks()
    {
        return service.ListAllBanksAsync();
    }

    [HttpPost(BankRoute.GetById)]
    public Task<Bank> GetBankById(ulong id)
    {
        return service.GetBankByIdAsync(id);
    }

    [HttpPost(BankRoute.Create)]
    public Task CreateBank(Bank bank)
    {
        return service.CreateBankAsync(bank);
    }

    [HttpPost(BankRoute.Update)]
    public Task UpdateBank(ulong id, Bank bank)
    {
        bank.Id = id; // Ensure the provided id matches the entity id
        return service.UpdateBankAsync(bank);
    }

    [HttpPost(BankRoute.Delete)]
    public Task DeleteBank(ulong id)
    {
        return service.DeleteBankAsync(id);
    }

    [HttpPost(BankRoute.Count)]
    public Task<int> GetBankCount()
    {
        return service.CountBanksAsync();
    }
}