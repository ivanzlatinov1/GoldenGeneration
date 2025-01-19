using System.ComponentModel.DataAnnotations;

namespace GoldenGeneration.Infrastructure.Entities
{
    public class Footballer
    {
        [Key]
        public string Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public int PositionId { get; set; }
        public string ClubId { get; set; }
        public int ShirtNumber { get; set; }
        public decimal TransferPrice { get; set; }
        public bool Retired { get; set; }
    }
}
