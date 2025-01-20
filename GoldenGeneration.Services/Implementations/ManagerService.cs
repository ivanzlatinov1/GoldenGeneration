using GoldenGeneration.Infrastructure;
using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Services.Interfaces;
using GoldenGeneration.Services.Mappers;
using GoldenGeneration.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Services.Implementations
{
    public class ManagerService(GoldenGenerationDbContext context) : IManagerService
    {
        public async Task<ManagerModel[]> GetAllAsync()
        {
            Manager[] managers = await context.Managers.ToArrayAsync();
            return [.. managers.Select(x => x.ToModel())];
        }

        public async Task<ManagerModel> GetByIdAsync(string id)
        {
            var manager = await GetManagerById(id);
            return manager.ToModel();
        }

        public async Task<string> AddAsync(ManagerModel manager)
        {
            var entry = await context.Managers.AddAsync(manager.ToEntity());
            Manager entity = entry.Entity;
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task RemoveAsync(string id)
        {
            var manager = await GetManagerById(id);
            context.Remove(manager);
        }

        private async Task<Manager> GetManagerById(string id)
            => await context.Managers.FirstOrDefaultAsync(x => x.Id == id)
               ?? throw new KeyNotFoundException($"Manager with id: {id} is not found.");
    }
}
