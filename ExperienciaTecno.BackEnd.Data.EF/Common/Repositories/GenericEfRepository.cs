using ExperienciaTecno.BackEnd.Core.Common.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExperienciaTecno.BackEnd.Data.EF.Common.Repositories;

public class GenericEfRepository<T, TDbContext> : IGenericRepository<T> where T : class where TDbContext : DbContext
{
    protected TDbContext DbContext { get; }
    protected DbSet<T> EntitySet { get; }


    public GenericEfRepository(TDbContext dbContext)
    {
        DbContext = dbContext;
        EntitySet = DbContext.Set<T>();
    }

    public T? Get(Expression<Func<T, bool>> expression)
        => EntitySet.FirstOrDefault(expression);

    public async Task<T?> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        => await EntitySet.FirstOrDefaultAsync(expression, cancellationToken);


    public IEnumerable<T> GetAll()
        => EntitySet.AsEnumerable();

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
        => EntitySet.Where(expression).AsEnumerable();

    public void Add(T entity)
        => DbContext.Add(entity);

    public void AddRange(IEnumerable<T> entities)
        => DbContext.AddRange(entities);

    public async Task AddRangeAsync(IEnumerable<T> entities)
        => await DbContext.AddRangeAsync(entities);

    public void Remove(T entity)
        => DbContext.Remove(entity);

    public void RemoveRange(IEnumerable<T> entities)
        => DbContext.RemoveRange(entities);

    public void Update(T entity)
        => DbContext.Update(entity);

    public void UpdateRange(IEnumerable<T> entities)
        => DbContext.UpdateRange(entities);

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        => await EntitySet.ToListAsync(cancellationToken);

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        => await EntitySet.Where(expression).ToListAsync(cancellationToken);

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        => await DbContext.AddAsync(entity, cancellationToken);

    public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        => await DbContext.AddRangeAsync(entities, cancellationToken);
}