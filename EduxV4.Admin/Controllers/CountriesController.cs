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
    public class CountriesController : Controller
    {
        private readonly ICountryService countryService;
        public CountriesController(ICountryService countryService)
        {
            this.countryService = countryService;
        }
        public IActionResult Index()
        {
            var countries = countryService.GetCountries();
            return View(countries);
        }
        public ActionResult Create()
        {
            var country = new Country();
            return View(country);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                countryService.InsertCountry(country);
                return RedirectToAction(nameof(Edit), new { id = country.Id, saved = true });
            }
            else
            {
                return View(country);
            }
        }
        public ActionResult Edit(string id, bool saved = false)
        {
            var country = countryService.GetCountry(id);
            ViewBag.Saved = saved;
            return View(country);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(String id, Country country)
        {
            if (ModelState.IsValid)
            {
                countryService.UpdateCountry(country);
                return RedirectToAction(nameof(Edit), new { id = country.Id, saved = true });
            }
            else
            {
                return View(country);
            }
        }
        public ActionResult Delete(string id)
        {
            countryService.DeleteCountry(id);
            return RedirectToAction("Index");
        }

    }
}