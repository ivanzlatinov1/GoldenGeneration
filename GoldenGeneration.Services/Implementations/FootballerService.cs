using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Infrastructure.Repositories;
using GoldenGeneration.Infrastructure.Repositories.Readers;
using GoldenGeneration.Services.Interfaces;
using GoldenGeneration.Services.Mappers;
using GoldenGeneration.Services.Models;

namespace GoldenGeneration.Services.Implementations
{
    public class FootballerService(UnitOfWork unitOfWork, Writes<Footballer> writes,
        FootballerReads reads) : IFootballerService
    {
        public async Task<FootballerModel[]> GetAllAsync()
        {
            Footballer[] footballers = await reads.AllAsync();

            return [.. footballers.Select(x => x.ToModel())];
        }

        public async Task<FootballerModel> GetByIdAsync(string id)
        {
            var footballer = await GetFootballerById(id);
            return footballer.ToModel();
        }

        public async Task<string> AddAsync(FootballerModel footballer)
        {
            var entity = await writes.AddAsync(footballer.ToEntity());
            await unitOfWork.SaveChangesAsync();
            return entity.Id;
        }

        public async Task RemoveAsync(string id)
        {
            var footballer = await GetFootballerById(id);
            writes.Remove(footballer);
            await unitOfWork.SaveChangesAsync();
        }

        private async Task<Footballer> GetFootballerById(string id)
            => await reads.SingleByIdAsync(id)
                    ?? throw new KeyNotFoundException($"Footballer with id: {id} is not found.");
    }
}