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
    public class AnnouncementsController : Controller
    {
        private readonly IAnnouncementService announcementService;
        private readonly ICourseService courseService;
        public AnnouncementsController(IAnnouncementService announcementService, ICourseService courseService)
        {
            this.announcementService = announcementService;
            this.courseService = courseService;
        }
        public IActionResult Index()
        {
            var announcement = announcementService.GetAnnouncements();
            return View(announcement);
        }
        public IActionResult Create()
        {
            var announcement = new Announcement();
            ViewData["CourseId"] = new SelectList(courseService.GetCourses(), "Id", "Name");
            return View(announcement);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                announcementService.InsertAnnouncement(announcement);
                return RedirectToAction(nameof(Edit), new { id = announcement.Id, saved = true });
            }
            else
            {
                ViewData["CourseId"] = new SelectList(courseService.GetCourses(), "Id", "Name");
                return View(announcement);
            }
        }
        public IActionResult Edit(string id, bool saved = false)
        {
            var announcement = announcementService.GetAnnouncement(id);
            ViewBag.Saved = saved;
            ViewData["CourseId"] = new SelectList(courseService.GetCourses(), "Id", "Name", announcement.CourseId);
            return View(announcement);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                announcementService.UpdateAnnouncement(announcement);
                return RedirectToAction(nameof(Edit), new { id = announcement.Id, saved = true });

            }
            else
            {
                ViewData["CourseId"] = new SelectList(courseService.GetCourses(), "Id", "Name", announcement.CourseId);
                return View(announcement);
            }
        }
        public ActionResult Delete(string id)
        {
            announcementService.DeleteAnnouncement(id);
            return RedirectToAction("Index");
        }
    }
}