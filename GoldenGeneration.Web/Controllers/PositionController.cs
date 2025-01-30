using GoldenGeneration.Services.Interfaces;
using GoldenGeneration.Web.Mappers;
using GoldenGeneration.Web.Models.Positions;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult Create()
        {
            PositionFormModel form = new();
            return View(form);
        }

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
