using GoldenGeneration.Services.Interfaces;
using GoldenGeneration.Web.Mappers;
using GoldenGeneration.Web.Models.Positions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static GoldenGeneration.Infrastructure.Constants;

namespace GoldenGeneration.Web.Controllers
{
    public class PositionController(IPositionService service): Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var positions = await service.GetAllAsync();
            return View(positions.Select(x => x.ToView()).ToArray());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var position = await service.GetByIdAsync(id);
            return View(position.ToView());
        }

        [Authorize(Admin)]
        [HttpGet]
        public IActionResult Create()
        {
            PositionFormModel form = new();
            return View(form);
        }

        [Authorize(Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PositionFormModel form)
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
