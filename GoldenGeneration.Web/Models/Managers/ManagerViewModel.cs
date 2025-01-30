using GoldenGeneration.Infrastructure.Entities.JoinedEntities;

namespace GoldenGeneration.Web.Models.Managers
{
    public class ManagerViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public ICollection<ManagerClub> ManagerClubs { get; set; } = new List<ManagerClub>();
    }
}
