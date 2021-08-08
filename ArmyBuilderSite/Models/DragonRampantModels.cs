using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyBuilderSite.DragonRampantModels
{
    public class Army {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string LeaderName { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual IdentityUser User { get; set; }

        public virtual ICollection<ArmyUnit> Units { get; set; }

        public int Points { get; set; }

        public bool IsSoftDeleted { get; set; }

        public bool IsPublic { get; set; }

        public DateTimeOffset DateAdded { get; set; }

        public DateTimeOffset DateSoftDeleted { get; set; }
    }

    public class ArmyUnit {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public int ArmyId { get; set; }

        [ForeignKey("ArmyId")]
        public virtual Army Army { get; set; }

        public string Name { get; set; }

        public int Points { get; set; }

        public UnitType Type { get; set; }

        public int FigureCount { get; set; }

        public bool IsSingleFigure { get; set; }

        public bool IsReducedModelUnit { get; set; }

        public bool IsLeader { get; set; }

        public IList<ChosenUnitOption> ChosenUnitOptions { get; set; }

        public string Notes { get; set; }

        public bool IsSoftDeleted { get; set; }

        public DateTimeOffset DateAdded { get; set; }

        public DateTimeOffset DateSoftDeleted { get; set; }
    }

    public class UnitType {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int BasePoints { get; set; }

        /* Unit Stats */
        public int AttackOrder { get; set; }
        public int MoveOrder { get; set; }
        public int ShootOrder { get; set; }
        public int Courage { get; set; }
        public int Armour { get; set; }
        public int AttackValue { get; set; }
        public int ShootValue { get; set; }
        public int DefenceValue { get; set; }
        public int MaximumMove { get; set; }
        public int StrengthPoints { get; set; }

        public IList<DRSpecialRule> SpecialRules { get; set; }

        public IList<AvailableUnitOption> AvailableUnitOptions { get; set; }
    }

    public class DRSpecialRule {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class ChosenUnitOption {
        [Key]
        public int Id { get; set; }
        public int ArmyUnitId { get; set; }

        [ForeignKey("ArmyUnitId")]
        public virtual ArmyUnit Unit { get; set; }
        public int OptionId { get; set; }

        [ForeignKey("OptionId")]
        public virtual UnitOption Option { get; set; }
    }

    public class UnitOption {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Rule { get; set; }
    }

    public class AvailableUnitOption
    {
        [Key]
        public int Id { get; set; }
        public int UnitTypeId { get; set; }

        [ForeignKey("UnitTypeId")]
        public virtual UnitType Unit { get; set; }

        public int OptionId { get; set; }

        [ForeignKey("OptionId")]
        public virtual UnitOption Option { get; set; }
    }

}
