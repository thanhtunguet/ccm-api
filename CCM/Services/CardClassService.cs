using CCM.Core;
using CCM.Models;
using CCM.Repositories;

namespace CCM.Services;

public class CardClassService(CardClassRepository repository) : GenericService<CardClass>(repository)
{
}