using CCM.Core;
using CCM.Models;

namespace CCM.Repositories;

public class TransactionStatusRepository(CcmContext context) : GenericRepository<TransactionStatus>(context)
{
}