using System.ComponentModel.DataAnnotations;

namespace GoldenGeneration.Infrastructure.Entities
{
    public class League
    {
        [Key]
        public int Id { get; }
        public string Name { get; set; }
    }
}
