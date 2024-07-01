using Microsoft.EntityFrameworkCore;

namespace CCM.Core;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> ListAllAsync(DataFilter filter);
    Task<int> CountAllAsync(DataFilter filter);
    Task<TEntity?> GetByIdAsync(ulong id);
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(ulong id);
}

public class GenericRepository<TEntity>(DbContext context) : IGenericRepository<TEntity>
    where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    private IQueryable<TEntity> IncludeRelatedEntities(IQueryable<TEntity> query)
    {
        var navigationProperties = typeof(TEntity).GetProperties()
            .Where(p => p.PropertyType.IsGenericType &&
                        typeof(IEnumerable<>).IsAssignableFrom(p.PropertyType.GetGenericTypeDefinition()) ||
                        p.PropertyType.IsClass && p.PropertyType != typeof(string));

        foreach (var property in navigationProperties)
        {
            query = query.Include(property.Name);
        }

        return query;
    }

    public async Task<IEnumerable<TEntity>> ListAllAsync(DataFilter filter)
    {
        var query = _dbSet.AsQueryable();
        query = IncludeRelatedEntities(query);

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
        query = query.Skip(filter.Skip).Take(filter.Take);

        return await query.ToListAsync();
    }

    public async Task<int> CountAllAsync(DataFilter filter)
    {
        var query = _dbSet.AsQueryable();

        // Apply search filter
        if (!string.IsNullOrEmpty(filter.Search))
        {
            // Apply search logic here
        }

        return await query.CountAsync();
    }

    public async Task<TEntity?> GetByIdAsync(ulong id)
    {
        var query = _dbSet.AsQueryable();
        query = IncludeRelatedEntities(query);

        return await query.FirstOrDefaultAsync(e => EF.Property<ulong>(e, "Id") == id);
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        _dbSet.Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(ulong id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null)
        {
            return false;
        }

        _dbSet.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
}