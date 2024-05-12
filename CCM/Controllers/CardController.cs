using CCM.Routes;
using CCM.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CCM.Models;

namespace CCM.Controllers
{
    [ApiController]
    [Route(CardRoute.ApiPrefix)]
    public class CardController : ControllerBase
    {
        private readonly CardService _service;

        public CardController(CardService service)
        {
            _service = service;
        }

        [HttpPost(CardRoute.List)]
        public Task<List<Card>> GetAllCards()
        {
            return _service.ListAllCardsAsync();
        }

        [HttpPost(CardRoute.GetById)]
        public Task<Card> GetCardById(ulong id)
        {
            return _service.GetCardByIdAsync(id);
        }

        [HttpPost(CardRoute.Create)]
        public Task CreateCard(Card card)
        {
            return _service.CreateCardAsync(card);
        }

        [HttpPost(CardRoute.Update)]
        public Task UpdateCard(ulong id, Card card)
        {
            card.Id = id; // Ensure the provided id matches the entity id
            return _service.UpdateCardAsync(card);
        }

        [HttpPost(CardRoute.Delete)]
        public Task DeleteCard(ulong id)
        {
            return _service.DeleteCardAsync(id);
        }

        [HttpPost(CardRoute.Count)]
        public Task<int> GetCardCount()
        {
            return _service.CountCardsAsync();
        }
    }
}