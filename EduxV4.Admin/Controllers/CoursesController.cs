using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduxV4.Data;
using EduxV4.Service;
using Microsoft.AspNetCore.Mvc;

namespace EduxV4.Admin.Controllers
{
    
        public class CoursesController : Controller
        {
            private readonly ICourseService courseService;
            public CoursesController(ICourseService courseService)
            {
                this.courseService = courseService;
            }
            public IActionResult Index()
            {
                var countries = courseService.GetCourses();
                return View(countries);
            }
            public ActionResult Create()
            {
                var course = new Course();
                return View(course);
            }




            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(Course course)
            {
                if (ModelState.IsValid)
                {
                    courseService.InsertCourse(course);
                    return RedirectToAction(nameof(Edit), new { id = course.Id, saved = true });
                }
                else
                {
                    return View(course);
                }
            }
            public ActionResult Edit(string id, bool saved = false)
            {
                var course = courseService.GetCourse(id);
                ViewBag.Saved = saved;
                return View(course);
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(String id, Course course)
            {
                if (ModelState.IsValid)
                {
                    courseService.UpdateCourse(course);
                    return RedirectToAction(nameof(Edit), new { id = course.Id, saved = true });
                }
                else
                {
                    return View(course);
                }
            }
            public ActionResult Delete(string id)
            {
                courseService.DeleteCourse(id);
                return RedirectToAction("Index");
            }

        }
    }
