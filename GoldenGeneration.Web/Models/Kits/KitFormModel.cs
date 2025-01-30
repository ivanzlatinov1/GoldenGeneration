using System.ComponentModel.DataAnnotations;

namespace GoldenGeneration.Web.Models.Kits
{
    public class KitFormModel
    {
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 2)]
        public string PrimaryColor { get; set; }
        [StringLength(30, MinimumLength = 2)]
        public string SecondaryColor { get; set; }
        public string BadgeUrl { get; set; }
        public string Sponsor { get; set; }
    }
}