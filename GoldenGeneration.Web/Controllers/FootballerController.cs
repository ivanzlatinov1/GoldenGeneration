using GoldenGeneration.Services.Interfaces;
using GoldenGeneration.Web.Mappers;
using GoldenGeneration.Web.Models.Footballers;
using Microsoft.AspNetCore.Mvc;

namespace GoldenGeneration.Web.Controllers
{
    public class FootballerController(IFootballerService service): Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var footballers = await service.GetAllAsync();
            return View(footballers.Select(x => x.ToView()).ToArray());
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var footballer = await service.GetByIdAsync(id);
            return View(footballer.ToView());
        }

        [HttpGet]
        public IActionResult Create()
        {
            FootballerFormModel form = new();
            return View(form);
        }

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
                return View(form);
            }
        }

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
