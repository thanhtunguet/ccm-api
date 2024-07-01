using CCM.Core;
using CCM.Models;
using CCM.Routes;
using CCM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCM.Controllers;

[ApiController]
[Route(TransactionStatusRoute.ApiPrefix)]
public class TransactionStatusController(TransactionStatusService service)
    : GenericController<TransactionStatus>(service)
{
}