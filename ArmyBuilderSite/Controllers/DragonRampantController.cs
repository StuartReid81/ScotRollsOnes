using ArmyBuilderSite.BloodBowlModels;
using ArmyBuilderSite.Data;
using ArmyBuilderSite.DragonRampantModels;
using ArmyBuilderSite.Models.ViewModels.DragonRampant;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ArmyBuilderSite.Controllers.BloodbowlController;

namespace ArmyBuilderSite.Controllers
{
    public class DragonRampantController : Controller
    {
        public ApplicationDbContext _db;

        public DragonRampantController(ApplicationDbContext db)
        {
            _db = db;
        }

        #region Page Urls

        public IActionResult Home()
        {
            var vm = new CreateEditArmyModalVM() { ButtonText = "Create Army", TitleText = "Create Your Army", Url = "../../../DragonRampant/DoCreateArmy" };
            return View(new DRHomeVM() { CreateEditVM = vm });
        }

        #endregion

        #region Get Methods

        [HttpGet]
        [Route("/DragonRampant/UserArmies/Data")]
        public ActionResult GetUserArmies()
        {
            var user = _db.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();

            if (user == null)
            {
                return Json(new { error = "Please log in and reload page." });
            }

            var armies = _db.Armies.Where(x => x.UserId == user.Id && !x.IsSoftDeleted).Select(x =>
                new {
                    x.Id,
                    x.Name,
                    x.LeaderName,
                    x.Points
                }).ToList();

            return Json(new { data = armies });
        }
        #endregion

        #region Post Methods

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DoCreateArmy(DoCreateArmyDTO dto)
        {
            var user = _db.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();

            if (user == null)
            {
                return Json(new { Success = false, Error = "Unable to validate this user on the database, please relog and try again." });
            }

            var dbTeam = _db.Armies.Where(x => x.Name == dto.ArmyName && x.UserId == user.Id).FirstOrDefault();

            if (dbTeam != null)
            {
                return Json(new { Success = false, Error = "You already have a team with this name saved on your account! This may be in your recycle bin. Either restore the team or empty it from the bin." });
            }

            var newArmy = new Army()
            {
                Name = dto.ArmyName,
                LeaderName = dto.LeaderName,
                IsPublic = dto.Public,
                IsSoftDeleted = false,
                UserId = user.Id,
                DateAdded = DateTimeOffset.Now,
                Points = 0,
            };

            try
            {
                _db.Armies.Add(newArmy);
                _db.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = "unable to save changes to the database", ex });
            }
        }

        #endregion

        #region DTOs
        public class DoCreateArmyDTO
        {
            public string ArmyName { get; set; }

            public string LeaderName { get; set; }

            public bool Public { get; set; }
        }
        #endregion
    }
}
