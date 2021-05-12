using Microsoft.EntityFrameworkCore.Migrations;

namespace ArmyBuilderSite.Data.Migrations
{
    public partial class added_new_fields_to_team_and_special_rules_base_skills_and_skill_groupings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerSkills_BasePlayers_RaceBasicPlayerId",
                table: "PlayerSkills");

            migrationBuilder.DropIndex(
                name: "IX_PlayerSkills_RaceBasicPlayerId",
                table: "PlayerSkills");

            migrationBuilder.DropColumn(
                name: "RaceBasicPlayerId",
                table: "PlayerSkills");

            migrationBuilder.AddColumn<int>(
                name: "SkillGroup",
                table: "Skills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ApothecaryAllowed",
                table: "Races",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Tier",
                table: "Races",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BasePlayerSkills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasePlayerId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasePlayerSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasePlayerSkills_BasePlayers_BasePlayerId",
                        column: x => x.BasePlayerId,
                        principalTable: "BasePlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasePlayerSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSkillGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasePlayerId = table.Column<int>(nullable: false),
                    SkillGroup = table.Column<int>(nullable: false),
                    Primary = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSkillGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerSkillGroups_BasePlayers_BasePlayerId",
                        column: x => x.BasePlayerId,
                        principalTable: "BasePlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialRules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamSpecialRule = table.Column<bool>(nullable: false),
                    RuleName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaceSpecialRules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceId = table.Column<int>(nullable: false),
                    SpecialRuleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceSpecialRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceSpecialRules_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceSpecialRules_SpecialRules_SpecialRuleId",
                        column: x => x.SpecialRuleId,
                        principalTable: "SpecialRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasePlayerSkills_BasePlayerId",
                table: "BasePlayerSkills",
                column: "BasePlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_BasePlayerSkills_SkillId",
                table: "BasePlayerSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSkillGroups_BasePlayerId",
                table: "PlayerSkillGroups",
                column: "BasePlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceSpecialRules_RaceId",
                table: "RaceSpecialRules",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceSpecialRules_SpecialRuleId",
                table: "RaceSpecialRules",
                column: "SpecialRuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasePlayerSkills");

            migrationBuilder.DropTable(
                name: "PlayerSkillGroups");

            migrationBuilder.DropTable(
                name: "RaceSpecialRules");

            migrationBuilder.DropTable(
                name: "SpecialRules");

            migrationBuilder.DropColumn(
                name: "SkillGroup",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "ApothecaryAllowed",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "Tier",
                table: "Races");

            migrationBuilder.AddColumn<int>(
                name: "RaceBasicPlayerId",
                table: "PlayerSkills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSkills_RaceBasicPlayerId",
                table: "PlayerSkills",
                column: "RaceBasicPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerSkills_BasePlayers_RaceBasicPlayerId",
                table: "PlayerSkills",
                column: "RaceBasicPlayerId",
                principalTable: "BasePlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
