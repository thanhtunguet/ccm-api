using CCM.Core;
using CCM.Models;
using Microsoft.EntityFrameworkCore;

namespace CCM.Repositories;

public class CardClassRepository(CcmContext context) : GenericRepository<CardClass>(context)
{
}