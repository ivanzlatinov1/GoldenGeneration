using GoldenGeneration.Services.Models;
using GoldenGeneration.Web.Models.Clubs;

namespace GoldenGeneration.Web.Mappers
{
    public static class ClubMapper
    {
        public static ClubModel ToModel(this ClubFormModel form, bool firstTime = true)
            => new()
            {
                Id = form.Id,
                Name = form.Name,
                LeagueId = form.LeagueId,
                ManagerId = form.ManagerId,
                Stadium = form.Stadium,
                ChampionsLeagueTitlesCount = form.ChampionsLeagueTitlesCount,
                LeagueWinnerTitlesCount = form.LeagueWinnerTitlesCount,
                KitId = form.KitId
            };

        public static ClubViewModel ToView(this ClubModel model, bool firstTime = true)
            => new()
            {
                Id = model.Id,
                Name = model.Name,
                LeagueId = model.LeagueId,
                ManagerId = model.ManagerId,
                Stadium = model.Stadium,
                ChampionsLeagueTitlesCount = model.ChampionsLeagueTitlesCount,
                LeagueWinnerTitlesCount = model.LeagueWinnerTitlesCount,
                KitId = model.KitId,
                Kit = firstTime ? model.Kit.ToView(false) : null!,
                Manager = firstTime ? model.Manager.ToView(false) : null!,
                League = firstTime ? model.League.ToView(false) : null!,
                ManagerClubs = model.ManagerClubs
            };
    }
}
