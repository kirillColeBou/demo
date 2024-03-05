using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newApp.Database;
using newApp.Models;

namespace newApp.Controllers
{
    public class GospitalizationController : Controller
    {
        Database.Context Context;

        public GospitalizationController(Context context)
        {
            Context = context;
        }

        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult Create()
        {
            var model = new Gospitalization();
            model.PatientsIds = Context.Patients.ToList();
            return View(model);
        }

        // POST: GospitalizationController/Create
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

    }
}
