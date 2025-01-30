using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Services.Models;

namespace GoldenGeneration.Services.Mappers
{
    public static class LeagueMapper
    {
        public static LeagueModel ToModel(this League entity, bool firstTime = true)
            => new()
            {
                Id = entity.Id,
                Name = entity.Name
            };

        public static League ToEntity(this LeagueModel model, bool firstTime = true)
            => new()
            {
                Id = model.Id,
                Name = model.Name
            };
    }
}
