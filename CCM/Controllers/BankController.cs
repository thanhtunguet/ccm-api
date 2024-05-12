using CCM.Models;
using CCM.Routes;
using CCM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCM.Controllers;

[ApiController]
[Route(BankRoute.ApiPrefix)]
public class BankController : ControllerBase
{
    private readonly BankService _service;

    public BankController(BankService service)
    {
        _service = service;
    }

    [HttpPost(BankRoute.List)]
    public Task<List<Bank>> GetAllBanks()
    {
        return _service.ListAllBanksAsync();
    }

    [HttpPost(BankRoute.GetById)]
    public Task<Bank> GetBankById(ulong id)
    {
        return _service.GetBankByIdAsync(id);
    }

    [HttpPost(BankRoute.Create)]
    public Task CreateBank(Bank bank)
    {
        return _service.CreateBankAsync(bank);
    }

    [HttpPost(BankRoute.Update)]
    public Task UpdateBank(ulong id, Bank bank)
    {
        bank.Id = id; // Ensure the provided id matches the entity id
        return _service.UpdateBankAsync(bank);
    }

    [HttpPost(BankRoute.Delete)]
    public Task DeleteBank(ulong id)
    {
        return _service.DeleteBankAsync(id);
    }

    [HttpPost(BankRoute.Count)]
    public Task<int> GetBankCount()
    {
        return _service.CountBanksAsync();
    }
}