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
    public class CountiesController : Controller
    {
        private readonly ICountyService countyService;

        private readonly ICityService cityService;

        public CountiesController(ICountyService countyService, ICityService cityService)
        {
            this.countyService = countyService;
            this.cityService = cityService;
        }
        public IActionResult Index()
        {
            // Tüm kampüsleri getir
            var counties = countyService.GetCounties();
            return View(counties);
        }
        public IActionResult Create()
        {
            var county = new County();
            ViewData["CityId"] = new SelectList(cityService.GetCities(), "Id", "Name");
            return View(county);
        }
        // POST: County/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(County county)
        {
            if (ModelState.IsValid)
            {
                countyService.InsertCounty(county);
                return RedirectToAction(nameof(Edit), new { id = county.Id, saved = true });
            }
            else
            {
                ViewData["CityId"] = new SelectList(cityService.GetCities(), "Id", "Name", county.CityId);
                return View(county);
                
            }
        }
        public IActionResult Edit(string id, bool saved = false)
        {
            var county = countyService.GetCounty(id);
            ViewBag.Saved = saved;
            ViewData["CityId"] = new SelectList(cityService.GetCities(), "Id", "Name", county.CityId);
            return View(county);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id,County county)
        {
            if (ModelState.IsValid)
            {
                countyService.UpdateCounty(county);
                return RedirectToAction(nameof(Edit), new { id = county.Id, saved = true });
            }
            else
            {
                ViewData["CityId"] = new SelectList(cityService.GetCities(), "Id", "Name", county.CityId);
                return View(cityService);
            }
        }
        public IActionResult Delete(string id)
        {
            countyService.DeleteCounty(id);
            return RedirectToAction("Index");
        }
    }
}