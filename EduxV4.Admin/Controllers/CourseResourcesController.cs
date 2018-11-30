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
    public class CourseResourcesController : Controller
    {
        private readonly ICourseResourceService courseResourceService;
        private readonly ISeasonService seasonService;
        private readonly ICourseService courseService;
        private readonly IBranchService branchService;
        public CourseResourcesController(ICourseResourceService courseResourceService, ISeasonService seasonService, ICourseService courseService, IBranchService branchService)
        {
            this.courseResourceService = courseResourceService;
            this.seasonService = seasonService;
            this.courseService = courseService;
            this.branchService = branchService;
        }
    

        public IActionResult Index()
        { 
            var courseResources = courseResourceService.GetCourseResources();
            return View(courseResources);
        }
        public IActionResult Create()
        {
            var courseResource = new CourseResource();
           ViewData["SeasonId"] = new SelectList(seasonService.GetSeasons(), "Id", "Name");
            ViewData["CourseId"] = new SelectList(courseService.GetCourses(), "Id", "Name");
            ViewData["BranchId"] = new SelectList(branchService.GetBranches(), "Id", "Name");
            return View(courseResource);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseResource courseResource)
        {
            if (ModelState.IsValid)
            {
                courseResourceService.InsertCourseResource(courseResource);
                return RedirectToAction(nameof(Edit), new { id = courseResource.Id, saved = true });
            }
            else
            {
                ViewData["SeasonId"] = new SelectList(seasonService.GetSeasons(), "Id", "Name", courseResource.SeasonId);
                ViewData["CourseId"] = new SelectList(courseService.GetCourses(), "Id", "Name", courseResource.CourseId);
                ViewData["BranchId"] = new SelectList(branchService.GetBranches(), "Id", "Name", courseResource.BranchId);
                return View(courseResource);
            }
        }

        public IActionResult Edit(string id, bool saved = false)
        {
            var courseResource = courseResourceService.GetCourseResource(id);
            ViewBag.Saved = saved;
            ViewData["SeasonId"] = new SelectList(seasonService.GetSeasons().Where(w => w.Id != id).ToList(), "Id", "Name", courseResource.SeasonId);
            ViewData["CourseId"] = new SelectList(courseService.GetCourses().Where(w => w.Id != id).ToList(), "Id", "Name", courseResource.CourseId);
            ViewData["BranchId"] = new SelectList(branchService.GetBranches().Where(w => w.Id != id).ToList(), "Id", "Name", courseResource.BranchId);
            return View(courseResource);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, CourseResource courseResource)
        {
            if (ModelState.IsValid)
            {
                courseResourceService.UpdateCourseResource(courseResource);
                return RedirectToAction(nameof(Edit), new { id = courseResource.Id, saved = true });
            }
            else
            {
                ViewData["SeasonId"] = new SelectList(seasonService.GetSeasons().Where(w => w.Id != id).ToList(), "Id", "Name", courseResource.SeasonId);
                ViewData["CourseId"] = new SelectList(courseService.GetCourses().Where(w => w.Id != id).ToList(), "Id", "Name", courseResource.CourseId);
                ViewData["BranchId"] = new SelectList(branchService.GetBranches().Where(w => w.Id != id).ToList(), "Id", "Name", courseResource.BranchId);
                return View(courseResourceService);
            }

        }
        public IActionResult Delete(string id)
        {
            courseResourceService.DeleteCourseResource(id);
            return RedirectToAction("Index");
        }
    }
}