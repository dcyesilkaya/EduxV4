using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduxV4.Data;
using EduxV4.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EduxV4.Admin.Controllers
{
    public class SchoolLevelsController : Controller
    {

        private readonly ISchoolLevelService schoolLevelService;
        private readonly ICampusService campusService;
        public SchoolLevelsController(ICampusService campusService, ISchoolLevelService schoolLevelService)
        {
            this.schoolLevelService = schoolLevelService;
            this.campusService = campusService;
        }

        public IActionResult Index()
        {
            var schoolLevels = schoolLevelService.GetSchoolLevels();
            return View(schoolLevels);
        }

        public IActionResult Create()
        {
            var schoolLevel = new SchoolLevel();
            ViewData["CampusId"] = new SelectList(campusService.GetCampuses(), "Id", "Name");
            return View(schoolLevel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SchoolLevel schoolLevel)
        {
            if (ModelState.IsValid)
            {
                schoolLevelService.InsertSchoolLevel(schoolLevel);
                return RedirectToAction(nameof(Edit), new { id = schoolLevel.Id, saved = true });
            }
            else
            {
                ViewData["CampusId"] = new SelectList(campusService.GetCampuses(), "Id", "Name", schoolLevel.CampusId);
                return View(schoolLevel);
            }
        }

        public IActionResult Edit(string id, bool saved = false)
        {
            var schoolLevel = schoolLevelService.GetSchoolLevel(id);
            ViewBag.Saved = saved;
            ViewData["CampusId"] = new SelectList(campusService.GetCampuses(), "Id", "Name", schoolLevel.CampusId);
            return View(schoolLevel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, SchoolLevel schoolLevel)
        {
            if (ModelState.IsValid)
            {
                schoolLevelService.UpdateSchoolLevel(schoolLevel);
                return RedirectToAction(nameof(Edit), new { id = schoolLevel.Id, saved = true });
            }
            else
            {
                ViewData["CampusId"] = new SelectList(campusService.GetCampuses(), "Id", "Name", schoolLevel.CampusId);
                return View(schoolLevel);
            }
        }

        public IActionResult Delete(string id)
        {
            schoolLevelService.DeleteSchoolLevel(id);
            return RedirectToAction("Index");
        }
    }
}