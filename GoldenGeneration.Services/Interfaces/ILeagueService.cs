using GoldenGeneration.Services.Models;

namespace GoldenGeneration.Services.Interfaces
{
    public interface ILeagueService
    {
        Task<LeagueModel[]> GetAllAsync();
        Task<LeagueModel> GetByIdAsync(int id);
        Task<int> AddAsync(LeagueModel league);
        Task RemoveAsync(int id);
    }
}
