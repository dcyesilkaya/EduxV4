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
    public class DistrictsController : Controller
    {
        public readonly IDistrictService districtService;
        public readonly ICountyService countyService;
        public DistrictsController(IDistrictService districtService, ICountyService countyService)
        {
            this.districtService = districtService;
            this.countyService = countyService;
        }
        public IActionResult Index()
        {
            var district = districtService.GetDistricts();
            return View(district);
        }

        public IActionResult Create()
        {
            var district = new District();
            ViewData["CountyId"] = new SelectList(countyService.GetCounties(), "Id", "Name");
            return View(district);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(District district)
        {
            if(ModelState.IsValid)
            {
                districtService.InsertDistrict(district);
                return RedirectToAction("Edit", new { id = district.Id, saved = true });
            }
            
            ViewData["CountyId"] = new SelectList(countyService.GetCounties(), "Id", "Name", district.CountyId);
            return View(district);
           
        }
        public IActionResult Edit(string id, bool saved= false)
        {
            var district = districtService.GetDistrict(id);
            ViewData["CountyId"] = new SelectList(countyService.GetCounties(), "Id", "Name");
            ViewBag.Saved = saved;
            return View(district);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, District district)
        {
            if(ModelState.IsValid)
            {
                districtService.UpdateDistrict(district);
                return RedirectToAction("Edit", new { id = district.Id, saved = true });
            }
            ViewData["CountyId"] = new SelectList(countyService.GetCounties(), "Id", "Name", district.CountyId);
            return View(district);

        }
        public IActionResult Delete(string id)
        {
            districtService.DeleteDistrict(id);
            return RedirectToAction("Index");
            
        }
    }

}