using CCM.Core;
using CCM.Models;
using CCM.Repositories;

namespace CCM.Services;

public class TransactionStatusService(TransactionStatusRepository repository)
    : GenericService<TransactionStatus>(repository)
{
}