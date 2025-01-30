using System.ComponentModel.DataAnnotations;

namespace GoldenGeneration.Web.Models.Leagues
{
    public class LeagueFormModel
    {
        public int Id { get; set; }
        [StringLength(32, MinimumLength = 2)]
        public string Name { get; set; }
    }
}
