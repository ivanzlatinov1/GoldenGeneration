using GoldenGeneration.Services.Interfaces;
using GoldenGeneration.Web.Mappers;
using GoldenGeneration.Web.Models.Clubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static GoldenGeneration.Infrastructure.Constants;

namespace GoldenGeneration.Web.Controllers
{
    public class ClubController(IClubService service, ILeagueService leagueService,
        IManagerService managerService, IKitService kitService): Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var pageSize = 9;
            var clubs = await service.GetAllAsync();

            var pagedClubs = clubs
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => x.ToView())
                .ToArray();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)clubs.Count() / pageSize);

            return View(pagedClubs);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var club = await service.GetByIdAsync(id);
            return View(club.ToView());
        }

        [Authorize(Admin)]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var leagues = await leagueService.GetAllAsync();
            var managers = await managerService.GetAllAsync();
            var kits = await kitService.GetAllAsync();

            ClubFormModel form = new()
            {
                Leagues = leagues.Select(x => x.ToView()).ToArray(),
                Managers = managers.Select(x => x.ToView()).ToArray(),
                Kits = kits.Select(x => x.ToView()).ToArray()
            };
            return View(form);
        }

        [Authorize(Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClubFormModel form)
        {
            try
            {
                await service.AddAsync(form.ToModel());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var leagues = await leagueService.GetAllAsync();
                var managers = await managerService.GetAllAsync();
                var kits = await kitService.GetAllAsync();

                form.Leagues = leagues.Select(x => x.ToView()).ToArray();
                form.Managers = managers.Select(x => x.ToView()).ToArray();
                form.Kits = kits.Select(x => x.ToView()).ToArray();

                return View(form);
            }
        }

        [Authorize(Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
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
