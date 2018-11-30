using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduxV4.Data;
using EduxV4.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduxV4.Admin.Controllers
{
    public class SiblingsController : Controller
    {
        private readonly IContactService contactService;
        public SiblingsController(IContactService contactService)
        {
            this.contactService = contactService;
        }
        // GET: Contacts
        public ActionResult Index(string id)
        {
            var contacts = contactService.GetSiblingContacts(id);
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
                return View(contact);
            }
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(string id)
        {
            var contact = contactService.GetContact(id);
            return View(contact);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Contact contact)
        {  if (ModelState.IsValid)
            { 
                contactService.UpdateContact(contact);
                return RedirectToAction(nameof(Edit), new { id = contact.Id });
            } else { 
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