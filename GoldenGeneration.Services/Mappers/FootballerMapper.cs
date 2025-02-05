using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Services.Models;

namespace GoldenGeneration.Services.Mappers
{
    public static class FootballerMapper
    {
        public static FootballerModel ToModel(this Footballer entity, bool firstTime = true)
            => new()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age,
                Nationality = entity.Nationality,
                ImageUrl = entity.ImageUrl,
                PositionId = entity.PositionId,
                ClubId = entity.ClubId,
                ShirtNumber = entity.ShirtNumber,
                TransferPrice = entity.TransferPrice,
                Retired = entity.Retired,
                Position = firstTime ? entity.Position.ToModel(false) : null!,
                Club = firstTime ? entity.Club.ToModel(false) : null!
            };

        public static Footballer ToEntity(this FootballerModel model, bool firstTime = true)
            => new()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Nationality = model.Nationality,
                ImageUrl = model.ImageUrl,
                PositionId = model.PositionId,
                ClubId = model.ClubId,
                ShirtNumber = model.ShirtNumber,
                TransferPrice = model.TransferPrice,
                Retired = model.Retired,
                Position = null!,
                Club = null!
            };
    }
}