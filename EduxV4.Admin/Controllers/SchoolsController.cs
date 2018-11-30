using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduxV4.Data;
using EduxV4.Service;
using Microsoft.AspNetCore.Mvc;

namespace EduxV4.Admin.Controllers
{
    public class SchoolsController : Controller
    {
        private readonly ISchoolService schoolService;
        public SchoolsController(ISchoolService schoolService)
        {
            this.schoolService = schoolService;

        }
        public IActionResult Index()
        {
            // Tüm kampüsleri getir
            var schools = schoolService.GetSchools();
            return View(schools);
        }
        public IActionResult Create()
        {
            var school = new School();
            return View(school);
        }
        // POST: School/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(School school)
        {
            if (ModelState.IsValid)
            {
                schoolService.InsertSchool(school);
                return RedirectToAction(nameof(Edit), new { id = school.Id, saved = true });
            }
            else
            {
                return View(school);
            }
        }
        public IActionResult Edit(string id, bool saved = false)
        {
            var school = schoolService.GetSchool(id);
            ViewBag.Saved = saved;
            return View(school);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(School school)
        {
            if (ModelState.IsValid)
            {
                schoolService.UpdateSchool(school);
                return RedirectToAction(nameof(Edit), new { id = school.Id, saved = true });
            }
            else
            {
                return View(school);
            }
        }
        public IActionResult Delete(string id)
        {
            schoolService.DeleteSchool(id);
            return RedirectToAction("Index");
        }
    }
}