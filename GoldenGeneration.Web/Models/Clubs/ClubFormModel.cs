using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Infrastructure.Entities.JoinedEntities;
using System.ComponentModel.DataAnnotations;
using GoldenGeneration.Web.Models.Kits;
using GoldenGeneration.Web.Models.Leagues;
using GoldenGeneration.Web.Models.Managers;

namespace GoldenGeneration.Web.Models.Clubs
{
    public class ClubFormModel
    {
        public string Id { get; set; }
        [StringLength(60, MinimumLength = 2)]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int LeagueId { get; set; }
        public string ManagerId { get; set; }
        [StringLength(70, MinimumLength = 2)]
        public string Stadium { get; set; }
        public int ChampionsLeagueTitlesCount { get; set; }
        public int LeagueWinnerTitlesCount { get; set; }
        public int KitId { get; set; }
        public LeagueViewModel[] Leagues { get; set; }
        public ManagerViewModel[] Managers { get; set; }
        public KitViewModel[] Kits { get; set; }
    }
}
