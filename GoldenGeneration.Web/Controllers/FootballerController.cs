using GoldenGeneration.Services.Interfaces;
using GoldenGeneration.Web.Mappers;
using GoldenGeneration.Web.Models.Footballers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static GoldenGeneration.Infrastructure.Constants;

namespace GoldenGeneration.Web.Controllers
{
    public class FootballerController(IFootballerService service, IClubService clubService,
    IPositionService positionService): Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var pageSize = 9;
            var footballers = await service.GetAllAsync();

            var pagedFootballers = footballers
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => x.ToView())
                .ToArray();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)footballers.Count() / pageSize);

            return View(pagedFootballers);
        }


        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var footballer = await service.GetByIdAsync(id);
            return View(footballer.ToView());
        }

        [Authorize(Admin)]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var clubs = await clubService.GetAllAsync();
            var positions = await positionService.GetAllAsync();
            FootballerFormModel form = new()
            {
                Clubs = clubs.Select(x => x.ToView()).ToArray(),
                Positions = positions.Select(x => x.ToView()).ToArray()
            };
            return View(form);
        }

        [Authorize(Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FootballerFormModel form)
        {
            try
            {
                await service.AddAsync(form.ToModel());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var clubs = await clubService.GetAllAsync();
                var positions = await positionService.GetAllAsync();

                form.Clubs = clubs.Select(x => x.ToView()).ToArray();
                form.Positions = positions.Select(x => x.ToView()).ToArray();

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
