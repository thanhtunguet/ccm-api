using CCM.Core;
using CCM.Models;
using CCM.Routes;
using CCM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCM.Controllers;

[ApiController]
[Route(CardClassRoute.ApiPrefix)]
public class CardClassController(CardClassService service) : GenericController<CardClass>(service)
{
}