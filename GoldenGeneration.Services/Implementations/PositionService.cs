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
    public class PositionService(UnitOfWork unitOfWork, Writes<Position> writes,
        PositionReads reads) : IPositionService
    {
        public async Task<PositionModel[]> GetAllAsync()
        {
            Position[] positions = await reads.AllAsync();
            return [.. positions.Select(x => x.ToModel())];
        }

        public async Task<PositionModel> GetByIdAsync(int id)
        {
            var position = await GetPositionById(id);
            return position.ToModel();
        }

        public async Task<int> AddAsync(PositionModel position)
        {
            var entity = await writes.AddAsync(position.ToEntity());
            await unitOfWork.SaveChangesAsync();
            return entity.Id;
        }

        public async Task RemoveAsync(int id)
        {
            var position = await GetPositionById(id);
            writes.Remove(position);
            await unitOfWork.SaveChangesAsync();
        }

        private async Task<Position> GetPositionById(int id)
            => await reads.SingleByIdAsync(id)
               ?? throw new KeyNotFoundException($"Position with id: {id} is not found.");
    }
}