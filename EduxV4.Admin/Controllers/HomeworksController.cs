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
using static EduxV4.Service.CountryService;
using static EduxV4.Service.HomeworkService;

namespace EduxV4.Admin.Controllers
{
    public class HomeworksController : Controller
    {
        private readonly IHomeworkService homeworkService;
        private readonly ICourseService courseService;
        private readonly IHostingEnvironment environment;

        public HomeworksController(IHomeworkService homeworkService, ICourseService courseService, IHostingEnvironment environment)
        {
            this.homeworkService = homeworkService;
            this.courseService = courseService;
            this.environment = environment;

        }

        public IActionResult Index()
        {
            var homeworks = homeworkService.GetHomeworks();//Tüm homeworkleri Getir.
            return View(homeworks);
        }
        public ActionResult Create()
        {

            var homework = new Homework();
           ViewData["CourseId"] = new SelectList(courseService.GetCourses(), "Id", "Name");
            return View(homework);
        }



        // POST: Homework/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Homework homework, IFormFile solutionFileUpload, IFormFile homeworkFileUpload)
        {
            if (ModelState.IsValid)
            {
                if (solutionFileUpload != null && solutionFileUpload.Length > 0)
                {
                    var rnd = new Random();
                    var fileName = Path.GetFileNameWithoutExtension(solutionFileUpload.FileName)+rnd.Next(1000).ToString()+Path.GetExtension(solutionFileUpload.FileName);
                    var uploadPath = Path.Combine(environment.WebRootPath, "Uploads", fileName);

                    // dizin yoksa oluştur
                    if (!Directory.Exists(Path.Combine(environment.WebRootPath, "Uploads")))
                    {
                        Directory.CreateDirectory(Path.Combine(environment.WebRootPath, "Uploads"));
                    }

                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        solutionFileUpload.CopyTo(stream);
                    }

                    homework.SolutionFile = fileName;
                }

                if (homeworkFileUpload != null && homeworkFileUpload.Length > 0)
                {
                    var rnd = new Random();
                    var fileName = Path.GetFileNameWithoutExtension(homeworkFileUpload.FileName) + rnd.Next(1000).ToString() + Path.GetExtension(homeworkFileUpload.FileName);
                    var uploadPath = Path.Combine(environment.WebRootPath, "Uploads", fileName);

                    if (!Directory.Exists(Path.Combine(environment.WebRootPath, "Uploads")))
                    {
                        Directory.CreateDirectory(Path.Combine(environment.WebRootPath, "Uploads"));
                    }

                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        homeworkFileUpload.CopyTo(stream);
                    }
                    homework.HomeworkFile = fileName;

                }
                homeworkService.InsertHomework(homework);
                return RedirectToAction(nameof(Edit), new { id = homework.Id, saved = true });
            }
            else
            {
                ViewData["CourseId"] = new SelectList(courseService.GetCourses(), "Id", "Name", homework.CourseId);
                return View(homework);
            }
        }
        public ActionResult Edit(string id, bool saved = false)
        {
            var homework = homeworkService.GetHomework(id);
            ViewBag.Saved = saved;
           ViewData["CourseId"] = new SelectList(courseService.GetCourses(), "Id", "Name", homework.CourseId);
            return View(homework);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(String id, Homework homework, IFormFile solutionFileUpload, IFormFile homeworkFileUpload)
        {
            if (ModelState.IsValid)
            {
                if (solutionFileUpload != null && solutionFileUpload.Length > 0)
                {
                    var rnd = new Random();
                    var fileName = Path.GetFileNameWithoutExtension(solutionFileUpload.FileName) + rnd.Next(1000).ToString() + Path.GetExtension(solutionFileUpload.FileName);
                    var uploadPath = Path.Combine(environment.WebRootPath, "Uploads", fileName);

                    // dizin yoksa oluştur
                    if (!Directory.Exists(Path.Combine(environment.WebRootPath, "Uploads")))
                    {
                        Directory.CreateDirectory(Path.Combine(environment.WebRootPath, "Uploads"));
                    }

                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        solutionFileUpload.CopyTo(stream);
                    }

                    homework.SolutionFile = fileName;
                }

                if (homeworkFileUpload != null && homeworkFileUpload.Length > 0)
                {
                    var rnd = new Random();
                    var fileName = Path.GetFileNameWithoutExtension(homeworkFileUpload.FileName) + rnd.Next(1000).ToString() + Path.GetExtension(homeworkFileUpload.FileName);
                    var uploadPath = Path.Combine(environment.WebRootPath, "Uploads", fileName);

                    if (!Directory.Exists(Path.Combine(environment.WebRootPath, "Uploads")))
                    {
                        Directory.CreateDirectory(Path.Combine(environment.WebRootPath, "Uploads"));
                    }

                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        homeworkFileUpload.CopyTo(stream);
                    }
                    homework.HomeworkFile = fileName;

                }
                homeworkService.UpdateHomework(homework);
                return RedirectToAction(nameof(Edit), new { id = homework.Id, saved = true });
            }
            else
            {
               ViewData["CourseId"] = new SelectList(courseService.GetCourses(), "Id", "Name", homework.CourseId);
                return View(homework);
            }
        }
        public ActionResult Delete(string id)
        {
            homeworkService.DeleteHomework(id);
            return RedirectToAction("Index");
        }

    }
}