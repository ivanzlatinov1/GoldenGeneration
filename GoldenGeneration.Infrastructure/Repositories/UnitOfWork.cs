namespace GoldenGeneration.Infrastructure.Repositories;

public class UnitOfWork
{
    private readonly GoldenGenerationDbContext _context;
    public UnitOfWork()
    {
    }
    public UnitOfWork(GoldenGenerationDbContext context)
    {
        this._context = context;
    }
    public virtual async Task SaveChangesAsync(CancellationToken ct = default)
    {
        await _context.SaveChangesAsync(ct);
    }
}