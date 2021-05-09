using ArmyBuilderSite.BloodBowlModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyBuilderSite.Models.ViewModels.Bloodbowl
{
    public class BBUserHomeVM
    {
        public List<Team> Teams { get; set; }

        public CreateEditTeamModalVM ModalVM { get; set; }
    }

    public class CreateEditTeamModalVM {
        public string Title { get; set; }

        public string ButtonText { get; set; }

        public string URL { get; set; }

        public List<SelectListItem> Races { get; set; }
    }

    public class ViewTeamVM {
        public string Error { get; set; }

        public Team Team { get; set; }
    }
}
