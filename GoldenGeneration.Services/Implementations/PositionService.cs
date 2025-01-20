using GoldenGeneration.Infrastructure;
using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Services.Interfaces;
using GoldenGeneration.Services.Mappers;
using GoldenGeneration.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Services.Implementations
{
    public class PositionService(GoldenGenerationDbContext context) : IPositionService
    {
        public async Task<PositionModel[]> GetAllAsync()
        {
            Position[] positions = await context.Positions.ToArrayAsync();
            return [.. positions.Select(x => x.ToModel())];
        }

        public async Task<PositionModel> GetByIdAsync(int id)
        {
            var position = await GetPositionById(id);
            return position.ToModel();
        }

        public async Task<int> AddAsync(PositionModel position)
        {
            var entry = await context.Positions.AddAsync(position.ToEntity());
            Position entity = entry.Entity;
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task RemoveAsync(int id)
        {
            var position = await GetPositionById(id);
            context.Remove(position);
        }

        private async Task<Position> GetPositionById(int id)
            => await context.Positions.FirstOrDefaultAsync(x => x.Id == id)
               ?? throw new KeyNotFoundException($"Position with id: {id} is not found.");
    }
}