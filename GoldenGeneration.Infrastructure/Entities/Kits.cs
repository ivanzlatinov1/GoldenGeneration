using System.ComponentModel.DataAnnotations;

namespace GoldenGeneration.Infrastructure.Entities
{
    public class Kits
    {
        [Key]
        public int Id { get; }

        public string ClubId { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string BadgeUrl { get; set; }
        public string Sponsor { get; set; }
    }
}
