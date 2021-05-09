using ArmyBuilderSite.BloodBowlModels;
using ArmyBuilderSite.Data;
using ArmyBuilderSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyBuilderSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public void SeedDatabase() {
            var races = new List<Race>();

            races.Add(new Race() { RaceName = "Humans", Description = "Humanities finest players", ReRollCost = 50000 });
            races.Add(new Race() { RaceName = "Skaven", Description = "Ratmen, agile and fragile", ReRollCost = 60000 });
            races.Add(new Race() { RaceName = "Orcs", Description = "Brutal, violent greenskins", ReRollCost = 60000 });

            var dbRaces = _db.Races.ToList();

            var toSeed = new List<Race>();

            foreach (var race in races)
            {
                if (!dbRaces.Where(x=> x.RaceName == race.RaceName).Any())
                {
                    toSeed.Add(race);
                }
            }

            _db.AddRange(toSeed);

            _db.SaveChanges();
        }
    }
}
