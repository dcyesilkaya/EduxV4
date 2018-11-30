using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EduxV4.Data;
using EduxV4.Repo;

namespace EduxV4.Admin.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Activities
        public async Task<IActionResult> Index(string forContactId = "")
        {
            var applicationDbContext = _context.Activities.Include(a => a.ActivityNextStep).Include(a => a.ActivitySource).Include(a => a.ActivityStatus).Include(a => a.ActivityType).Include(a => a.Campus).Include(a => a.ClassLevel).Include(a => a.Positiveness).Include(a => a.SchoolLevel).Include(a => a.Staff).Include(a=>a.Contact).Include(a=>a.ForContact).AsQueryable();
            if (!string.IsNullOrEmpty(forContactId))
            {
                applicationDbContext = applicationDbContext.Where(w => w.ForContactId == forContactId);
            }
            ViewBag.ForContactId = forContactId;
            var activities = await applicationDbContext.ToListAsync();
            return View(activities);
        }

        // GET: Activities/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .Include(a => a.ActivityNextStep)
                .Include(a => a.ActivitySource)
                .Include(a => a.ActivityStatus)
                .Include(a => a.ActivityType)
                .Include(a => a.Campus)
                .Include(a => a.ClassLevel)
                .Include(a => a.Positiveness)
                .Include(a => a.SchoolLevel)
                .Include(a => a.Staff)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // GET: Activities/Create
        public IActionResult Create(string forContactId)
        {
            ViewData["ActivityNextStepId"] = new SelectList(_context.ActivityNextSteps, "Id", "Name");
            ViewData["ActivitySourceId"] = new SelectList(_context.ActivitySources, "Id", "Name");
            ViewData["ActivityStatusId"] = new SelectList(_context.ActivityStatuses, "Id", "Name");
            ViewData["ActivityTypeId"] = new SelectList(_context.ActivityTypes, "Id", "Name");
            ViewData["CampusId"] = new SelectList(_context.Campuses, "Id", "Name");
            ViewData["ClassLevelId"] = new SelectList(_context.ClassLevels, "Id", "Name");
            ViewData["PositivenessId"] = new SelectList(_context.Positivenesses, "Id", "Name");
            ViewData["SchoolLevelId"] = new SelectList(_context.SchoolLevels, "Id", "Name");
            ViewData["StaffId"] = new SelectList(_context.Contacts.Where(c => c.ContactType == ContactType.Staff), "Id", "FullName");
            ViewData["ContactId"] = new SelectList(_context.Contacts.Where(c => c.ContactType == ContactType.Parent), "Id", "FullName");
            ViewData["ForContactId"] = new SelectList(_context.Contacts.Where(c => c.ContactType == ContactType.Student), "Id", "FullName", forContactId);
            var activity = new Activity();
            activity.ActivityDate = DateTime.Now;
            return View(activity);
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(Activity activity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activity);
                await _context.SaveChangesAsync();
                ViewBag.ScriptToRun = "LoadActivityIndex(true)";
                return View("Redirect");
            }
            ViewData["ActivityNextStepId"] = new SelectList(_context.ActivityNextSteps, "Id", "Name", activity.ActivityNextStepId);
            ViewData["ActivitySourceId"] = new SelectList(_context.ActivitySources, "Id", "Name", activity.ActivitySourceId);
            ViewData["ActivityStatusId"] = new SelectList(_context.ActivityStatuses, "Id", "Name", activity.ActivityStatusId);
            ViewData["ActivityTypeId"] = new SelectList(_context.ActivityTypes, "Id", "Name", activity.ActivityTypeId);
            ViewData["CampusId"] = new SelectList(_context.Campuses, "Id", "Name", activity.CampusId);
            ViewData["ClassLevelId"] = new SelectList(_context.ClassLevels, "Id", "Name", activity.ClassLevelId);
            ViewData["PositivenessId"] = new SelectList(_context.Positivenesses, "Id", "Name", activity.PositivenessId);
            ViewData["SchoolLevelId"] = new SelectList(_context.SchoolLevels, "Id", "Name", activity.SchoolLevelId);
            ViewData["StaffId"] = new SelectList(_context.Contacts.Where(c=>c.ContactType == ContactType.Staff), "Id", "Id", activity.StaffId);
            ViewData["ContactId"] = new SelectList(_context.Contacts.Where(c => c.ContactType == ContactType.Parent), "Id", "FullName", activity.ContactId);
            ViewData["ForContactId"] = new SelectList(_context.Contacts.Where(c => c.ContactType == ContactType.Student), "Id", "FullName", activity.ForContactId);
            return View(activity);
        }

        // GET: Activities/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities.SingleOrDefaultAsync(m => m.Id == id);
            if (activity == null)
            {
                return NotFound();
            }
            ViewData["ActivityNextStepId"] = new SelectList(_context.ActivityNextSteps, "Id", "Name", activity.ActivityNextStepId);
            ViewData["ActivitySourceId"] = new SelectList(_context.ActivitySources, "Id", "Name", activity.ActivitySourceId);
            ViewData["ActivityStatusId"] = new SelectList(_context.ActivityStatuses, "Id", "Name", activity.ActivityStatusId);
            ViewData["ActivityTypeId"] = new SelectList(_context.ActivityTypes, "Id", "Name", activity.ActivityTypeId);
            ViewData["CampusId"] = new SelectList(_context.Campuses, "Id", "Name", activity.CampusId);
            ViewData["ClassLevelId"] = new SelectList(_context.ClassLevels, "Id", "Name", activity.ClassLevelId);
            ViewData["PositivenessId"] = new SelectList(_context.Positivenesses, "Id", "Name", activity.PositivenessId);
            ViewData["SchoolLevelId"] = new SelectList(_context.SchoolLevels, "Id", "Name", activity.SchoolLevelId);
            ViewData["StaffId"] = new SelectList(_context.Contacts.Where(c => c.ContactType == ContactType.Staff), "Id", "FullName", activity.StaffId);
            ViewData["ContactId"] = new SelectList(_context.Contacts.Where(c => c.ContactType == ContactType.Parent), "Id", "FullName", activity.ContactId);
            ViewData["ForContactId"] = new SelectList(_context.Contacts.Where(c => c.ContactType == ContactType.Student), "Id", "FullName", activity.ForContactId);
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(string id, Activity activity)
        {
            if (id != activity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityExists(activity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.ScriptToRun = "LoadActivityIndex(true)";
                return View("Redirect");
            }
            ViewData["ActivityNextStepId"] = new SelectList(_context.ActivityNextSteps, "Id", "Id", activity.ActivityNextStepId);
            ViewData["ActivitySourceId"] = new SelectList(_context.ActivitySources, "Id", "Id", activity.ActivitySourceId);
            ViewData["ActivityStatusId"] = new SelectList(_context.ActivityStatuses, "Id", "Id", activity.ActivityStatusId);
            ViewData["ActivityTypeId"] = new SelectList(_context.ActivityTypes, "Id", "Id", activity.ActivityTypeId);
            ViewData["CampusId"] = new SelectList(_context.Campuses, "Id", "Id", activity.CampusId);
            ViewData["ClassLevelId"] = new SelectList(_context.ClassLevels, "Id", "Id", activity.ClassLevelId);
            ViewData["PositivenessId"] = new SelectList(_context.Positivenesses, "Id", "Id", activity.PositivenessId);
            ViewData["SchoolLevelId"] = new SelectList(_context.SchoolLevels, "Id", "Id", activity.SchoolLevelId);
            ViewData["StaffId"] = new SelectList(_context.Contacts, "Id", "Id", activity.StaffId);
            return View(activity);
        }

        // GET: Activities/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .Include(a => a.ActivityNextStep)
                .Include(a => a.ActivitySource)
                .Include(a => a.ActivityStatus)
                .Include(a => a.ActivityType)
                .Include(a => a.Campus)
                .Include(a => a.ClassLevel)
                .Include(a => a.Positiveness)
                .Include(a => a.SchoolLevel)
                .Include(a => a.Staff)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var activity = await _context.Activities.SingleOrDefaultAsync(m => m.Id == id);
            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();
            ViewBag.ScriptToRun = "LoadActivityIndex(true)";
            return View("Redirect");
        }

        private bool ActivityExists(string id)
        {
            return _context.Activities.Any(e => e.Id == id);
        }
    }
}
