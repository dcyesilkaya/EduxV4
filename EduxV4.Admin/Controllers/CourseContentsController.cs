using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EduxV4.Data;
using EduxV4.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EduxV4.Admin.Controllers
{
    public class CourseContentsController : Controller
    {
        private readonly ICourseContentService courseContentService;
        private readonly ICourseService courseService;
        private readonly IHostingEnvironment environment;
        public CourseContentsController(ICourseContentService courseContentService, ICourseService courseService, IHostingEnvironment environment)
        {
            this.courseContentService = courseContentService;
            this.courseService = courseService;
            this.environment = environment;
        }
        public IActionResult Index()
        {
            var courseContent = courseContentService.GetCourseContents();
            return View(courseContent);
        }

        public IActionResult Create()
        {
            var courseContent = new CourseContent();
            ViewData["CourseId"] = new SelectList(courseService.GetCourses(), "Id", "Name");
            return View(courseContent);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create (CourseContent courseContent, IFormFile fileUpload)
        {
            if(ModelState.IsValid)
            {
                if (fileUpload != null && fileUpload.Length > 0)
                {
                    var rnd = new Random();
                    var fileName = Path.GetFileNameWithoutExtension(fileUpload.FileName) + rnd.Next(1000).ToString() + Path.GetExtension(fileUpload.FileName);
                    var path = Path.Combine(environment.WebRootPath, "Uploads");
                    var filePath = Path.Combine(path, fileName);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        fileUpload.CopyTo(stream);
                    }
                    courseContent.File = fileName;     
                }
                courseContentService.InsertCourseContent(courseContent);
                return RedirectToAction("Edit", new { id = courseContent.Id, saved = true });
            }
            ViewData["CourseId"] = new SelectList(courseService.GetCourses(), "Id", "Name", courseContent.CourseId);
            return View(courseContent);
        }
        public IActionResult Edit(string id, bool saved = false)
        {
            var courseContent = courseContentService.GetCourseContent(id);
            ViewData["CourseId"] = new SelectList(courseService.GetCourses(), "Id", "Name");
            ViewBag.Saved = saved;
            return View(courseContent);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (CourseContent courseContent, string id, IFormFile fileUpload)
        {
            if (ModelState.IsValid)
            {
                if (fileUpload != null && fileUpload.Length > 0)
                {
                    var rnd = new Random();
                    var fileName = Path.GetFileNameWithoutExtension(fileUpload.FileName) + rnd.Next(1000).ToString() + Path.GetExtension(fileUpload.FileName);
                    var path = Path.Combine(environment.WebRootPath, "Uploads");
                    var filePath = Path.Combine(path, fileName);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        fileUpload.CopyTo(stream);
                    }
                    courseContent.File = fileName;
                }
                courseContentService.UpdateCourseContent(courseContent);
                return RedirectToAction("Edit", new { id = courseContent.Id, saved = true });
            }
            ViewData["CountyId"] = new SelectList(courseService.GetCourses(), "Id", "Name", courseContent.CourseId);
            return View(courseContent);
        }
        public IActionResult Delete(string id)
        {
            courseContentService.DeleteCourseContent(id);
            return RedirectToAction("Index");

        }
    }
}