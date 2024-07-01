using CCM.Core;
using CCM.Models;
using CCM.Routes;
using CCM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCM.Controllers;

[ApiController]
[Route(CustomerRoute.ApiPrefix)]
public class CustomerController(CustomerService service) : GenericController<Customer>(service)
{
}