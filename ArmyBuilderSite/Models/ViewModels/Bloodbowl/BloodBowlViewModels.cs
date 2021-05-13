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

        public ViewTeamDataVM Team { get; set; }

        public CreateEditTeamModalVM ModalVM { get; set; }
    }

    public class ViewTeamDataVM {

        public int Id { get; set; }

        public string UserName { get; set; }

        public string TeamName { get; set; }

        public string RaceName { get; set; }

        public int RaceId { get; set; }

        public string SpecialRules { get; set; }

        public string Tier { get; set; }

        public int Gold { get; set; }

        public string ManagerName { get; set; }

        public int ActivePlayers { get; set; }

        public int TotalPlayers { get; set; }

        public List<Player> CurrentTeamRoster { get; set; }

        public int Cheerleaders { get; set; }

        public int FanFactor { get; set; }

        public int ReRolls { get; set; }

        public int AssistantCoaches { get; set; }

        public int Apothecaries { get; set; }

        public int TotalGamesPlayed { get; set; }

        public int Wins { get; set; }

        public int Draws { get; set; }

        public int Losses { get; set; }

        public int TouchDowns { get; set; }

        public int CasualtiesInflicted { get; set; }

        public string League { get; set; }

        public int LeaguePoints { get; set; }

        public bool IsSoftDeleted { get; set; }

        public DateTimeOffset DateSoftDeleted { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public bool IsPublic { get; set; }

        public bool BeingCreated { get; set; }
    }
}
