using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduxV4.Data;
using EduxV4.Service;
using Microsoft.AspNetCore.Mvc;

namespace EduxV4.Admin.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomService roomService;
        public RoomsController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        public IActionResult Index()
        {
            var rooms = roomService.GetRooms();
            return View(rooms); 
        }

        public IActionResult Create()
        {
            var room = new Room();
            return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                roomService.InsertRoom(room);
                return RedirectToAction(nameof(Edit), new { id = room.Id, saved = true });
            }
            else
            {
                return View(room);
            }
        }

        public IActionResult Edit(string id, bool saved = false)
        {
            var room = roomService.GetRoom(id);
            ViewBag.Saved = saved;
            return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Room room)
        {
            if (ModelState.IsValid)
            {
                roomService.UpdateRoom(room);
                return RedirectToAction(nameof(Edit), new { id = room.Id, saved = true });
            }
            else
            {
                return View(room);
            }
        }

        public IActionResult Delete(string id)
        {
            roomService.DeleteRoom(id);
            return RedirectToAction("Index");
        }
    }
}