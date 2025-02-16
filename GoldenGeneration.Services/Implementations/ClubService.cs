using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Infrastructure.Repositories;
using GoldenGeneration.Infrastructure.Repositories.Readers;
using GoldenGeneration.Services.Interfaces;
using GoldenGeneration.Services.Mappers;
using GoldenGeneration.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Services.Implementations
{
    public class ClubService(UnitOfWork unitOfWork, Writes<Club> writes,
        ClubReads reads) : IClubService
    {
        public async Task<ClubModel[]> GetAllAsync()
        {
            Club[] clubs = await reads.AllAsync();

            return [.. clubs.Select(x => x.ToModel())];
        }

        public async Task<ClubModel> GetByIdAsync(string id)
        {
            var club = await GetClubById(id);
            return club.ToModel();
        }

        public async Task<string> AddAsync(ClubModel club)
        {
            var entity = await writes.AddAsync(club.ToEntity());
            await unitOfWork.SaveChangesAsync();
            return entity.Id;
        }

        public async Task RemoveAsync(string id)
        {
            var club = await GetClubById(id);
            writes.Remove(club);
            await unitOfWork.SaveChangesAsync();
        }

        private async Task<Club> GetClubById(string id)
            => await reads.SingleByIdAsync(id)
               ?? throw new KeyNotFoundException($"Club with id: {id} is not found.");
    }
}
