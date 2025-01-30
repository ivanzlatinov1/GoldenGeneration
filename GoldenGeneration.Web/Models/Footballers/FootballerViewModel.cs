using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Services.Models;
using GoldenGeneration.Web.Models.Clubs;
using GoldenGeneration.Web.Models.Positions;

namespace GoldenGeneration.Web.Models.Footballers
{
    public class FootballerViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public int PositionId { get; set; }
        public string ClubId { get; set; }
        public int ShirtNumber { get; set; }
        public decimal TransferPrice { get; set; }
        public bool Retired { get; set; }
        public PositionViewModel Position { get; set; }
        public ClubViewModel Club { get; set; }
    }
}
