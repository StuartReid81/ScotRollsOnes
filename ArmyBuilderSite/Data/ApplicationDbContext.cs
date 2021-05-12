using ArmyBuilderSite.BloodBowlModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyBuilderSite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceBasicPlayer> BasePlayers { get; set; }
        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerSkill> PlayerSkills { get; set; }
        public DbSet<StartingPlayerSkill> BasePlayerSkills { get; set; }
        public DbSet<PlayerSkillGroups> PlayerSkillGroups { get; set; }
        public DbSet<PlayerInjury> PlayerInjuries { get; set; }
        public DbSet<PlayerModifier> PlayerModifiers { get; set; }
        public DbSet<RaceSpecialRule> RaceSpecialRules { get; set; }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillModifier> SkillModifiers { get; set; }
        public DbSet<Injury> Injuries { get; set; }
        public DbSet<InjuryModifier> InjuryModifiers { get; set; }
        public DbSet<SpecialRule> SpecialRules { get; set; }

        public DbSet<Modifier> Modifiers { get; set; }






    }
}
