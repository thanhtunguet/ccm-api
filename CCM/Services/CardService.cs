using CCM.Core;
using CCM.Models;
using CCM.Repositories;

namespace CCM.Services;

public class CardService(CardRepository repository) : GenericService<Card>(repository)
{
}