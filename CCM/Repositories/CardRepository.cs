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

        query = await FilterByCardType(query, filter);

        query = SearchCard(query, filter);

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

        query = await FilterByCardType(query, filter);

        query = SearchCard(query, filter);

        return await query.CountAsync();
    }

    private async Task<IQueryable<Card>> FilterByCardType(IQueryable<Card> query, CardFilter filter)
    {
        var today = DateTime.Today.Day;
        var tomorrow = DateTime.Today.AddDays(1).Day;
        IQueryable<CardClass> cardClassQuery = _cardClassDbSet.AsQueryable();
        if (filter.CardTypeId.HasValue)
        {
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

        return query;
    }

    private IQueryable<Card> SearchCard(IQueryable<Card> query, CardFilter filter)
    {
        if (!string.IsNullOrEmpty(filter.Search))
        {
            query = query.Where((card) => card.Number.StartsWith(filter.Search));
        }

        return query;
    }

    public async Task<IEnumerable<Card>> SyncBinAsync()
    {
        var cards = await _dbSet.ToListAsync();
        var cardClasses = await _cardClassDbSet.ToListAsync();
        var updatedCards = new List<Card>();

        foreach (var card in cards)
        {
            if (card.Number.Length >= 6)
            {
                var bin = card.Number.Substring(0, 6);
                var cardClass = cardClasses.FirstOrDefault(cc => cc.Bin == bin);

                if (cardClass != null && card.CardClassId != cardClass.Id)
                {
                    card.CardClassId = cardClass.Id;
                    card.CardClass = cardClass;
                    updatedCards.Add(card);
                }
            }
        }

        await context.SaveChangesAsync();
        return updatedCards;
    }
}