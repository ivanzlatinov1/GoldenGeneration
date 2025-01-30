using GoldenGeneration.Services.Models;
using GoldenGeneration.Web.Models.Managers;

namespace GoldenGeneration.Web.Mappers
{
    public static class ManagerMapper
    {
        public static ManagerModel ToModel(this ManagerFormModel form, bool firstTime = true)
            => new()
            {
                Id = form.Id,
                FirstName = form.FirstName,
                LastName = form.LastName,
                Age = form.Age,
                Nationality = form.Nationality
            };

        public static ManagerViewModel ToView(this ManagerModel model, bool firstTime = true)
            => new()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Nationality = model.Nationality,
                ManagerClubs = model.ManagerClubs
            };
    }
}
