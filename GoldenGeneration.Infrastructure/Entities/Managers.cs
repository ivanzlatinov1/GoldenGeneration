using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Infrastructure.Entities
{
    public class Managers
    {
        [Key]
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
    }
}
