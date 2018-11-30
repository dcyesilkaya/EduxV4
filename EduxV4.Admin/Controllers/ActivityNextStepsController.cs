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
    public class ActivityNextStepsController : Controller
    {
        private readonly IActivityNextStepService activityNextStepService;
        public ActivityNextStepsController(IActivityNextStepService activityNextStepService) 
        {
            this.activityNextStepService = activityNextStepService;
        }
        public IActionResult Index()
        {
            var activityNextStep = activityNextStepService.GetActivityNextSteps();
            return View(activityNextStep);
        }
        public IActionResult Create()
        {
            var activityNextStep = new ActivityNextStep();
            return View(activityNextStep);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ActivityNextStep activityNextStep)
        {
            if (ModelState.IsValid)
            {
                activityNextStepService.InsertActivityNextStep(activityNextStep);
                return RedirectToAction(nameof(Edit), new { id = activityNextStep.Id, saved = true });
            }
            else
            {
                return View(activityNextStep);
            }
        }
        public IActionResult Edit(string id, bool saved = false)
        {
            var activityNextStep = activityNextStepService.GetActivityNextStep(id);
            ViewBag.Saved = saved;
            return View(activityNextStep);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, ActivityNextStep activityNextStep)
        {
            if (ModelState.IsValid)
            {
                activityNextStepService.UpdateActivityNextStep(activityNextStep);
                return RedirectToAction(nameof(Edit), new { id = activityNextStep.Id, saved = true });

            }
            else
            {
                return View(activityNextStep);
            }
        }
        public ActionResult Delete(string id)
        {
            activityNextStepService.DeleteActivityNextStep(id);
            return RedirectToAction("Index");
        }

        
    }
}