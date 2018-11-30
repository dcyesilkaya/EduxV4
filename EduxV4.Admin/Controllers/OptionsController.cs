using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EduxV4.Admin.Controllers
{
    public class OptionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}