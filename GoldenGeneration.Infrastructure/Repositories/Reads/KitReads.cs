using GoldenGeneration.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Infrastructure.Repositories.Readers
{
    public class KitReads
    {
        private readonly GoldenGenerationDbContext _context;
        public KitReads()
        {
        }
        public KitReads(GoldenGenerationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<Kit[]> AllAsync()
            => await _context.Kits.ToArrayAsync();

        public virtual async Task<Kit?> SingleByIdAsync(int id)
            => await _context.Kits.FirstOrDefaultAsync(c => c.Id == id);
    }
}
