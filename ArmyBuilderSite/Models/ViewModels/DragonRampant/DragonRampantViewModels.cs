using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyBuilderSite.Models.ViewModels.DragonRampant
{
    public class DRHomeVM
    {
        public CreateEditArmyModalVM CreateEditVM { get; set; }
    }

    public class CreateEditArmyModalVM {
        public string ButtonText { get; set; }
        public string TitleText { get; set; }
        public string Url { get; set; }
    }
}
