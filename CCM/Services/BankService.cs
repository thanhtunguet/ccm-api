using CCM.Core;
using CCM.Models;
using CCM.Repositories;

namespace CCM.Services;

public class BankService(BankRepository repository) : GenericService<Bank>(repository)
{
}