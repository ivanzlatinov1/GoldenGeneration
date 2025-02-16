using System.Collections;
using GoldenGeneration.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Infrastructure.Repositories.Readers
{
    public class FootballerReads
    {
        private readonly GoldenGenerationDbContext _context;
        public FootballerReads()
        {
        }
        public FootballerReads(GoldenGenerationDbContext context)
        {
            _context = context;
        }
        public virtual async Task<Footballer[]> AllAsync()
            => await _context.Footballers
                .Include(x => x.Position)
                .Include(x => x.Club)
                .ToArrayAsync();

        public virtual async Task<Footballer?> SingleByIdAsync(string id)
            => await _context.Footballers
                .Include(x => x.Position)
                .Include(x => x.Club)
                .FirstOrDefaultAsync(c => c.Id == id);
    }
}