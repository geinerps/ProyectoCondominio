using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoCondominio.Controllers
{
    public class VisitantesController : Controller
    {
        // GET: VisitantesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VisitantesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VisitantesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VisitantesController/Create
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

        // GET: VisitantesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VisitantesController/Edit/5
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

        // GET: VisitantesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VisitantesController/Delete/5
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
