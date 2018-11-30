using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduxV4.Data;
using EduxV4.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduxV4.Admin.Controllers
{
    public class ActivityTypesController : Controller
    {
        private readonly IActivityTypeService activityTypeService;
        public ActivityTypesController (IActivityTypeService activityTypeService)
        {
            this.activityTypeService = activityTypeService;
        }

        //GET ActivityTypes (Tüm aktivity typlerı getirir)
        public IActionResult Index()
        {
            var activityTypes = activityTypeService.GetActivityTypes();
            return View(activityTypes);
        }

        public IActionResult Create()
        {
            var activityType = new ActivityType();
            return View(activityType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ActivityType activityType)
        {
            if (ModelState.IsValid)
            {
                activityTypeService.InsertActivityType(activityType);
                return RedirectToAction(nameof(Edit), new { id = activityType.Id, saved = true });
            }
            else
            {
                return View(activityType);
            }
        }

        public IActionResult Edit(string id, bool saved = false)
        {
            var activityType = activityTypeService.GetActivityType(id);
            ViewBag.Saved = saved;
            return View(activityType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, ActivityType activityType)
        {
            if (ModelState.IsValid)
            {
                activityTypeService.UpdateActivityType(activityType);
                return RedirectToAction(nameof(Edit), new { id = activityType.Id, saved = true });
            }
            else
            {
                return View(activityType);
            }
        }

        public IActionResult Delete(string id)
        {
            activityTypeService.DeleteActivityType(id);
            return RedirectToAction("Index");
        }
        
    }
}