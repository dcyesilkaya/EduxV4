using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduxV4.Data;
using EduxV4.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EduxV4.Admin.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactService contactService;
        private readonly ICountryService countryService;
        private readonly ICityService cityService;
        private readonly ICountyService countyService;
        private readonly IDistrictService districtService;
        public ContactsController(IContactService contactService, ICountryService countryService, ICityService cityService, ICountyService countyService, IDistrictService districtService)
        {
            this.contactService = contactService;
            this.countryService = countryService;
            this.cityService = cityService;
            this.countyService = countyService;
            this.districtService = districtService;
        }
        // GET: Contacts
        public ActionResult Index()
        {
            var contacts = contactService.GetCandidateContacts();
            return View(contacts);
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            var contact = new Contact();
            ViewData["ParentId"] = new SelectList(contactService.GetParentContacts(),"Id","FullName");
            ViewData["Countries"] = new SelectList(countryService.GetCountries(), "Id", "Name");
            return View(contact);
        }



        // POST: Contacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contactService.InsertContact(contact);
                return RedirectToAction(nameof(Edit), new { id = contact.Id });
            }
            else
            {
                ViewData["ParentId"] = new SelectList(contactService.GetParentContacts(),"Id","FullName",contact.ParentId);
                ViewData["Countries"] = new SelectList(countryService.GetCountries(), "Id", "Name", contact.CountryId);
                ViewData["Cities"] = new SelectList(cityService.GetCities(contact.CountryId), "Id", "Name", contact.CityId);
                ViewData["Counties"] = new SelectList(countyService.GetCounties(contact.CityId), "Id", "Name", contact.CountyId);
                //ViewData["Districts"] = new SelectList(districtService.GetDistricts(contact.CountyId), "Id", "Name", contact.DistrictId);
                return View(contact);
            }
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(string id)
        {
            var contact = contactService.GetContact(id);
            ViewData["ParentId"] = new SelectList(contactService.GetParentContacts(),"Id","FullName",contact.ParentId);
            ViewData["Countries"] = new SelectList(countryService.GetCountries(), "Id", "Name", contact.CountryId);
            ViewData["Cities"] = new SelectList(cityService.GetCities(contact.CountryId), "Id", "Name", contact.CityId);
            ViewData["Counties"] = new SelectList(countyService.GetCounties(contact.CityId), "Id", "Name", contact.CountyId);
            //ViewData["Districts"] = new SelectList(districtService.GetDistricts(contact.CountyId), "Id", "Name", contact.DistrictId);
            return View(contact);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Contact contact)
        {  if (ModelState.IsValid)
            { 
                contactService.UpdateContact(contact);
                return RedirectToAction(nameof(Edit), new { id = contact.Id });
            } else { 
                ViewData["ParentId"] = new SelectList(contactService.GetParentContacts(),"Id","FullName",contact.ParentId);
                ViewData["Countries"] = new SelectList(countryService.GetCountries(), "Id", "Name", contact.CountryId);
                ViewData["Cities"] = new SelectList(cityService.GetCities(contact.CountryId), "Id", "Name", contact.CityId);
                ViewData["Counties"] = new SelectList(countyService.GetCounties(contact.CityId), "Id", "Name", contact.CountyId);
                //ViewData["Districts"] = new SelectList(districtService.GetDistricts(contact.CountyId), "Id", "Name", contact.DistrictId);
                return View(contact);
            }
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contacts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}