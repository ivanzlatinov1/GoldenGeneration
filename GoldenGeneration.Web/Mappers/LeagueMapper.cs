using GoldenGeneration.Services.Models;
using GoldenGeneration.Web.Models.Leagues;

namespace GoldenGeneration.Web.Mappers
{
    public static class LeagueMapper
    {
        public static LeagueModel ToModel(this LeagueFormModel form, bool firstTime = true)
            => new()
            {
                Id = form.Id,
                Name = form.Name
            };

        public static LeagueViewModel ToView(this LeagueModel model, bool firstTime = true)
            => new()
            {
                Id = model.Id,
                Name = model.Name
            };
    }
}
