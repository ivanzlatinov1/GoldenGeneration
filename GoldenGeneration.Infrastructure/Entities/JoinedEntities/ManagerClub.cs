using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenGeneration.Infrastructure.Entities.JoinedEntities
{
    public class ManagerClub
    {
        public string ManagerId { get; set; }
        public string ClubId { get; set; }

        [ForeignKey(nameof(ManagerId))]
        public Manager Manager { get; set; }

        [ForeignKey(nameof(ClubId))]
        public Club Club { get; set; }
    }
}
