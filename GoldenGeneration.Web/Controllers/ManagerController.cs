using GoldenGeneration.Services.Interfaces;
using GoldenGeneration.Web.Mappers;
using GoldenGeneration.Web.Models.Managers;
using Microsoft.AspNetCore.Mvc;

namespace GoldenGeneration.Web.Controllers
{
    public class ManagerController(IManagerService service): Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var managers = await service.GetAllAsync();
            return View(managers.Select(x => x.ToView()).ToArray());
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var manager = await service.GetByIdAsync(id);
            return View(manager.ToView());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ManagerFormModel form = new();
            return View(form);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ManagerFormModel form)
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
