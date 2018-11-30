using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduxV4.Data;
using EduxV4.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EduxV4.Admin.Controllers
{
    public class ActivitySourcesController : Controller
    {
        private readonly IActivitySourceService activitySourceService;
        public ActivitySourcesController(IActivitySourceService activitySourceService)
        {
            this.activitySourceService = activitySourceService;
        }

        public IActionResult Index()
        {
            var activitySources = activitySourceService.GetActivitySources();
            return View(activitySources);
        }
        public IActionResult Create()
        {
            var activitySource = new ActivitySource();
            ViewData["ParentActivitySourceId"] = new SelectList(activitySourceService.GetActivitySources(), "Id", "Name");
            return View(activitySource);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ActivitySource activitySource)
        {
            if (ModelState.IsValid)
            {
                activitySourceService.InsertActivitySource(activitySource);
                return RedirectToAction(nameof(Edit), new { id = activitySource.Id, saved=true});
            }
            else
            {
                ViewData["ParentActivitySourceId"] = new SelectList(activitySourceService.GetActivitySources(), "Id", "Name",activitySource.ParentActivitySourceId);
                return View(activitySource);
            }
        }

        public IActionResult Edit( string id,bool saved =false)
        {
            var activitySource = activitySourceService.GetActivitySource(id);
            ViewBag.Saved = saved;
            ViewData["ParentActivitySourceId"] = new SelectList(activitySourceService.GetActivitySources().Where(w => w.Id != id).ToList(), "Id", "Name", activitySource.ParentActivitySourceId);
            return View(activitySource);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, ActivitySource activitySource)
        {
            if (ModelState.IsValid)
            {
                activitySourceService.UpdateActivitySource(activitySource);
                return RedirectToAction(nameof(Edit), new { id = activitySource.Id,saved=true });
            }
            else
            {
                ViewData["ParentActivitySourceId"] = new SelectList(activitySourceService.GetActivitySources().Where(w=>w.Id!=id).ToList(), "Id", "Name", activitySource.ParentActivitySourceId);
                return View(activitySourceService);
            }
        
        }
        public IActionResult Delete(string id)
        {
            activitySourceService.DeleteActivitySource(id);
            return RedirectToAction("Index");
        }
       
    }
}