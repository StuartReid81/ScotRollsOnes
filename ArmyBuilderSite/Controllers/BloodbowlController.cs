using ArmyBuilderSite.BloodBowlModels;
using ArmyBuilderSite.Data;
using ArmyBuilderSite.Models.ViewModels.Bloodbowl;
using ArmyBuilderSite.Services.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyBuilderSite.Controllers
{
    [Authorize]
    public class BloodbowlController : Controller
    {
        public ApplicationDbContext _db;

        public BloodbowlController(ApplicationDbContext db)
        {
            _db = db;
        }

        #region Page Urls

        public IActionResult Home()
        {
            if (TempData["Success"] != null)
            {
                ViewData["Success"] = TempData["Success"];
            }
            var teams = _db.Teams.Where(x => x.UserName == User.Identity.Name && x.IsSoftDeleted != true).Include(x => x.Race).ToList();

            var races = _db.Races.Select(x => new SelectListItem() { Text = $"{x.RaceName}, {x.Description}.", Value = x.Id.ToString() }).ToList();

            var modalVM = new CreateEditTeamModalVM() { Title = "Create a new team", Races = races, ButtonText = "Create Team", URL = "../../../../BloodBowl/DoCreateTeam" };

            var vm = new BBUserHomeVM() { Teams = teams, ModalVM = modalVM };

            return View(vm);
        }

        [HttpGet]
        [Route("/Bloodbowl/Team/View/{id}")]
        public IActionResult TeamPage(int id) {
            if (TempData["Success"] != null)
            {
                ViewData["Success"] = TempData["Success"];
            }

            var team = _db.Teams.Where(x => x.Id == id).Include(x => x.Race).ThenInclude(x => x.SpecialRules).ThenInclude(x => x.SpecialRule).Include(x => x.TeamRoster).FirstOrDefault();

            var error = "";

            if (team == null)
            {
                error = "Unable to find this team on the database.";
            }
            else
            {
                if (!team.IsPublic && team.UserName != User.Identity.Name)
                {
                    error = "You are not elligible to view this team.";
                }
            }

            var sr = "";

            foreach (var rule in team.Race.SpecialRules)
            {
                sr += $"{rule.SpecialRule.RuleName}, ";
            }

            sr = sr.Substring(0, sr.LastIndexOf(","));

            var races = _db.Races.Select(x => new SelectListItem() { Text = $"{x.RaceName}, {x.Description}.", Value = x.Id.ToString() }).ToList();

            var modalVM = new CreateEditTeamModalVM() { Title = "Edit your team", Races = races, ButtonText = "Edit Team", URL = "../../../../BloodBowl/DoEditTeam" };

            var teamVM = new ViewTeamVM() { Error = error, ModalVM = modalVM, Team = new ViewTeamDataVM() {
                TeamName = team.TeamName, // in
                ManagerName = team.ManagerName, // in
                Gold = team.Gold, // in
                ActivePlayers = team.TeamRoster.Where(x => x.IsActive).Count(), //in
                TotalPlayers = team.TeamRoster.Count(), //in
                Apothecaries = team.Apothecaries,
                AssistantCoaches = team.AssistantCoaches,
                BeingCreated = team.BeingCreated, //in
                CasualtiesInflicted = team.CasualtiesInflicted,
                Cheerleaders = team.Cheerleaders,
                CurrentTeamRoster = team.TeamRoster,
                DateCreated = team.DateCreated, //in
                DateSoftDeleted = team.DateSoftDeleted,
                Draws = team.Draws,
                FanFactor = team.FanFactor,
                Id = team.Id,
                IsPublic = team.IsPublic, //in
                IsSoftDeleted = team.IsSoftDeleted, //in
                League = team.League,
                LeaguePoints = team.LeaguePoints,
                Losses = team.Losses,
                RaceId = team.RaceId,
                RaceName = team.Race.RaceName, //in
                ReRolls = team.ReRolls,
                TotalGamesPlayed = team.TotalGamesPlayed,
                TouchDowns = team.TouchDowns,
                UserName = team.UserName, //in
                Wins = team.Wins,
                SpecialRules = sr,
                Tier = team.Race.Tier.ToString()
            } };


            return View("TeamPage", teamVM);
        }

        #endregion

        #region Post Methods
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DoCreateTeam(DoCreateTeamDTO dto)
        {
            var race = _db.Races.Where(x => x.Id.ToString() == dto.Race).FirstOrDefault();

            if (race == null)
            {
                return Json(new { Success = false, Error = "Unable to find this race in the database." });
            }

            var user = _db.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();

            if (user == null)
            {
                return Json(new { Success = false, Error = "Unable to validate this user on the database, please relog and try again." });
            }

            var dbTeam = _db.Teams.Where(x => x.TeamName == dto.TeamName && x.UserId == user.Id).FirstOrDefault();

            if (dbTeam != null)
            {
                return Json(new { Success = false, Error = "You already have a team with this name saved on your account! This may be in your recycle bin. Either restore the team or empty it from the bin." });
            }

            var newTeam = new Team()
            {
                TeamName = dto.TeamName,
                ManagerName = dto.ManagerName,
                RaceId = race.Id,
                IsPublic = dto.Public,
                Gold = 1000000,
                IsSoftDeleted = false,
                UserId = user.Id,
                UserName = user.UserName,
                DateCreated = DateTimeOffset.Now,
                BeingCreated = true
            };

            try
            {
                _db.Teams.Add(newTeam);
                _db.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = "unable to save changes to the database", ex });
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult DoSoftDeleteTeam(DoDeleteTeamDTO dto) {
            var team = _db.Teams.Where(x => x.Id == dto.TeamId).FirstOrDefault();

            if (team == null)
            {
                return Json(new { Success = false, Error = "Unable to find this team on the database." });
            }

            if (team.UserName != User.Identity.Name)
            {
                return Json(new { Success = false, Error = "This team does not belong to you." });
            }

            team.IsSoftDeleted = true;
            team.DateSoftDeleted = DateTimeOffset.Now;

            try
            {
                _db.Update(team);
                _db.SaveChanges();
                return Json(new { Success = true });
            }
            catch (Exception)
            {
                return Json(new { Success = false, Error = "Unable to update the database." });
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult DoRestoreTeam(DoDeleteTeamDTO dto)
        {
            var team = _db.Teams.Where(x => x.Id == dto.TeamId).FirstOrDefault();

            if (team == null)
            {
                return Json(new { Success = false, Error = "Unable to find this team on the database." });
            }

            if (team.UserName != User.Identity.Name)
            {
                return Json(new { Success = false, Error = "This team does not belong to you." });
            }

            if (!team.IsSoftDeleted)
            {
                return Json(new { Success = false, Error = "This team is already active." });
            }

            team.IsSoftDeleted = false;

            try
            {
                _db.Update(team);
                _db.SaveChanges();
                return Json(new { Success = true });
            }
            catch (Exception)
            {
                return Json(new { Success = false, Error = "Unable to update the database." });
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult DoHardDeleteTeam(DoDeleteTeamDTO dto)
        {
            var team = _db.Teams.Where(x => x.Id == dto.TeamId).FirstOrDefault();

            if (team == null)
            {
                return Json(new { Success = false, Error = "Unable to find this team on the database." });
            }

            if (team.UserName != User.Identity.Name)
            {
                return Json(new { Success = false, Error = "This team does not belong to you." });
            }

            if (!team.IsSoftDeleted)
            {
                return Json(new { Success = false, Error = "This team is not currently in the recycle bin." });
            }

            try
            {
                _db.Remove(team);
                _db.SaveChanges();
                if (dto.FromTeamPage)
                {
                    TempData["Success"] = "Team emptied from recycle bin.";
                }
                return Json(new { Success = true });
            }
            catch (Exception)
            {
                return Json(new { Success = false, Error = "Unable to update the database." });
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult DoHardDeleteAllTeams(DoDeleteTeamDTO dto)
        {
            var teams = _db.Teams.Where(x => x.UserName == User.Identity.Name && x.IsSoftDeleted ).ToList();

            if (teams == null)
            {
                return Json(new { Success = false, Error = "Unable to find any teams on the database." });
            }

            try
            {
                _db.RemoveRange(teams);
                _db.SaveChanges();
                if (dto.FromTeamPage)
                {
                    TempData["Success"] = "All teams emptied from recycle bin.";
                }
                return Json(new { Success = true });
            }
            catch (Exception)
            {
                return Json(new { Success = false, Error = "Unable to update the database." });
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult DoEditTeam(DoEditTeamDTO dto) {
            var team = _db.Teams.Where(x => x.Id == dto.TeamId).FirstOrDefault();

            if (team == null)
            {
                return Json(new { Success = false, Error = "Unable to find this team on the database." });
            }

            if (team.UserName != User.Identity.Name)
            {
                return Json(new { Success = false, Error = "This team does not belong to you." });
            }

            var race = _db.Races.Where(x => x.Id.ToString() == dto.Race).FirstOrDefault();

            if (race == null)
            {
                return Json(new { Success = false, Error = "Unable to find this race in the database." });
            }

            if (team.TeamName == dto.TeamName && team.ManagerName == dto.ManagerName && team.RaceId == race.Id && team.IsPublic == dto.Public)
            {
                return Json(new { Success = false, Error = "There were no changed detected." });
            }

            team.TeamName = dto.TeamName;
            team.ManagerName = dto.ManagerName;
            team.IsPublic = dto.Public;
            team.RaceId = race.Id;

            try
            {
                _db.SaveChanges();
                return Json(new { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Error = "Unable to save changes on the database.", Ex = ex });
            }
        }

        #endregion

        #region Get Methods

        [HttpGet]
        [Route("/Bloodbowl/UserTeams/Data")]
        public ActionResult GetUserTeams() {
            var user = _db.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();

            if (user == null)
            {
                return Json(new { error = "Please log in and reload page." });
            }

            var teams = _db.Teams.Where(x => x.UserId == user.Id && !x.IsSoftDeleted).Include(x => x.Race).Select(x => 
                new { x.Id, 
                        x.TeamName, 
                        x.ManagerName, 
                        race = x.Race.RaceName }).ToList();

            return Json(new { data = teams });
        }

        [HttpGet]
        [Route("/Bloodbowl/UserTeams/Deleted/Data")]
        public ActionResult GetDeletedUserTeams()
        {
            var user = _db.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();

            if (user == null)
            {
                return Json(new { error = "Please log in and reload page." });
            }

            var teams = _db.Teams.Where(x => x.UserId == user.Id && x.IsSoftDeleted).Include(x => x.Race).Select(x => 
            new { x.Id, 
                    x.TeamName, 
                    x.ManagerName, 
                    race = x.Race.RaceName,
                    DateDeleted = x.DateSoftDeleted.ToMomentString(),
            }).ToList();

            return Json(new { data = teams });
        }

        #endregion

        #region DTOs
        public class DoCreateTeamDTO
        {
            public string TeamName { get; set; }

            public string ManagerName { get; set; }

            public string Race { get; set; }

            public bool Public { get; set; }
        }

        public class DoDeleteTeamDTO {
            public int TeamId { get; set; }

            public bool FromTeamPage { get; set; }
        }

        public class DoEditTeamDTO {
            public int TeamId { get; set; }

            public string TeamName { get; set; }

            public string ManagerName { get; set; }

            public string Race { get; set; }

            public bool Public { get; set; }
        }
        
        #endregion
    }
}
