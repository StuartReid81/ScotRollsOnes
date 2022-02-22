using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArmyBuilderSite.FortyKCrusadeModels
{
    public class CrusadeForce {
        [Key]
        public int Id { get; set; }

        public string ForceName { get; set; }

        public string Faction { get; set; }

        public string PlayerName { get; set; }

        public int BattlesPlayed { get; set; }

        public int BattlesWon { get; set; }

        public int RequisitionPoints { get; set; }

        public int SupplyLimit { get; set; }

        public int SupplyUsed { get; set; }

        public virtual List<CrusadeCard> Roster { get; set; }

        public string Notes { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual IdentityUser User { get; set; }
    }

    public class CrusadeCard {
        [Key]
        public int Id { get; set; }

        public string UnitName { get; set; }

        public int PowerRating { get; set; }

        public int CrusadePoints { get; set; }

        public Role BattleFieldRole { get; set; }

        public string Faction { get; set; }

        public string SelectableKeyword { get; set; }

        public int ExperiencePoints { get; set; }

        public string UnitType { get; set; }

        public string Equipment { get; set; }

        public string PsychicPowers { get; set; }

        public string WarlordTraits { get; set; }

        public string Relics { get; set; }

        public string Notes { get; set; }

        public int BattlesPlayed { get; set; }

        public int BattlesSurvived { get; set; }

        public int EnemyUnitsDestroyedThisBattle { get; set; }

        public int EnemyUnitsDestroyedTotal { get; set; }

        public int EnemyUnitsDestroyedWithPsychicPowersThisBattle { get; set; }

        public int EnemyUnitsDestroyedWithPsychicPowersInTotal { get; set; }

        public int EnemyUnitsDestroyedWithRangedWeaponsThisBattle { get; set; }

        public int EnemyUnitsDestroyedWithRangedWeaponsInTotal { get; set; }
        
        public int EnemyUnitsDestroyedWithMeleeWeaponsThisBattle { get; set; }

        public int EnemyUnitsDestroyedWithMeleeWeaponsInTotal { get; set; }

        public int AgendaTallyOne { get; set; }

        public int AgendaTallyTwo { get; set; }

        public int AgendaTallyThree { get; set; }

        public Rank Rank { get; set; }

        public string BattleHonours { get; set; }

        public string BattleScars { get; set; }

        public int ForceId { get; set; }

        [ForeignKey("ForceId")]
        public virtual CrusadeForce Force { get; set; }
    }

    public enum Role { HQ, Troop, FastAttack, Elite, HeavySupport, DedicatedTransport, LordOfWar }

    public enum Rank { Fresh, Blooded, BattleHardened, Heroic, Legendary }

    public static class EnumHelpers {
        public static string ToCleanString(this Role r) {
            switch (r)
            {
                case Role.FastAttack:
                    return "Fast Attack";
                case Role.HeavySupport:
                    return "Heavy Support";
                case Role.DedicatedTransport:
                    return "Dedicated Transport";
                case Role.LordOfWar:
                    return "Lord of War";
                default:
                    return r.ToString();
            }
        }

        public static string ToCleanString(this Rank r) {
            switch (r)
            {
                case Rank.BattleHardened:
                    return "Battle-Hardened";
                default:
                    return r.ToString();
            }
        }
    }
}
