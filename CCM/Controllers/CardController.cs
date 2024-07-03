using CCM.Core;
using CCM.Filters;
using CCM.Models;
using CCM.Routes;
using CCM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCM.Controllers;

[ApiController]
[Route(CardRoute.ApiPrefix)]
public class CardController(CardService service) : GenericController<Card>(service)
{
    [HttpPost(CardRoute.ListByType)]
    public async Task<ActionResult<IEnumerable<Card>>> ListAllAsync([FromBody] CardFilter filter)
    {
        var entities = await service.ListAllAsync(filter);
        return Ok(entities);
    }

    [HttpPost(CardRoute.CountByType)]
    public async Task<ActionResult<int>> CountAllAsync([FromBody] CardFilter filter)
    {
        var count = await service.CountAllAsync(filter);
        return Ok(count);
    }
}