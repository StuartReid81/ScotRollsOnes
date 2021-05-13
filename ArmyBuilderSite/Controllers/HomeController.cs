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
            #region Special Rules Seed
            var sr = new List<SpecialRule>();

            sr.Add(new SpecialRule() { RuleName = "Underworld Challenge", Description = "A secretive league that, until only recently, many pundits refused to believe even existed! The Underworld Challenge hosts many strange and diverse teams, the likes of which are rarely seen in daylight.For a horrifying spectacle, it is second to none!", TeamSpecialRule = false  });
            sr.Add(new SpecialRule() { RuleName = "Old World Classic", Description = "Since the collapse of the NAF, Blood Bowl in the Old World has struggled. But in recent years the sport’s fortunes have improved, largely thanks to the founding of the Old World Classic, a competition that draws together many minor leagues.", TeamSpecialRule = false  });
            sr.Add(new SpecialRule() { RuleName = "Badlands Brawl", Description = "The Badlands Brawl is home to a great many Greenskin and Ogre teams. Unsurprisingly, Blood Bowl in the Badlands is a brutal, violent and extremely dishonest affair, but these are virtues that make it ever popular with the fans!", TeamSpecialRule = false  });


            var dbSpecialRules = _db.SpecialRules.ToList();

            var rulesToSeed = new List<SpecialRule>();

            foreach (var rule in sr)
            {
                if (!dbSpecialRules.Where(x => x.RuleName == rule.RuleName).Any())
                {
                    rulesToSeed.Add(rule);
                }
            }

            _db.AddRange(rulesToSeed);

            _db.SaveChanges();

            #endregion

            #region Race Seed
            var races = new List<Race>();

            races.Add(new Race() { RaceName = "Humans", Description = "Humanities finest players", ReRollCost = 50000, Tier = TeamTier.One, ApothecaryAllowed = true, SpecialRules = new List<RaceSpecialRule>() { new RaceSpecialRule() { SpecialRuleId = _db.SpecialRules.Where(x => x.RuleName == "Old World Classic").FirstOrDefault().Id } } });
            races.Add(new Race() { RaceName = "Skaven", Description = "Ratmen, agile and fragile", ReRollCost = 50000, Tier = TeamTier.One, ApothecaryAllowed = true, SpecialRules = new List<RaceSpecialRule>() { new RaceSpecialRule() { SpecialRuleId = _db.SpecialRules.Where(x => x.RuleName == "Underworld Challenge").FirstOrDefault().Id } }  });
            races.Add(new Race() { RaceName = "Orcs", Description = "Brutal, violent greenskins", ReRollCost = 60000, Tier = TeamTier.One, ApothecaryAllowed = true, SpecialRules = new List<RaceSpecialRule>() { new RaceSpecialRule() { SpecialRuleId = _db.SpecialRules.Where(x => x.RuleName == "Badlands Brawl").FirstOrDefault().Id } }});

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

            _db.SaveChanges();

            #endregion

            #region Skill Seed
            var skills = new List<Skill>();

            skills.Add(new Skill() { SkillName = "Pass", Effect = "This player may re-roll a failed Passing Ability test when performing a Pass action.", SkillGroup = SkillGroup.Passing });
            skills.Add(new Skill() { SkillName = "Sure Hands", Effect = "This player may re-roll any failed attempt to pick up the ball. In addition, the Strip Ball skill cannot be used against a player with this Skill.", SkillGroup = SkillGroup.Agility });
            skills.Add(new Skill() { SkillName = "Dodge", Effect = "Once per team turn, during their activation, this player may re - roll a failed Agility test when attempting to Dodge. Additionally, this player may choose to use this Skill when theyare the target of a Block action and a Stumble result is applied against them, as described on page 57.", SkillGroup = SkillGroup.Agility });
            skills.Add(new Skill() { SkillName = "Block", Effect = "When a Both Down result is applied during a Block action, this player may choose to ignore it and not be Knocked Down, as described on page 5", SkillGroup = SkillGroup.General  });
            skills.Add(new Skill() { SkillName = "Animal Savagery", Effect = "See Traits, page 81", SkillGroup = SkillGroup.Trait  });
            skills.Add(new Skill() { SkillName = "Frenzy", Effect = "See General Skills, page 77", SkillGroup = SkillGroup.General  });
            skills.Add(new Skill() { SkillName = "Loner (4+)", Effect = "If this player wishes to use a team re-roll, roll a D6. If you roll equal to or higher than the target number shown in brackets, this player may use the team re-roll as normal. Otherwise, the original result stands without being re-rolled but the team re-roll is lost just as if it had been used", SkillGroup = SkillGroup.Trait  });
            skills.Add(new Skill() { SkillName = "Mighty Blow (+1)", Effect = "When an opposition player is Knocked Down as the result of a Block action performed by this player (on its own or as part of a Blitz action), you may modify either the Armour roll or Injury roll by the amount shown in brackets.This modifier may be applied after the roll has been made.This Skill cannot be used with the Stab or Chainsaw traits.", SkillGroup = SkillGroup.Strength  });
            skills.Add(new Skill() { SkillName = "Prehensile Tail", Effect = "When an active opposition player attempts to Dodge, Jump or Leap in order to vacate a square in which they are being Marked by this player, there is an additional - 1 modifier applied to the active player’s Agility test. If the opposition player is being Marked by more than one player with this Mutation, only one player may use it.", SkillGroup = SkillGroup.Mutations  });

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

            _db.SaveChanges();

            #endregion

            #region Base Player Seed
            var basePlayers = new List<RaceBasicPlayer>();

            #region Skaven
            basePlayers.Add(new RaceBasicPlayer() { 
                RaceId = _db.Races.Where(x => x.RaceName == "Skaven").FirstOrDefault().Id, 
                Agility = 3, 
                PositionName = "Clan Rat Lineman",
                ArmourValue = 8, 
                PassingAbility = 4, 
                MaximumAllowed = 16, 
                Cost = 50000, 
                Movement = 7, 
                Strength = 3, 
                AllowedSkills = new List<PlayerSkillGroups>() {
                    new PlayerSkillGroups() { Primary = true, SkillGroup = SkillGroup.General },
                    new PlayerSkillGroups() { Primary = false, SkillGroup = SkillGroup.Agility },
                    new PlayerSkillGroups() { Primary = false, SkillGroup = SkillGroup.Mutations },
                    new PlayerSkillGroups() { Primary = false, SkillGroup = SkillGroup.Strength },
                } 
            });
            basePlayers.Add(new RaceBasicPlayer()
            {
                RaceId = _db.Races.Where(x => x.RaceName == "Skaven").FirstOrDefault().Id,
                Agility = 3,
                PositionName = "Thrower",
                ArmourValue = 8,
                PassingAbility = 2,
                MaximumAllowed = 2,
                Cost = 85000,
                Movement = 7,
                Strength = 3,
                StartingSkills = new List<StartingPlayerSkill>() {
                    new StartingPlayerSkill() { SkillId = _db.Skills.Where(x => x.SkillName == "Pass").FirstOrDefault().Id },
                    new StartingPlayerSkill() { SkillId = _db.Skills.Where(x => x.SkillName == "Sure Hands").FirstOrDefault().Id }
                },
                AllowedSkills = new List<PlayerSkillGroups>() {
                    new PlayerSkillGroups() { Primary = true, SkillGroup = SkillGroup.General },
                    new PlayerSkillGroups() { Primary = true, SkillGroup = SkillGroup.Passing },
                    new PlayerSkillGroups() { Primary = false, SkillGroup = SkillGroup.Agility },
                    new PlayerSkillGroups() { Primary = false, SkillGroup = SkillGroup.Mutations },
                    new PlayerSkillGroups() { Primary = false, SkillGroup = SkillGroup.Strength },
                }
            });
            basePlayers.Add(new RaceBasicPlayer()
            {
                RaceId = _db.Races.Where(x => x.RaceName == "Skaven").FirstOrDefault().Id,
                Agility = 2,
                PositionName = "Gutter Runner",
                ArmourValue = 8,
                PassingAbility = 4,
                MaximumAllowed = 4,
                Cost = 85000,
                Movement = 9,
                Strength = 2,
                StartingSkills = new List<StartingPlayerSkill>() {
                    new StartingPlayerSkill() { SkillId = _db.Skills.Where(x => x.SkillName == "Dodge").FirstOrDefault().Id },
                },
                AllowedSkills = new List<PlayerSkillGroups>() {
                    new PlayerSkillGroups() { Primary = true, SkillGroup = SkillGroup.Agility },
                    new PlayerSkillGroups() { Primary = true, SkillGroup = SkillGroup.General },
                    new PlayerSkillGroups() { Primary = false, SkillGroup = SkillGroup.Passing },
                    new PlayerSkillGroups() { Primary = false, SkillGroup = SkillGroup.Mutations },
                    new PlayerSkillGroups() { Primary = false, SkillGroup = SkillGroup.Strength },
                }
            });
            basePlayers.Add(new RaceBasicPlayer()
            {
                RaceId = _db.Races.Where(x => x.RaceName == "Skaven").FirstOrDefault().Id,
                Agility = 3,
                PositionName = "Blitzer",
                ArmourValue = 9,
                PassingAbility = 5,
                MaximumAllowed = 4,
                Cost = 90000,
                Movement = 7,
                Strength = 3,
                StartingSkills = new List<StartingPlayerSkill>() {
                    new StartingPlayerSkill() { SkillId = _db.Skills.Where(x => x.SkillName == "Block").FirstOrDefault().Id },
                },
                AllowedSkills = new List<PlayerSkillGroups>() {
                    new PlayerSkillGroups() { Primary = true, SkillGroup = SkillGroup.Strength },
                    new PlayerSkillGroups() { Primary = true, SkillGroup = SkillGroup.General },
                    new PlayerSkillGroups() { Primary = false, SkillGroup = SkillGroup.Passing },
                    new PlayerSkillGroups() { Primary = false, SkillGroup = SkillGroup.Mutations },
                    new PlayerSkillGroups() { Primary = false, SkillGroup = SkillGroup.Agility },
                }
            });
            basePlayers.Add(new RaceBasicPlayer()
            {
                RaceId = _db.Races.Where(x => x.RaceName == "Skaven").FirstOrDefault().Id,
                Agility = 4,
                PositionName = "Rat Ogre",
                ArmourValue = 9,
                PassingAbility = 0,
                MaximumAllowed = 1,
                Cost = 150000,
                Movement = 6,
                Strength = 5,
                StartingSkills = new List<StartingPlayerSkill>() {
                    new StartingPlayerSkill() { SkillId = _db.Skills.Where(x => x.SkillName == "Animal Savagery").FirstOrDefault().Id },
                    new StartingPlayerSkill() { SkillId = _db.Skills.Where(x => x.SkillName == "Frenzy").FirstOrDefault().Id },
                    new StartingPlayerSkill() { SkillId = _db.Skills.Where(x => x.SkillName == "Loner (4+)").FirstOrDefault().Id },
                    new StartingPlayerSkill() { SkillId = _db.Skills.Where(x => x.SkillName == "Mighty Blow (+1)").FirstOrDefault().Id },
                    new StartingPlayerSkill() { SkillId = _db.Skills.Where(x => x.SkillName == "Prehensile Tail").FirstOrDefault().Id }
                },
                AllowedSkills = new List<PlayerSkillGroups>() {
                    new PlayerSkillGroups() { Primary = true, SkillGroup = SkillGroup.Strength },
                    new PlayerSkillGroups() { Primary = false, SkillGroup = SkillGroup.General },
                    new PlayerSkillGroups() { Primary = false, SkillGroup = SkillGroup.Mutations },
                    new PlayerSkillGroups() { Primary = false, SkillGroup = SkillGroup.Agility },
                }
            });
            #endregion

            var dbBasePlayers = _db.BasePlayers.ToList();

            var basePlayersToSeed = new List<RaceBasicPlayer>();

            foreach (var pl in basePlayers)
            {
                if (!dbBasePlayers.Where(x => x.Race == pl.Race && x.PositionName == pl.PositionName).Any())
                {
                    basePlayersToSeed.Add(pl);
                }
            }

            _db.AddRange(basePlayersToSeed);

            _db.SaveChanges();

            #endregion
        }
    }
}
