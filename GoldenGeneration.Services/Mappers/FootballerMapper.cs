using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Services.Models;

namespace GoldenGeneration.Services.Mappers
{
    public static class FootballerMapper
    {
        public static FootballerModel ToModel(this Footballer entity)
            => new()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age,
                Nationality = entity.Nationality,
                PositionId = entity.PositionId,
                ClubId = entity.ClubId,
                ShirtNumber = entity.ShirtNumber,
                TransferPrice = entity.TransferPrice,
                Retired = entity.Retired,
                Position = entity.Position,
                Club = entity.Club.ToModel()
            };

        public static Footballer ToEntity(this FootballerModel model)
            => new()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Nationality = model.Nationality,
                PositionId = model.PositionId,
                ClubId = model.ClubId,
                ShirtNumber = model.ShirtNumber,
                TransferPrice = model.TransferPrice,
                Retired = model.Retired,
                Position = model.Position,
                Club = model.Club.ToEntity()
            };
    }
}