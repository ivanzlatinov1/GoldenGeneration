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
    public class KitService(UnitOfWork unitOfWork, Writes<Kit> writes,
        KitReads reads) : IKitService
    {
        public async Task<KitModel[]> GetAllAsync()
        {
            Kit[] kits = await reads.AllAsync();
            return [.. kits.Select(x => x.ToModel())];
        }

        public async Task<KitModel> GetByIdAsync(int id)
        {
            var kit = await GetKitById(id);
            return kit.ToModel();
        }

        public async Task<int> AddAsync(KitModel kit)
        {
            var entity = await writes.AddAsync(kit.ToEntity());
            await unitOfWork.SaveChangesAsync();
            return entity.Id;
        }

        public async Task RemoveAsync(int id)
        {
            var kit = await GetKitById(id);
            writes.Remove(kit);
            await unitOfWork.SaveChangesAsync();
        }

        private async Task<Kit> GetKitById(int id)
            => await reads.SingleByIdAsync(id)
               ?? throw new KeyNotFoundException($"Kit with id: {id} is not found.");
    }
}
