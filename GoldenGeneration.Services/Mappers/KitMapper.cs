using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Services.Models;

namespace GoldenGeneration.Services.Mappers
{
    public static class KitMapper
    {
        public static KitModel ToModel(this Kit entity, bool firstTime = true)
            => new()
            {
                Id = entity.Id,
                PrimaryColor = entity.PrimaryColor,
                SecondaryColor = entity.SecondaryColor,
                BadgeUrl = entity.BadgeUrl,
                Sponsor = entity.Sponsor,
            };

        public static Kit ToEntity(this KitModel model, bool firstTime = true)
            => new()
            {
                Id = model.Id,
                PrimaryColor = model.PrimaryColor,
                SecondaryColor = model.SecondaryColor,
                BadgeUrl = model.BadgeUrl,
                Sponsor = model.Sponsor,
            };
    }
}
