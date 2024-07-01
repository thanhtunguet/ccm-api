using CCM.Core;
using CCM.Models;
using CCM.Routes;
using CCM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCM.Controllers;

[ApiController]
[Route(StoreRoute.ApiPrefix)]
public class StoreController(StoreService service) : GenericController<Store>(service)
{
}