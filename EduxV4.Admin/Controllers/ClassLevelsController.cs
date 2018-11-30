using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduxV4.Data;
using EduxV4.Service;
using Microsoft.AspNetCore.Mvc;

namespace EduxV4.Admin.Controllers
{
    public class ClassLevelsController : Controller
    {
       
        private readonly IClassLevelService classLevelService;
        public ClassLevelsController(IClassLevelService classLevelService)

        {
            this.classLevelService = classLevelService;
        }

        //GET ActivityTypes (Tüm aktivity typlerı getirir)
        public IActionResult Index()
        {
            var classLevels = classLevelService.GetClassLevels();
            return View(classLevels);
        }

        public IActionResult Create()
        {
            var classLevel = new ClassLevel();
            return View(classLevel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClassLevel classLevel)
        {
            if (ModelState.IsValid)
            {
                classLevelService.InsertClassLevel(classLevel);
                return RedirectToAction(nameof(Edit), new { id = classLevel.Id, saved = true });
            }
            else
            {
                return View(classLevel);
            }
        }

        public IActionResult Edit(string id, bool saved = false)
        {
            var classLevel = classLevelService.GetClassLevel(id);
            ViewBag.Saved = saved;
            return View(classLevel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, ClassLevel classLevel)
        {
            if (ModelState.IsValid)
            {
                classLevelService.UpdateClassLevel(classLevel);
                return RedirectToAction(nameof(Edit), new { id = classLevel.Id, saved = true });
            }
            else
            {
                return View(classLevel);
            }
        }

        public IActionResult Delete(string id)
        {
            classLevelService.DeleteClassLevel(id);
            return RedirectToAction("Index");
        }

    }
}