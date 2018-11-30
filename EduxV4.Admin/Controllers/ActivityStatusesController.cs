using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduxV4.Data;
using EduxV4.Service;
using Microsoft.AspNetCore.Mvc;

namespace EduxV4.Admin.Controllers
{
    public class ActivityStatusesController : Controller
    {
        private IActivityStatusService activityStatusService;
        public ActivityStatusesController(IActivityStatusService activityStatusService)
        {
            this.activityStatusService = activityStatusService;
        }
        public IActionResult Index()
        {
            var activityStatus = activityStatusService.GetActivityStatuses();
            return View(activityStatus);
        }
        public IActionResult Create()
        {
            var activityStatus = new ActivityStatus();
            return View(activityStatus);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ActivityStatus activityStatus)
        {
            if(ModelState.IsValid)
            {
                activityStatusService.InsertActivityStatus(activityStatus);
                return RedirectToAction("Edit", new { id = activityStatus.Id, saved = true });
            }
            else
            {
                return View(activityStatus);
            }  
        }
        public IActionResult Edit(string id, bool saved = false)
        {
            var activityStatus = activityStatusService.GetActivityStatus(id);
            ViewBag.Saved = saved;
            return View(activityStatus);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, ActivityStatus activityStatus)
        {
            if(ModelState.IsValid)
            {
                activityStatusService.UpdateActivityStatus(activityStatus);
                return RedirectToAction("Edit", new { id = activityStatus.Id, saved = true });
            }
            else
            {
                return View(activityStatus);
            }
        }
        public IActionResult Delete(string id)
        {
            activityStatusService.DeleteActivityStatus(id);
            return RedirectToAction("Index");
        }
    }
}