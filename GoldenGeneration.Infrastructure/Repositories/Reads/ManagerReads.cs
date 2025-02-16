using GoldenGeneration.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Infrastructure.Repositories.Readers
{
    public class ManagerReads
    {
        private readonly GoldenGenerationDbContext _context;
        public ManagerReads()
        {
        }
        public ManagerReads(GoldenGenerationDbContext context)
        {
            _context = context;
        }
        public virtual async Task<Manager[]> AllAsync()
            => await _context.Managers.ToArrayAsync();

        public virtual async Task<Manager?> SingleByIdAsync(string id)
            => await _context.Managers.FirstOrDefaultAsync(c => c.Id == id);
    }
}
