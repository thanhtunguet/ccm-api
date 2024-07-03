using CCM.Core;
using CCM.Filters;
using CCM.Models;
using Microsoft.EntityFrameworkCore;

namespace CCM.Repositories;

public class CardRepository(CcmContext context) : GenericRepository<Card>(context)
{
    private readonly DbSet<CardClass> _cardClassDbSet = context.Set<CardClass>();


    public async Task<IEnumerable<Card>> ListAllAsync(CardFilter filter)
    {
        var query = _dbSet.AsQueryable();
        query = IncludeRelatedEntities(query);

        if (filter.CardTypeId.HasValue)
        {
            var today = DateTime.Today.Day;
            var tomorrow = DateTime.Today.AddDays(1).Day;

            IQueryable<CardClass> cardClassQuery = _cardClassDbSet.AsQueryable();

            switch (filter.CardTypeId.Value)
            {
                case CardType.All:
                    // No additional filtering needed, handled by pagination below
                    break;
                case CardType.StatementDate:
                    cardClassQuery =
                        cardClassQuery.Where(cc => cc.StatementDate == today || cc.StatementDate == tomorrow);
                    var statementDateCardClassIds = await cardClassQuery.Select(cc => cc.Id).ToListAsync();
                    query = query.Where(c =>
                        c.CardClassId.HasValue && statementDateCardClassIds.Contains(c.CardClassId.Value));
                    break;
                case CardType.DueDate:
                    cardClassQuery = cardClassQuery.Where(cc => cc.DueDate == today || cc.DueDate == tomorrow);
                    var dueDateCardClassIds = await cardClassQuery.Select(cc => cc.Id).ToListAsync();
                    query = query.Where(
                        c => c.CardClassId.HasValue && dueDateCardClassIds.Contains(c.CardClassId.Value));
                    break;
            }
        }

        // Apply search filter
        if (!string.IsNullOrEmpty(filter.Search))
        {
            // Apply search logic here, e.g., using reflection
        }

        // Apply ordering
        if (!string.IsNullOrEmpty(filter.OrderBy))
        {
            query = filter.OrderType == DataFilter.Desc
                ? query.OrderByDescending(e => EF.Property<object>(e, filter.OrderBy))
                : query.OrderBy(e => EF.Property<object>(e, filter.OrderBy));
        }

        // Apply pagination
        if (filter.CardTypeId == CardType.All)
        {
            query = query.Skip(filter.Skip).Take(filter.Take);
        }

        return await query.ToListAsync();
    }

    public async Task<int> CountAllAsync(CardFilter filter)
    {
        var query = _dbSet.AsQueryable();

        if (filter.CardTypeId.HasValue)
        {
            var today = DateTime.Today.Day;
            var tomorrow = DateTime.Today.AddDays(1).Day;

            IQueryable<CardClass> cardClassQuery = _cardClassDbSet.AsQueryable();

            switch (filter.CardTypeId.Value)
            {
                case CardType.All:
                    // No additional filtering needed
                    break;
                case CardType.StatementDate:
                    cardClassQuery =
                        cardClassQuery.Where(cc => cc.StatementDate == today || cc.StatementDate == tomorrow);
                    var statementDateCardClassIds = await cardClassQuery.Select(cc => cc.Id).ToListAsync();
                    query = query.Where(c =>
                        c.CardClassId.HasValue && statementDateCardClassIds.Contains(c.CardClassId.Value));
                    break;
                case CardType.DueDate:
                    cardClassQuery = cardClassQuery.Where(cc => cc.DueDate == today || cc.DueDate == tomorrow);
                    var dueDateCardClassIds = await cardClassQuery.Select(cc => cc.Id).ToListAsync();
                    query = query.Where(
                        c => c.CardClassId.HasValue && dueDateCardClassIds.Contains(c.CardClassId.Value));
                    break;
            }
        }

        // Apply search filter
        if (!string.IsNullOrEmpty(filter.Search))
        {
            // Apply search logic here
        }

        return await query.CountAsync();
    }
}