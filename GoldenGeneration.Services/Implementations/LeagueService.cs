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
    public class LeagueService(UnitOfWork unitOfWork, Writes<League> writes,
        LeagueReads reads) : ILeagueService
    {
        public async Task<LeagueModel[]> GetAllAsync()
        {
            League[] leagues = await reads.AllAsync();
            return [.. leagues.Select(x => x.ToModel())];
        }

        public async Task<LeagueModel> GetByIdAsync(int id)
        {
            var league = await GetLeagueById(id);
            return league.ToModel();
        }

        public async Task<int> AddAsync(LeagueModel league)
        {
            var entity = await writes.AddAsync(league.ToEntity());
            await unitOfWork.SaveChangesAsync();
            return entity.Id;
        }

        public async Task RemoveAsync(int id)
        {
            var league = await GetLeagueById(id);
            writes.Remove(league);
            await unitOfWork.SaveChangesAsync();
        }

        private async Task<League> GetLeagueById(int id)
            => await reads.SingleByIdAsync(id)
               ?? throw new KeyNotFoundException($"League with id: {id} is not found.");
    }
}
