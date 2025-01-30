using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Services.Models;

namespace GoldenGeneration.Services.Mappers
{
    public static class ClubMapper
    {
        public static ClubModel ToModel(this Club entity, bool firstTime = true)
            => new()
            {
                Id = entity.Id,
                Name = entity.Name,
                LeagueId = entity.LeagueId,
                ManagerId = entity.ManagerId,
                Stadium = entity.Stadium,
                ChampionsLeagueTitlesCount = entity.ChampionsLeagueTitlesCount,
                LeagueWinnerTitlesCount = entity.LeagueWinnerTitlesCount,
                KitId = entity.KitId,
                Kit = firstTime ? entity.Kit.ToModel(false) : null!,
                Manager = firstTime ? entity.Manager.ToModel(false) : null!,
                League = firstTime ? entity.League.ToModel(false) : null!,
                ManagerClubs = entity.ManagerClubs
            };

        public static Club ToEntity(this ClubModel model, bool firstTime = true)
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
                Kit = firstTime ? model.Kit.ToEntity(false) : null!,
                Manager = firstTime ? model.Manager.ToEntity(false) : null!,
                League = firstTime ? model.League.ToEntity(false) : null!,
                ManagerClubs = model.ManagerClubs
            };
    }
}
