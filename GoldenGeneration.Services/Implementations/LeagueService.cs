using GoldenGeneration.Infrastructure;
using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Services.Interfaces;
using GoldenGeneration.Services.Mappers;
using GoldenGeneration.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Services.Implementations
{
    public class LeagueService(GoldenGenerationDbContext context) : ILeagueService
    {
        public async Task<LeagueModel[]> GetAllAsync()
        {
            League[] leagues = await context.League.ToArrayAsync();
            return [.. leagues.Select(x => x.ToModel())];
        }

        public async Task<LeagueModel> GetByIdAsync(int id)
        {
            var league = await GetLeagueById(id);
            return league.ToModel();
        }

        public async Task<int> AddAsync(LeagueModel league)
        {
            var entry = await context.League.AddAsync(league.ToEntity());
            League entity = entry.Entity;
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task RemoveAsync(int id)
        {
            var league = await GetLeagueById(id);
            context.Remove(league);
        }

        private async Task<League> GetLeagueById(int id)
            => await context.League.FirstOrDefaultAsync(x => x.Id == id)
               ?? throw new KeyNotFoundException($"League with id: {id} is not found.");
    }
}
