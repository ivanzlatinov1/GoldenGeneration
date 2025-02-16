using GoldenGeneration.Infrastructure;
using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Infrastructure.Repositories.Readers;
using GoldenGeneration.Infrastructure.Repositories;
using GoldenGeneration.Services.Interfaces;
using GoldenGeneration.Services.Mappers;
using GoldenGeneration.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Services.Implementations
{
    public class ManagerService(UnitOfWork unitOfWork, Writes<Manager> writes,
        ManagerReads reads) : IManagerService
    {
        public async Task<ManagerModel[]> GetAllAsync()
        {
            Manager[] managers = await reads.AllAsync();
            return [.. managers.Select(x => x.ToModel())];
        }

        public async Task<ManagerModel> GetByIdAsync(string id)
        {
            var manager = await GetManagerById(id);
            return manager.ToModel();
        }

        public async Task<string> AddAsync(ManagerModel manager)
        {
            var entity = await writes.AddAsync(manager.ToEntity());
            await unitOfWork.SaveChangesAsync();
            return entity.Id;
        }

        public async Task RemoveAsync(string id)
        {
            var manager = await GetManagerById(id);
            writes.Remove(manager);
            await unitOfWork.SaveChangesAsync();
        }

        private async Task<Manager> GetManagerById(string id)
            => await reads.SingleByIdAsync(id)
               ?? throw new KeyNotFoundException($"Manager with id: {id} is not found.");
    }
}
