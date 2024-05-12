using CCM.Models;
using CCM.Routes;
using CCM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCM.Controllers;

[ApiController]
[Route(CardClassRoute.ApiPrefix)]
public class CardClassController(CardClassService service) : ControllerBase
{
    [HttpPost(CardClassRoute.List)]
    public Task<List<CardClass>> GetAllCardClasses()
    {
        return service.ListAllCardClassesAsync();
    }

    [HttpPost(CardClassRoute.GetById)]
    public Task<CardClass> GetCardClassById(ulong id)
    {
        return service.GetCardClassByIdAsync(id);
    }

    [HttpPost(CardClassRoute.Create)]
    public Task CreateCardClass(CardClass cardClass)
    {
        return service.CreateCardClassAsync(cardClass);
    }

    [HttpPost(CardClassRoute.Update)]
    public Task UpdateCardClass(ulong id, CardClass cardClass)
    {
        cardClass.Id = id; // Ensure the provided id matches the entity id
        return service.UpdateCardClassAsync(cardClass);
    }

    [HttpPost(CardClassRoute.Delete)]
    public Task DeleteCardClass(ulong id)
    {
        return service.DeleteCardClassAsync(id);
    }

    [HttpPost(CardClassRoute.Count)]
    public Task<int> GetCardClassCount()
    {
        return service.CountCardClassesAsync();
    }
}