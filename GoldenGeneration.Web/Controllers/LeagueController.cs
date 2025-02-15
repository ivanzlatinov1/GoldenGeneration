using GoldenGeneration.Services.Interfaces;
using GoldenGeneration.Web.Mappers;
using GoldenGeneration.Web.Models.Leagues;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static GoldenGeneration.Infrastructure.Constants;

namespace GoldenGeneration.Web.Controllers
{
    public class LeagueController(ILeagueService service): Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var leagues = await service.GetAllAsync();
            return View(leagues.Select(x => x.ToView()).ToArray());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var league = await service.GetByIdAsync(id);
            return View(league.ToView());
        }

        [Authorize(Admin)]
        [HttpGet]
        public IActionResult Create()
        {
            LeagueFormModel form = new();
            return View(form);
        }

        [Authorize(Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeagueFormModel form)
        {
            try
            {
                await service.AddAsync(form.ToModel());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(form);
            }
        }

        [Authorize(Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await service.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
