using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoCondominio.Controllers
{
    public class VisitasController : Controller
    {
        // GET: VisitasController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VisitasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VisitasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VisitasController/Create
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

        // GET: VisitasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VisitasController/Edit/5
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

        // GET: VisitasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VisitasController/Delete/5
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
