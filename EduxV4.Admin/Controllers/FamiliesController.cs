using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduxV4.Data;
using EduxV4.Service;
using Microsoft.AspNetCore.Mvc;

namespace EduxV4.Admin.Controllers
{
    public class FamiliesController : Controller
    {
        private readonly IFamilyService familyService;
        private readonly IContactService contactService;
        public FamiliesController(IFamilyService familyService, IContactService contactService)
        {
            this.familyService = familyService;
            this.contactService = contactService;
        }
        public IActionResult Create(string contactId)
        {
            ViewBag.ContactId = contactId;
            var family = new Family();
            return View(family);
        }
        [HttpPost]
        public IActionResult Create(Family family, string contactId)
        {
            if (ModelState.IsValid && !String.IsNullOrEmpty(contactId))
            {
                
                familyService.InsertFamily(family);
                var contact = contactService.GetContact(contactId);
                contact.FamilyId = family.Id;
                contactService.UpdateContact(contact);
                return RedirectToAction("Edit", new { id = family.Id, contactId=contactId });
            }
            ViewBag.ContactId = contactId;
            return View(family);
        }

        public IActionResult Edit(string id, string contactId)
        {
            if (string.IsNullOrEmpty(id)) {
                
                return RedirectToAction("Create", new { contactId = contactId });
            }
            var family = familyService.GetFamily(id);
            ViewBag.ContactId = contactId;
            return View(family);
        }
    }
}