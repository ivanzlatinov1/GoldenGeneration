using GoldenGeneration.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Infrastructure.Repositories.Readers
{
    public class ClubReads
    {
        private readonly GoldenGenerationDbContext _context;
        public ClubReads()
        {
        }
        public ClubReads(GoldenGenerationDbContext context)
        {
            _context = context;
        }
        public virtual async Task<Club[]> AllAsync()
            => await _context.Clubs
                .Include(x => x.Kit)
                .Include(x => x.Manager)
                .Include(x => x.League)
                .ToArrayAsync();

        public virtual async Task<Club?> SingleByIdAsync(string id)
            => await _context.Clubs
                .Include(x => x.Kit)
                .Include(x => x.Manager)
                .Include(x => x.League)
                .FirstOrDefaultAsync(c => c.Id == id);
    }
}
