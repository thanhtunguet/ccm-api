using CCM.Core;
using CCM.Models;
using Microsoft.EntityFrameworkCore;

namespace CCM.Repositories;

public class CardRepository(CcmContext context) : GenericRepository<Card>(context)
{
}