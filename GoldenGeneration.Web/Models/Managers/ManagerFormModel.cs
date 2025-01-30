using GoldenGeneration.Infrastructure.Entities.JoinedEntities;
using System.ComponentModel.DataAnnotations;

namespace GoldenGeneration.Web.Models.Managers
{
    public class ManagerFormModel
    {
        public string Id { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        public int Age { get; set; }
        [StringLength(60, MinimumLength = 2)]
        public string Nationality { get; set; }
    }
}
