namespace GoldenGeneration.Infrastructure.Repositories;

public class Writes<TEntity> where TEntity : class
{
    private readonly GoldenGenerationDbContext _context;
    public Writes()
    {
    }
    public Writes(GoldenGenerationDbContext context)
    {
        _context = context;
    }
    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken ct = default)
        => (await _context.Set<TEntity>().AddAsync(entity, ct).ConfigureAwait(false)).Entity;

    public virtual void Remove(TEntity entity)
        => _context.Set<TEntity>().Remove(entity);
}