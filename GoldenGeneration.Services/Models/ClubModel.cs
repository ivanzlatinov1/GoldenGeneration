using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Infrastructure.Entities.JoinedEntities;
using System.ComponentModel.DataAnnotations;

namespace GoldenGeneration.Services.Models
{
    public class ClubModel
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
        public KitModel Kit { get; set; }
        public ManagerModel Manager { get; set; }
        public LeagueModel League { get; set; }
        public ICollection<ManagerClub> ManagerClubs { get; set; } = new List<ManagerClub>();
    }
}
