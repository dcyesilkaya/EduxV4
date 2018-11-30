using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduxV4.Data;
using EduxV4.Service;
using Microsoft.AspNetCore.Mvc;

namespace EduxV4.Admin.Controllers
{
    public class CampusesController : Controller
    {
        private readonly ICampusService campusService;

        public CampusesController(ICampusService campusService)
        {
            this.campusService = campusService;
        }
        public IActionResult Index()
        {
            // Tüm kampüsleri getir
            var campuses = campusService.GetCampuses();
            return View(campuses);
        }
        public IActionResult Create()
        {
            var campus = new Campus();
            return View(campus);
        }
        // POST: Campus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Campus campus)
        {
            if (ModelState.IsValid)
            {
                campusService.InsertCampus(campus);
                return RedirectToAction(nameof(Edit), new { id = campus.Id, saved = true });
            }
            else
            {
                return View(campus);
            }
        }
        public IActionResult Edit(string id, bool saved = false)
        {
            var campus = campusService.GetCampus(id);
            ViewBag.Saved = saved;
            return View(campus);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Campus campus)
        {
            if (ModelState.IsValid)
            {
                campusService.UpdateCampus(campus);
                return RedirectToAction(nameof(Edit), new { id = campus.Id, saved = true });
            }
            else
            {
                return View(campus);
            }
        }
        public IActionResult Delete(string id)
        {
            campusService.DeleteCampus(id);
            return RedirectToAction("Index");
        }
    }
}