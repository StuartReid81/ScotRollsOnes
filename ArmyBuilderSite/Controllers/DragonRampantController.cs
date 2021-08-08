using ArmyBuilderSite.Models.ViewModels.DragonRampant;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyBuilderSite.Controllers
{
    public class DragonRampantController : Controller
    {
        public IActionResult Home()
        {
            var vm = new CreateEditArmyModalVM() { ButtonText = "Create Army", TitleText = "Create Your Army" };
            return View(new DRHomeVM() { CreateEditVM = vm });
        }
    }
}
