using GoldenGeneration.Services.Models;

namespace GoldenGeneration.Services.Interfaces
{
    public interface IFootballerService
    {
        Task<FootballerModel[]> GetAllAsync();
        Task<FootballerModel> GetByIdAsync(string id);
        Task<string> AddAsync(FootballerModel footballer);
        Task RemoveAsync(string id);
    }
}
