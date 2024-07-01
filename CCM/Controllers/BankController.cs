using CCM.Core;
using CCM.Models;
using CCM.Routes;
using CCM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCM.Controllers;

[ApiController]
[Route(BankRoute.ApiPrefix)]
public class BankController(BankService service) : GenericController<Bank>(service)
{
}