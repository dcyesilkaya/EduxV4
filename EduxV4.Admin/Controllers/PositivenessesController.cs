using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduxV4.Data;
using EduxV4.Service;
using Microsoft.AspNetCore.Mvc;

namespace EduxV4.Admin.Controllers
{
    public class PositivenessesController : Controller
    {
        private readonly IPositivenessService positivenessService;
        public PositivenessesController(IPositivenessService positivenessService)
        {
            this.positivenessService = positivenessService;
        }
        public IActionResult Index()
        {
            var positiveness = positivenessService.GetPositiveness();

            return View(positiveness);
        }
        public IActionResult Create()
        {
            var positiveness = new Positiveness();
           
            return View(positiveness);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Positiveness positiveness)
        {
            if (ModelState.IsValid)
            {
                positivenessService.InsertPositiveness(positiveness);
                return RedirectToAction(nameof(Edit), new { id = positiveness.Id, saved = true });
            }
            else
            {
             
                return View(positiveness);
            }
        }
        public IActionResult Edit(string id, bool saved = false)
        {
            var positiveness = positivenessService.GetPositiveness(id);
            ViewBag.Saved = saved;
           
            return View(positiveness);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Positiveness positiveness)
        {
            if (ModelState.IsValid)
            {
                positivenessService.UpdatePositiveness(positiveness);
                return RedirectToAction(nameof(Edit), new { id = positiveness.Id, saved = true });
            }
            else
            {
              
                return View(positivenessService);
            }

        }
        public IActionResult Delete(string id)
        {
            positivenessService.DeletePositiveness(id);
            return RedirectToAction("Index");
        }


    }
}