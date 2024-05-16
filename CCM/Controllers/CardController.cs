using CCM.Models;
using CCM.Routes;
using CCM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCM.Controllers;

[ApiController]
[Route(CardRoute.ApiPrefix)]
public class CardController(CardService service) : ControllerBase
{
    [HttpPost(CardRoute.List)]
    public Task<List<Card>> GetAllCards()
    {
        return service.ListAllCardsAsync();
    }

    [HttpPost(CardRoute.GetById)]
    public Task<Card> GetCardById(ulong id)
    {
        return service.GetCardByIdAsync(id);
    }

    [HttpPost(CardRoute.Create)]
    public Task CreateCard(Card card)
    {
        return service.CreateCardAsync(card);
    }

    [HttpPost(CardRoute.Update)]
    public Task UpdateCard(ulong id, Card card)
    {
        card.Id = id; // Ensure the provided id matches the entity id
        return service.UpdateCardAsync(card);
    }

    [HttpPost(CardRoute.Delete)]
    public Task DeleteCard(ulong id)
    {
        return service.DeleteCardAsync(id);
    }

    [HttpPost(CardRoute.Count)]
    public Task<int> GetCardCount()
    {
        return service.CountCardsAsync();
    }

    [HttpPost("sync-bin")]
    public Task<long> SyncBin()
    {
        return service.SyncBin();
    }
}