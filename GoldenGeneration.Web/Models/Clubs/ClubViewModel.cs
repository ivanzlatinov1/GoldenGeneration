using GoldenGeneration.Infrastructure.Entities.JoinedEntities;
using GoldenGeneration.Web.Models.Kits;
using GoldenGeneration.Web.Models.Leagues;
using GoldenGeneration.Web.Models.Managers;

namespace GoldenGeneration.Web.Models.Clubs
{
    public class ClubViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int LeagueId { get; set; }
        public string ManagerId { get; set; }
        public string Stadium { get; set; }
        public int ChampionsLeagueTitlesCount { get; set; }
        public int LeagueWinnerTitlesCount { get; set; }
        public int KitId { get; set; }
        public KitViewModel Kit { get; set; }
        public ManagerViewModel Manager { get; set; }
        public LeagueViewModel League { get; set; }
        public ICollection<ManagerClub> ManagerClubs { get; set; } = new List<ManagerClub>();
    }
}
