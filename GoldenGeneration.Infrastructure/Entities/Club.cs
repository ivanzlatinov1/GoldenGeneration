using System.ComponentModel.DataAnnotations;

namespace GoldenGeneration.Infrastructure.Entities
{
    public class Club
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public int LeagueId { get; set; }
        public string ManagerId { get; set; }
        public string Stadium { get; set; }
        public int ChampionsLeagueTitlesCount { get; set; }
        public int LeagueWinnerTitlesCount { get; set; }
        public int KitId { get; set; }
    }
}
