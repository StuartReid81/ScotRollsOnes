using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyBuilderSite.BloodBowlModels
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual IdentityUser User { get; set; }

        /// <summary>
        /// Denormalised user name
        /// </summary>
        public string UserName { get; set; }

        public string TeamName { get; set; }

        public int RaceId { get; set; }

        [ForeignKey("RaceId")]
        public virtual Race Race { get; set; }

        public int Gold { get; set; }

        public string ManagerName { get; set; }

        public virtual List<Player> TeamRoster { get; set; }

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
    public class Race
    {
        [Key]
        public int Id { get; set; }

        public string RaceName { get; set; }

        public string Description { get; set; }

        public int ReRollCost { get; set; }

        public virtual List<RaceBasicPlayer> BasePlayers { get; set; }

        public TeamTier Tier { get; set; }

        public bool ApothecaryAllowed { get; set; }

        public virtual List<RaceSpecialRule> SpecialRules { get; set; }

    }
    public class RaceBasicPlayer
    {
        [Key]
        public int Id { get; set; }

        public int RaceId { get; set; }

        [ForeignKey("RaceId")]
        public virtual Race Race { get; set; }

        public string PositionName { get; set; }

        public int Cost { get; set; }

        public int Movement { get; set; }

        public int ArmourValue { get; set; }

        public int Strength { get; set; }

        public int Agility { get; set; }

        public virtual List<StartingPlayerSkill> StartingSkills { get; set; }

        public int MaximumAllowed { get; set; }

    }
    public class Player
    {
        [Key]
        public int Id { get; set; }

        public string PlayerName { get; set; }

        public int BasePlayerId { get; set; }

        [ForeignKey("BasePlayerId")]
        public virtual RaceBasicPlayer BasePlayer { get; set; }

        public bool IsActive { get; set; }

        public bool IsSoftDeleted { get; set; }

        public DateTimeOffset DateSoftDeleted { get; set; }

        public string PlayerStatus { get; set; }

        public DateTimeOffset DateHired { get; set; }

        public int GamesPlayed { get; set; }

        public int TouchDowns { get; set; }

        public int InjuriesInflicted { get; set; }

        public bool MissNextGame { get; set; }

        public virtual List<PlayerSkill> Skills { get; set; }
        public virtual List<PlayerInjury> Injuries { get; set; }
        public virtual List<PlayerModifier> Modifiers { get; set; }
    }

    #region many to many tables
    public class PlayerSkill {
        [Key]
        public int Id { get; set; }

        public int PlayerId { get; set; }

        [ForeignKey("PlayerId")]
        public virtual Player Player { get; set; }

        public int SkillId { get; set; }

        [ForeignKey("SkillId")]
        public virtual Skill Skill { get; set; }

        public DateTimeOffset DateAdded { get; set; }
    }

    public class StartingPlayerSkill
    {
        [Key]
        public int Id { get; set; }

        public int BasePlayerId { get; set; }

        [ForeignKey("BasePlayerId")]
        public virtual RaceBasicPlayer Player { get; set; }

        public int SkillId { get; set; }

        [ForeignKey("SkillId")]
        public virtual Skill Skill { get; set; }
    }

    public class PlayerSkillGroups {
        [Key]
        public int Id { get; set; }

        public int BasePlayerId { get; set; }

        [ForeignKey("BasePlayerId")]
        public RaceBasicPlayer Player { get; set; }

        public SkillGroup SkillGroup { get; set; }

        public bool Primary { get; set; }
    }

    public class PlayerInjury
    {
        [Key]
        public int Id { get; set; }

        public int PlayerId { get; set; }

        [ForeignKey("PlayerId")]
        public virtual Player Player { get; set; }

        public int InjuryId { get; set; }

        [ForeignKey("InjuryId")]
        public virtual Injury Injury { get; set; }

        public DateTimeOffset DateAdded { get; set; }
    } 

    public class PlayerModifier
    {
        [Key]
        public int Id { get; set; }

        public int PlayerId { get; set; }

        [ForeignKey("PlayerId")]
        public virtual Player Player { get; set; }

        public int ModifierId { get; set; }

        [ForeignKey("ModifierId")]
        public virtual Modifier Modifier { get; set; }

        public DateTimeOffset DateAdded { get; set; }
    }

    public class RaceSpecialRule { 
        [Key]
        public int Id { get; set; }

        public int RaceId { get; set; }

        [ForeignKey("RaceId")]
        public virtual Race Race { get; set; }

        public int SpecialRuleId { get; set; }

        [ForeignKey("SpecialRuleId")]
        public SpecialRule SpecialRule { get; set; }
    }

    #endregion

    //skill and stat mofdifier table
    public class Skill
    {
        [Key]
        public int Id { get; set; }

        public string SkillName { get; set; }

        public string Effect { get; set; }

        public SkillGroup SkillGroup { get; set; }

        public Modifier Modifier { get; set; }
    }

    public class SkillModifier
    {
        [Key]
        public int Id { get; set; }

        public int SkillId { get; set; }

        [ForeignKey("SkillId")]
        public virtual PlayerSkill Skill { get; set; }

        public int ModifierId { get; set; }

        [ForeignKey("ModifierId")]
        public virtual Modifier Modifier { get; set; }

        public DateTimeOffset DateAdded { get; set; }
    }

    //injuries and modifier table
    public class Injury {
        [Key]
        public int Id { get; set; }

        public string InjuryName { get; set; }

        public string Effect { get; set; }

        public Modifier Modifier { get; set; }
    }

    public class InjuryModifier
    {
        [Key]
        public int Id { get; set; }

        public int InjuryId { get; set; }

        [ForeignKey("InjuryId")]
        public virtual Injury Injury { get; set; }

        public int ModifierId { get; set; }

        [ForeignKey("ModifierId")]
        public virtual Modifier Modifier { get; set; }

        public DateTimeOffset DateAdded { get; set; }
    }

    public class SpecialRule
    {
        [Key]
        public int Id { get; set; }

        public bool TeamSpecialRule { get; set; }

        public string RuleName { get; set; }

        public string Description { get; set; }
    }

    //stat management
    public class Modifier {
        [Key]
        public int Id { get; set; }

        public Attribute Attribute { get; set; }

        public bool Positive { get; set; }

        public int ModValue { get; set; }
    }

    /// <summary>
    /// Enum for player attributes
    /// </summary>
    public enum Attribute { Move, Strength, Armour_Value, Agility, ReRolls, Injury_Roll }

    /// <summary>
    /// Grouping for skills in to type
    /// </summary>
    public enum SkillGroup { General, Agility, Mutations, Passing, Strength, Trait }
    
    /// <summary>
    /// Team difficulty value
    /// </summary>
    public enum TeamTier { One, Two, Three }


}
