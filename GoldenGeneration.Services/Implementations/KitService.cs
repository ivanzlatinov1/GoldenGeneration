using GoldenGeneration.Infrastructure;
using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Services.Interfaces;
using GoldenGeneration.Services.Mappers;
using GoldenGeneration.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Services.Implementations
{
    public class KitService(GoldenGenerationDbContext context) : IKitService
    {
        public async Task<KitModel[]> GetAllAsync()
        {
            Kit[] kits = await context.Kits.ToArrayAsync();
            return [.. kits.Select(x => x.ToModel())];
        }

        public async Task<KitModel> GetByIdAsync(int id)
        {
            var kit = await GetKitById(id);
            return kit.ToModel();
        }

        public async Task<int> AddAsync(KitModel kit)
        {
            var entry = await context.Kits.AddAsync(kit.ToEntity());
            Kit entity = entry.Entity;
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task RemoveAsync(int id)
        {
            var kit = await GetKitById(id);
            context.Remove(kit);
        }

        private async Task<Kit> GetKitById(int id)
            => await context.Kits.FirstOrDefaultAsync(x => x.Id == id)
               ?? throw new KeyNotFoundException($"Kit with id: {id} is not found.");
    }
}
