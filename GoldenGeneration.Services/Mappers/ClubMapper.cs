using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Infrastructure.Entities.JoinedEntities;
using GoldenGeneration.Services.Models;

namespace GoldenGeneration.Services.Mappers
{
    public static class ClubMapper
    {
        public static ClubModel ToModel(this Club entity)
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
                Kit = entity.Kit,
                Manager = entity.Manager,
                League = entity.League,
                ManagerClubs = entity.ManagerClubs
            };

        public static Club ToEntity(this ClubModel model)
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
                Kit = model.Kit,
                Manager = model.Manager,
                League = model.League,
                ManagerClubs = model.ManagerClubs
            };
    }
}
