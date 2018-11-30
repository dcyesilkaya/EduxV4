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
    public class BranchesController : Controller
    {
        private readonly IBranchService branchService;
        private readonly IClassLevelService classLevelService;
        private readonly IRoomService roomService;
        public BranchesController(IBranchService branchService, IClassLevelService classLevelService, IRoomService roomService)
        {
            this.branchService = branchService;
            this.classLevelService = classLevelService;
            this.roomService = roomService;
        }
        public IActionResult Index()
        {
            var branch = branchService.GetBranches();
            return View(branch);
        }
        public IActionResult Create()
        {
            var branch = new Branch();
            ViewData["ClassLevelId"] = new SelectList(classLevelService.GetClassLevels(), "Id", "Name");
            ViewData["RoomId"] = new SelectList(roomService.GetRooms(), "Id", "Name");
            return View(branch);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Branch branch)
        {
            if (ModelState.IsValid)
            {
                branchService.InsertBranch(branch);
                return RedirectToAction(nameof(Edit), new { id = branch.Id, saved = true });
            }
            else
            {
                ViewData["ClassLevelId"] = new SelectList(classLevelService.GetClassLevels(), "Id", "Name");
                ViewData["RoomId"] = new SelectList(roomService.GetRooms(), "Id", "Name");
                return View(branch);
            }
        }
        public IActionResult Edit(string id, bool saved = false)
        {
            var branch = branchService.GetBranch(id);
            ViewBag.Saved = saved;
            ViewData["ClassLevelId"] = new SelectList(classLevelService.GetClassLevels(), "Id", "Name", branch.ClassLevelId);
            ViewData["RoomId"] = new SelectList(roomService.GetRooms(), "Id", "Name", branch.RoomId);
            return View(branch);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Branch branch)
        {
            if (ModelState.IsValid)
            {
                branchService.UpdateBranch(branch);
                return RedirectToAction(nameof(Edit), new { id = branch.Id, saved = true });

            }
            else
            {
                ViewData["ClassLevelId"] = new SelectList(classLevelService.GetClassLevels(), "Id", "Name", branch.ClassLevelId);
                ViewData["RoomId"] = new SelectList(roomService.GetRooms(), "Id", "Name", branch.RoomId);
                return View(branch);
            }
        }
        public ActionResult Delete(string id)
        {
            branchService.DeleteBranch(id);
            return RedirectToAction("Index");
        }
    }
}