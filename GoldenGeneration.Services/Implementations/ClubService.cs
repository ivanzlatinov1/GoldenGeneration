using GoldenGeneration.Infrastructure;
using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Services.Interfaces;
using GoldenGeneration.Services.Mappers;
using GoldenGeneration.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Services.Implementations
{
    public class ClubService(GoldenGenerationDbContext context) : IClubService
    {
        public async Task<ClubModel[]> GetAllAsync()
        {
            Club[] clubs = await context.Clubs
                .Include(x => x.Kit)
                .Include(x => x.Manager)
                .Include(x => x.League)
                .ToArrayAsync();

            return [.. clubs.Select(x => x.ToModel())];
        }

        public async Task<ClubModel> GetByIdAsync(string id)
        {
            var club = await GetClubById(id);
            return club.ToModel();
        }

        public async Task<string> AddAsync(ClubModel club)
        {
            var entry = await context.Clubs.AddAsync(club.ToEntity());
            Club entity = entry.Entity;
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task RemoveAsync(string id)
        {
            var club = await GetClubById(id);
            context.Remove(club);
        }

        private async Task<Club> GetClubById(string id)
            => await context.Clubs
                   .Include(x => x.Kit)
                   .Include(x => x.Manager)
                   .Include(x => x.League)
                   .FirstOrDefaultAsync(x => x.Id == id)
               ?? throw new KeyNotFoundException($"Club with id: {id} is not found.");
    }
}
