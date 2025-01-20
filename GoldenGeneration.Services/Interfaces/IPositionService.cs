using GoldenGeneration.Services.Models;

namespace GoldenGeneration.Services.Interfaces
{
    public interface IPositionService
    {
        Task<PositionModel[]> GetAllAsync();
        Task<PositionModel> GetByIdAsync(int id);
        Task<int> AddAsync(PositionModel position);
        Task RemoveAsync(int id);
    }
}
