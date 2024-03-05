using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using newApp.Database;
using newApp.Models;

namespace newApp.Controllers
{
    public class PatientsController : Controller
    {
        Database.Context Context;

        public PatientsController(Context context)
        {
            Context = context;
        }


        // GET: PatientsController
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Patients patients)
        {
            if (!ModelState.IsValid)
            {
                return View(patients);
            }
                

            Context.Patients.Add(patients);
            Context.SaveChanges();

            return RedirectToAction(nameof(Details), new { Id = patients.Id });
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: PatientsController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var patients = await Context.Patients.FirstOrDefaultAsync(x => x.Id == id);
            if (patients is null)
                return NotFound();

            patients.CreateQr();
            return View(patients);
        }

        public ActionResult GetPatientPartial(int id)
        {
            var patients =  Context.Patients.FirstOrDefault(x => x.Id == id);
            if (patients is null)
                return NotFound();
            return PartialView("Patient",patients);
        }

        // GET: PatientsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientsController/Create
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

        // GET: PatientsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientsController/Edit/5
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

        // GET: PatientsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientsController/Delete/5
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
