using ArmyBuilderSite.Data;
using Microsoft.AspNetCore.Mvc;

namespace ArmyBuilderSite.Controllers
{
    public class FortyKCrusadeController : Controller
    {
        public ApplicationDbContext _db;
        public FortyKCrusadeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Home()
        {
            if (TempData["Success"] != null)
            {
                ViewData["Success"] = TempData["Success"];
            }

            return View();
        }
    }
}
