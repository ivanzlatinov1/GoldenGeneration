using System.ComponentModel.DataAnnotations;

namespace GoldenGeneration.Infrastructure.Entities
{
    public class Position
    {
        [Key]
        public int Id { get; }
        [Required]
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }
}
