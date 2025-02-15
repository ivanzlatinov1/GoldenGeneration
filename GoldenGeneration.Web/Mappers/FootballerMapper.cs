using GoldenGeneration.Services.Models;
using GoldenGeneration.Web.Models.Footballers;

namespace GoldenGeneration.Web.Mappers
{
    public static class FootballerMapper
    {
        public static FootballerModel ToModel(this FootballerFormModel form, bool firstTime = true)
            => new()
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Age = form.Age,
                Nationality = form.Nationality,
                PositionId = form.PositionId,
                ClubId = form.ClubId,
                ShirtNumber = form.ShirtNumber,
                TransferPrice = form.TransferPrice,
                ImageUrl = form.ImageUrl,
                Retired = form.Retired,
            };

        public static FootballerViewModel ToView(this FootballerModel model, bool firstTime = true)
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
                ImageUrl = model.ImageUrl,
                Position = firstTime ? model.Position.ToView(false) : null!,
                Club = firstTime ? model.Club.ToView(false) : null!
            };
    }
}