using System.ComponentModel.DataAnnotations;

namespace GoldenGeneration.Services.Models
{
    public class LeagueModel
    {
        public int Id { get; set; }
        [StringLength(32, MinimumLength = 2)]
        public string Name { get; set; }
    }
}
