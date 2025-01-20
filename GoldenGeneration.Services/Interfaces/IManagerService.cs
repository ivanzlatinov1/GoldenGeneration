using GoldenGeneration.Services.Models;

namespace GoldenGeneration.Services.Interfaces
{
    public interface IManagerService
    {
        Task<ManagerModel[]> GetAllAsync();
        Task<ManagerModel> GetByIdAsync(string id);
        Task<string> AddAsync(ManagerModel footballer);
        Task RemoveAsync(string id);
    }
}
