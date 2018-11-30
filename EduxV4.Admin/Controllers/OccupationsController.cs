using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduxV4.Data;
using EduxV4.Service;
using Microsoft.AspNetCore.Mvc;

namespace EduxV4.Admin.Controllers
{
    public class OccupationsController : Controller
    {
        private readonly IOccupationService occupationService;
        public OccupationsController(IOccupationService occupationService)
        {
            this.occupationService = occupationService;
        }
        public IActionResult Index()
        {
            var occupation = occupationService.GetOccupations();
            return View(occupation);
        }
        public IActionResult Create()
        {
            var occupation = new Occupation();
            return View(occupation);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Occupation occupation)
        {
            if (ModelState.IsValid)
            {
                occupationService.InsertOccupation(occupation);
                return RedirectToAction(nameof(Edit), new { id = occupation.Id, saved = true });
            }
            else
            {
                return View(occupation);
            }
        }
        public IActionResult Edit(string id, bool saved = false)
        {
            var occupation = occupationService.GetOccupation(id);
            ViewBag.Saved = saved;
            return View(occupation);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Occupation occupation)
        {
            if (ModelState.IsValid)
            {
                occupationService.UpdateOccupation(occupation);
                return RedirectToAction(nameof(Edit), new { id = occupation.Id, saved = true });

            }
            else
            {
                return View(occupation);
            }
        }
        public ActionResult Delete(string id)
        {
            occupationService.DeleteOccupation(id);
            return RedirectToAction("Index");
        }
    }
}