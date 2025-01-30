using GoldenGeneration.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace GoldenGeneration.Services.Models
{
    public class FootballerModel
    {
        public string Id { get; set; }
        [StringLength(60, MinimumLength = 2)]
        public string FirstName { get; set; }
        [StringLength(60, MinimumLength = 2)]
        public string LastName { get; set; }
        public int Age { get; set; }
        [StringLength(60, MinimumLength = 2)]
        public string Nationality { get; set; }
        public int PositionId { get; set; }
        public string ClubId { get; set; }
        public int ShirtNumber { get; set; }
        public decimal TransferPrice { get; set; }
        public bool Retired { get; set; }
        public PositionModel Position { get; set; }
        public ClubModel Club { get; set; }
    }
}
