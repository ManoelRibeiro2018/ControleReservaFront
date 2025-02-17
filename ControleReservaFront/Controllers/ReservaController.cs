using ControleReserva.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace ControleReserva.Controllers
{
    public class ReservaController : Controller
    {
        private readonly IReservaService _service;

        public ReservaController(IReservaService service)
        {
            _service = service;
        }


        // GET: ReservaController
        public async Task<ActionResult> Index()
        {
            var result = await _service.GetAll();
            return View(result);
        }

        // GET: ReservaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
