using GoldenGeneration.Services.Models;

namespace GoldenGeneration.Services.Interfaces
{
    public interface IKitService
    {
        Task<KitModel[]> GetAllAsync();
        Task<KitModel> GetByIdAsync(int id);
        Task<int> AddAsync(KitModel kit);
        Task RemoveAsync(int id);
    }
}
