using GoldenGeneration.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Infrastructure.Repositories.Readers
{
    public class LeagueReads
    {
        private readonly GoldenGenerationDbContext _context;
        public LeagueReads()
        {
        }
        public LeagueReads(GoldenGenerationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<League[]> AllAsync()
            => await _context.League.ToArrayAsync();

        public virtual async Task<League?> SingleByIdAsync(int id)
            => await _context.League.FirstOrDefaultAsync(c => c.Id == id);
    }
}
