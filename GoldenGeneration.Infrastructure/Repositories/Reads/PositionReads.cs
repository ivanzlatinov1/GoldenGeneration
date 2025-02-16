using GoldenGeneration.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Infrastructure.Repositories.Readers
{
    public class PositionReads
    {
        private readonly GoldenGenerationDbContext _context;
        public PositionReads()
        {
        }
        public PositionReads(GoldenGenerationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<Position[]> AllAsync()
            => await _context.Positions.ToArrayAsync();

        public virtual async Task<Position?> SingleByIdAsync(int id)
            => await _context.Positions.FirstOrDefaultAsync(c => c.Id == id);
    }
}
