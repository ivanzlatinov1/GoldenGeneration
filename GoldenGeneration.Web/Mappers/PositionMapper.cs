using GoldenGeneration.Services.Models;
using GoldenGeneration.Web.Models.Positions;

namespace GoldenGeneration.Web.Mappers
{
    public static class PositionMapper
    {
        public static PositionModel ToModel(this PositionFormModel form, bool firstTime = true)
            => new()
            {
                Id = form.Id,
                Name = form.Name,
                Abbreviation = form.Abbreviation
            };

        public static PositionViewModel ToView(this PositionModel model, bool firstTime = true)
            => new()
            {
                Id = model.Id,
                Name = model.Name,
                Abbreviation = model.Abbreviation
            };
    }
}
