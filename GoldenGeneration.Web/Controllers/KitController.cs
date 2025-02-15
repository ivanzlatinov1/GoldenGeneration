using GoldenGeneration.Services.Interfaces;
using GoldenGeneration.Web.Mappers;
using GoldenGeneration.Web.Models.Kits;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static GoldenGeneration.Infrastructure.Constants;

namespace GoldenGeneration.Web.Controllers
{
    public class KitController(IKitService service): Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var kits = await service.GetAllAsync();
            return View(kits.Select(x => x.ToView()).ToArray());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var kit = await service.GetByIdAsync(id);
            return View(kit.ToView());
        }

        [Authorize(Admin)]
        [HttpGet]
        public IActionResult Create()
        {
            KitFormModel form = new();
            return View(form);
        }

        [Authorize(Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KitFormModel form)
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
