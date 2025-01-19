using GoldenGeneration.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Infrastructure
{
    public class GoldenGenerationDbContext : DbContext
    {
        public GoldenGenerationDbContext(DbContextOptions<GoldenGenerationDbContext> opt)
            : base(opt)
        {
        }
        public required DbSet<Position> Positions { get; set; }
        public required DbSet<Footballer> Footballers { get; set; }
    }
}
