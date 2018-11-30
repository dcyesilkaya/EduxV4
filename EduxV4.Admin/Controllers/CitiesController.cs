using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduxV4.Data;
using EduxV4.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static EduxV4.Service.CountryService;

namespace EduxV4.Admin.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityService cityService;
        private readonly ICountryService countryService;
        public CitiesController(ICityService cityService,ICountryService countryService)
        {
            this.cityService = cityService;
            this.countryService = countryService;
        }
       
        
        public IActionResult Index()
        {
            var cities = cityService.GetCities();//Tüm City'leri Getir.
            return View(cities);
        }
        public ActionResult Create()
        {

            var city = new City();
            ViewData["CountryId"] = new SelectList(countryService.GetCountries(), "Id", "Name");
            return View(city);
        }



        // POST: City/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(City city)
        {
            if (ModelState.IsValid)
            {
                cityService.InsertCity(city);
                return RedirectToAction(nameof(Edit), new { id = city.Id,saved=true });
            }
            else
            {
                ViewData["CountryId"] = new SelectList(countryService.GetCountries(), "Id", "Name", city.CountryId);
                return View(city);
            }
        }
        public ActionResult Edit(string id, bool saved = false)
        {
            var city = cityService.GetCity(id);
            ViewBag.Saved = saved;
            ViewData["CountryId"] = new SelectList(countryService.GetCountries(), "Id", "Name", city.CountryId);
            return View(city);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(String id, City city)
        {
            if (ModelState.IsValid)
            {
                cityService.UpdateCity(city);
                return RedirectToAction(nameof(Edit), new { id = city.Id, saved = true });
            }
            else
            {
                ViewData["CountryId"] = new SelectList(countryService.GetCountries(), "Id", "Name", city.CountryId);
                return View(countryService);
            }
        }
        public ActionResult Delete(string id)
        {
            cityService.DeleteCity(id);
            return RedirectToAction("Index");
        }

    }
}