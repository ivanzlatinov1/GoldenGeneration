using GoldenGeneration.Services.Models;
using GoldenGeneration.Web.Models.Kits;

namespace GoldenGeneration.Web.Mappers
{
    public static class KitMapper
    {
        public static KitModel ToModel(this KitFormModel form, bool firstTime = true)
            => new()
            {
                Id = form.Id,
                PrimaryColor = form.PrimaryColor,
                SecondaryColor = form.SecondaryColor,
                BadgeUrl = form.BadgeUrl,
                Sponsor = form.Sponsor,
            };

        public static KitViewModel ToView(this KitModel model, bool firstTime = true)
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
