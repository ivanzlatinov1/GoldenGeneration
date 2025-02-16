using GoldenGeneration.Services.Interfaces;
using GoldenGeneration.Web.Mappers;
using GoldenGeneration.Web.Models.DreamTeam;
using GoldenGeneration.Web.Models.Footballers;
using Microsoft.AspNetCore.Mvc;

namespace GoldenGeneration.Web.Controllers
{
    public class DreamTeamController(IFootballerService service) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var footballers = await service.GetAllAsync();
            var viewModel = new DreamTeamViewModel
            {
                AllFootballers = footballers.Select(x => x.ToView()).ToList(),
                SelectedFootballers = new List<FootballerViewModel>()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDreamTeam(DreamTeamViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var footballers = await service.GetAllAsync();
                model.AllFootballers = footballers.Select(x => x.ToView()).ToList();
                return View("Index", model);
            }

            return RedirectToAction("DreamTeamSummary", model);
        }

        [HttpGet]
        public IActionResult DreamTeamSummary(DreamTeamViewModel model)
        {
            return View(model);
        }
    }
}