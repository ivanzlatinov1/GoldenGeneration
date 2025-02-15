using GoldenGeneration.Services.Interfaces;
using GoldenGeneration.Web.Mappers;
using GoldenGeneration.Web.Models.Clubs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static GoldenGeneration.Infrastructure.Constants;

namespace GoldenGeneration.Web.Controllers
{
    public class ClubController(IClubService service): Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clubs = await service.GetAllAsync();
            return View(clubs.Select(x => x.ToView()).ToArray());
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var club = await service.GetByIdAsync(id);
            return View(club.ToView());
        }

        [Authorize(Admin)]
        [HttpGet]
        public IActionResult Create()
        {
            ClubFormModel form = new();
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
