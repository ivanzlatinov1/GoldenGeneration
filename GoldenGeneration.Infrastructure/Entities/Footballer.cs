using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenGeneration.Infrastructure.Entities
{
    public class Footballer
    {
        [Key]
        public string Id { get; set; }
        [MaxLength(60)]
        public string FirstName { get; set; }
        [MaxLength(60)]
        public string LastName { get; set; }
        public int Age { get; set; }
        [MaxLength(60)]
        public string Nationality { get; set; }
        public int PositionId { get; set; }
        public string ClubId { get; set; }
        public int ShirtNumber { get; set; }
        public decimal TransferPrice { get; set; }
        public bool Retired { get; set; }

        [ForeignKey(nameof(PositionId))]
        public Position Position { get; set; }

        [ForeignKey(nameof(ClubId))]
        public Club Club { get; set; }
    }
}
