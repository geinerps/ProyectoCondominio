using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoCondominio.Controllers
{
    public class SeguridadController : Controller
    {
        // GET: SeguridadController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SeguridadController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SeguridadController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SeguridadController/Create
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

        // GET: SeguridadController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SeguridadController/Edit/5
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

        // GET: SeguridadController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SeguridadController/Delete/5
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
