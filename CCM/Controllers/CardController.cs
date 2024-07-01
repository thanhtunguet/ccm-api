using CCM.Core;
using CCM.Models;
using CCM.Routes;
using CCM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCM.Controllers;

[ApiController]
[Route(CardRoute.ApiPrefix)]
public class CardController(CardService service) : GenericController<Card>(service)
{
}