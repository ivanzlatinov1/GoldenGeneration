using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Services.Models;
using GoldenGeneration.Web.Models.Clubs;
using System.ComponentModel.DataAnnotations;
using GoldenGeneration.Web.Models.Positions;

namespace GoldenGeneration.Web.Models.Footballers
{
    public class FootballerFormModel
    {
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
        public string ImageUrl { get; set; }
        public decimal TransferPrice { get; set; }
        public bool Retired { get; set; }
        public ClubViewModel[] Clubs { get; set; }
        public PositionViewModel[] Positions { get; set; }
    }
}
