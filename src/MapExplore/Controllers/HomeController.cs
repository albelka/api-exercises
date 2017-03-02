using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MapExplore.Models;
using System.Diagnostics;

namespace MapExplore.Controllers
{
    public class HomeController : Controller
    {
        private MapExploreDbContext db = new MapExploreDbContext();
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetBreweries()
        {
            
            List<Brewery> myList= Brewery.GetBreweries();
            Debug.WriteLine("LIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIST" + myList[0]);
            foreach(var brew in myList)
            {
                Debug.WriteLine("***************************************************************" + brew);
            db.Breweries.Add(brew);
            db.SaveChanges();
            }


            return View(myList);
        }
    }
}
