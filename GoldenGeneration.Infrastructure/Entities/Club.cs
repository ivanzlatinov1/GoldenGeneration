using GoldenGeneration.Infrastructure.Entities.JoinedEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenGeneration.Infrastructure.Entities
{
    public class Club
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        public int LeagueId { get; set; }
        public string ManagerId { get; set; }
        [MaxLength(70)]
        public string Stadium { get; set; }
        public int ChampionsLeagueTitlesCount { get; set; }
        public int LeagueWinnerTitlesCount { get; set; }
        public int KitId { get; set; }

        [ForeignKey(nameof(KitId))]
        public Kit Kit { get; set; }

        [ForeignKey(nameof(ManagerId))]
        public Manager Manager { get; set; }

        [ForeignKey(nameof(LeagueId))]
        public League League { get; set; }
        public ICollection<ManagerClub> ManagerClubs { get; set; } = new List<ManagerClub>();
    }
}
