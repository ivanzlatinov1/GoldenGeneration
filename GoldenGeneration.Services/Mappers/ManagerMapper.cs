using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Services.Models;

namespace GoldenGeneration.Services.Mappers
{
    public static class ManagerMapper
    {
        public static ManagerModel ToModel(this Manager entity, bool firstTime = true)
            => new()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age,
                Nationality = entity.Nationality,
                ManagerClubs = entity.ManagerClubs
            };

        public static Manager ToEntity(this ManagerModel model, bool firstTime = true)
            => new()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Nationality = model.Nationality,
                ManagerClubs = model.ManagerClubs
            };
    }
}
