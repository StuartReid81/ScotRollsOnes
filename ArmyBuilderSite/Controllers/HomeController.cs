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
            #region Race Seed
            var races = new List<Race>();

            races.Add(new Race() { RaceName = "Humans", Description = "Humanities finest players", ReRollCost = 50000 });
            races.Add(new Race() { RaceName = "Skaven", Description = "Ratmen, agile and fragile", ReRollCost = 60000 });
            races.Add(new Race() { RaceName = "Orcs", Description = "Brutal, violent greenskins", ReRollCost = 60000 });

            var dbRaces = _db.Races.ToList();

            var racesToSeed = new List<Race>();

            foreach (var race in races)
            {
                if (!dbRaces.Where(x=> x.RaceName == race.RaceName).Any())
                {
                    racesToSeed.Add(race);
                }
            }

            _db.AddRange(racesToSeed);

            #endregion

            #region Skill Seed
            var skills = new List<Skill>();

            skills.Add(new Skill() { SkillName = "Pass", Effect = "This player may re-roll a failed Passing Ability test when performing a Pass action.", SkillGroup = SkillGroup.Passing });
            skills.Add(new Skill() { SkillName = "Sure Hands", Effect = "This player may re-roll any failed attempt to pick up the ball. In addition, the Strip Ball skill cannot be used against a player with this Skill.", SkillGroup = SkillGroup.Agility });
            skills.Add(new Skill() { SkillName = "Dodge", Effect = "Once per team turn, during their activation, this player may re - roll a failed Agility test when attempting to Dodge. Additionally, this player may choose to use this Skill when theyare the target of a Block action and a Stumble result is applied against them, as described on page 57.", SkillGroup = SkillGroup.Agility });
            skills.Add(new Skill() { SkillName = "Block", Effect = "When a Both Down result is applied during a Block action, this player may choose to ignore it and not be Knocked Down, as described on page 5", SkillGroup = SkillGroup.General  });

            var dbSkills = _db.Skills.ToList();

            var skillsToSeed = new List<Skill>();

            foreach (var skill in skills)
            {
                if (!dbSkills.Where(x => x.SkillName == skill.SkillName).Any())
                {
                    skillsToSeed.Add(skill);
                }
            }

            _db.AddRange(skillsToSeed);

            #endregion

            _db.SaveChanges();
        }
    }
}
