using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MapExplore.Models;


namespace MapExplore.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetBreweries()
        {
            Brewery newBrewery = new Brewery();
            newBrewery.GetBreweries();
            return View(newBrewery);
        }
    }
}
