using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoCondominio.Controllers
{
    public class ViviendasController : Controller
    {
        // GET: ViviendasController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ViviendasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ViviendasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ViviendasController/Create
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

        // GET: ViviendasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ViviendasController/Edit/5
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

        // GET: ViviendasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ViviendasController/Delete/5
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
