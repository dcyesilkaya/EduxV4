using EduxV4.Data;
using EduxV4.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxV4.Admin.Controllers
{
    public class SeasonsController : Controller
    {

        private readonly ISeasonService seasonService;
        public SeasonsController(ISeasonService seasonService)

        {
            this.seasonService = seasonService;
        }

        //GET ActivityTypes (Tüm aktivity typlerı getirir)
        public IActionResult Index()
        {
            var seasons = seasonService.GetSeasons();
            return View(seasons);
        }
        public ActionResult Edit(string id)
        {
            Season season = seasonService.GetSeason(id);
            return View(season);





        }

        public ActionResult Create()
        {
            Season season = new Season();
            return View(season);
        }
        [HttpPost]
        public ActionResult Create(Season season)
        {
           
            return View(season);
        }
        public ActionResult Delete(int id)
        {
            Season season = new Season();
            return View(season);


        }



    }




}
