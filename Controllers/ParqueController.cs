using Microsoft.AspNetCore.Mvc;
using MonitoramentoAmbiental.Models;
using MonitoramentoAmbiental.Services;

namespace MonitoramentoAmbiental.Controllers
{
    public class ParqueController : Controller
    {
        private readonly IParqueService _parqueService;

        public ParqueController(IParqueService parqueService)
        {
            _parqueService = parqueService;
        }

        public async Task<IActionResult> Index()
        {
            var parques = await _parqueService.GetAllAsync();
            return View(parques);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Parque parque)
        {
            if (ModelState.IsValid)
            {
                await _parqueService.CreateAsync(parque);
                return RedirectToAction(nameof(Index));
            }
            return View(parque);
        }

        // GET: Parque/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var parque = await _parqueService.GetByIdAsync(id);
            if (parque == null)
            {
                return NotFound();
            }

            return View(parque);
        }

        // POST: Parque/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Parque parque)
        {
            if (id != parque.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var success = await _parqueService.UpdateAsync(id, parque);
                if (success == null)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(parque);
        }
    }
}
