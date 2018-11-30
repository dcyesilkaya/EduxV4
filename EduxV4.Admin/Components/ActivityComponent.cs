using EduxV4.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxV4.Admin.Components
{
    public class ActivityComponent:ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public ActivityComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var applicationDbContext = _context.Activities.Include(a => a.ActivityNextStep).Include(a => a.ActivitySource).Include(a => a.ActivityStatus).Include(a => a.ActivityType).Include(a => a.Campus).Include(a => a.ClassLevel).Include(a => a.Positiveness).Include(a => a.SchoolLevel).Include(a => a.Staff);
            return View("Index", await applicationDbContext.ToListAsync());
        }
    }
}
