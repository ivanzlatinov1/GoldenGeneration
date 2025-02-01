using GoldenGeneration.Infrastructure;
using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Services.Interfaces;
using GoldenGeneration.Services.Mappers;
using GoldenGeneration.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Services.Implementations
{
    public class FootballerService(GoldenGenerationDbContext context) : IFootballerService
    {
        public async Task<FootballerModel[]> GetAllAsync()
        {
            Footballer[] footballers = await context.Footballers
                .Include(x => x.Position)
                .Include(x => x.Club)
                .ToArrayAsync();

            return [.. footballers.Select(x => x.ToModel())];
        }

        public async Task<FootballerModel> GetByIdAsync(string id)
        {
            var footballer = await GetFootballerById(id);
            return footballer.ToModel();
        }

        public async Task<string> AddAsync(FootballerModel footballer)
        {
            var entry = await context.Footballers.AddAsync(footballer.ToEntity());
            Footballer entity = entry.Entity;
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task RemoveAsync(string id)
        {
            var footballer = await GetFootballerById(id);
            context.Remove(footballer);
        }

        private async Task<Footballer> GetFootballerById(string id)
            => await context.Footballers
                   .Include(x => x.Position)
                   .Include(x => x.Club)
                   .FirstOrDefaultAsync(x => x.Id == id)
                    ?? throw new KeyNotFoundException($"Footballer with id: {id} is not found.");
    }
}