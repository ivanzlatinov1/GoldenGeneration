using GoldenGeneration.Services.Models;

namespace GoldenGeneration.Services.Interfaces
{
    public interface IClubService
    {
        Task<ClubModel[]> GetAllAsync();
        Task<ClubModel> GetByIdAsync(string id);
        Task<string> AddAsync(ClubModel club);
        Task RemoveAsync(string id);
    }
}
