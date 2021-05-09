using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArmyBuilderSite.Data.Migrations
{
    public partial class Identity_Scaffolded_BloodBowl_Initial_Push : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modifiers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attribute = table.Column<int>(nullable: false),
                    Positive = table.Column<bool>(nullable: false),
                    ModValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modifiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ReRollCost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Injuries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InjuryName = table.Column<string>(nullable: true),
                    Effect = table.Column<string>(nullable: true),
                    ModifierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Injuries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Injuries_Modifiers_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Modifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(nullable: true),
                    Effect = table.Column<string>(nullable: true),
                    ModifierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Modifiers_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Modifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BasePlayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceId = table.Column<int>(nullable: false),
                    PositionName = table.Column<string>(nullable: true),
                    Cost = table.Column<int>(nullable: false),
                    Movement = table.Column<int>(nullable: false),
                    ArmourValue = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Agility = table.Column<int>(nullable: false),
                    MaximumAllowed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasePlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasePlayers_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    TeamName = table.Column<string>(nullable: true),
                    RaceId = table.Column<int>(nullable: false),
                    Gold = table.Column<int>(nullable: false),
                    ManagerName = table.Column<string>(nullable: true),
                    Cheerleaders = table.Column<int>(nullable: false),
                    FanFactor = table.Column<int>(nullable: false),
                    ReRolls = table.Column<int>(nullable: false),
                    AssistantCoaches = table.Column<int>(nullable: false),
                    Apothecaries = table.Column<int>(nullable: false),
                    TotalGamesPlayed = table.Column<int>(nullable: false),
                    Wins = table.Column<int>(nullable: false),
                    Draws = table.Column<int>(nullable: false),
                    Losses = table.Column<int>(nullable: false),
                    TouchDowns = table.Column<int>(nullable: false),
                    CasualtiesInflicted = table.Column<int>(nullable: false),
                    League = table.Column<string>(nullable: true),
                    LeaguePoints = table.Column<int>(nullable: false),
                    IsSoftDeleted = table.Column<bool>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teams_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InjuryModifiers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InjuryId = table.Column<int>(nullable: false),
                    ModifierId = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InjuryModifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InjuryModifiers_Injuries_InjuryId",
                        column: x => x.InjuryId,
                        principalTable: "Injuries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InjuryModifiers_Modifiers_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Modifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(nullable: true),
                    BasePlayerId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsSoftDeleted = table.Column<bool>(nullable: false),
                    PlayerStatus = table.Column<string>(nullable: true),
                    DateHired = table.Column<DateTimeOffset>(nullable: false),
                    GamesPlayed = table.Column<int>(nullable: false),
                    TouchDowns = table.Column<int>(nullable: false),
                    InjuriesInflicted = table.Column<int>(nullable: false),
                    MissNextGame = table.Column<bool>(nullable: false),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_BasePlayers_BasePlayerId",
                        column: x => x.BasePlayerId,
                        principalTable: "BasePlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerInjuries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(nullable: false),
                    InjuryId = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerInjuries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerInjuries_Injuries_InjuryId",
                        column: x => x.InjuryId,
                        principalTable: "Injuries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerInjuries_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerModifiers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(nullable: false),
                    ModifierId = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerModifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerModifiers_Modifiers_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Modifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerModifiers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSkills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTimeOffset>(nullable: false),
                    RaceBasicPlayerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerSkills_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerSkills_BasePlayers_RaceBasicPlayerId",
                        column: x => x.RaceBasicPlayerId,
                        principalTable: "BasePlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillModifiers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillId = table.Column<int>(nullable: false),
                    ModifierId = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillModifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillModifiers_Modifiers_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Modifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillModifiers_PlayerSkills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "PlayerSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasePlayers_RaceId",
                table: "BasePlayers",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Injuries_ModifierId",
                table: "Injuries",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_InjuryModifiers_InjuryId",
                table: "InjuryModifiers",
                column: "InjuryId");

            migrationBuilder.CreateIndex(
                name: "IX_InjuryModifiers_ModifierId",
                table: "InjuryModifiers",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerInjuries_InjuryId",
                table: "PlayerInjuries",
                column: "InjuryId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerInjuries_PlayerId",
                table: "PlayerInjuries",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerModifiers_ModifierId",
                table: "PlayerModifiers",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerModifiers_PlayerId",
                table: "PlayerModifiers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_BasePlayerId",
                table: "Players",
                column: "BasePlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSkills_PlayerId",
                table: "PlayerSkills",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSkills_RaceBasicPlayerId",
                table: "PlayerSkills",
                column: "RaceBasicPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSkills_SkillId",
                table: "PlayerSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillModifiers_ModifierId",
                table: "SkillModifiers",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillModifiers_SkillId",
                table: "SkillModifiers",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ModifierId",
                table: "Skills",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_RaceId",
                table: "Teams",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_UserId",
                table: "Teams",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InjuryModifiers");

            migrationBuilder.DropTable(
                name: "PlayerInjuries");

            migrationBuilder.DropTable(
                name: "PlayerModifiers");

            migrationBuilder.DropTable(
                name: "SkillModifiers");

            migrationBuilder.DropTable(
                name: "Injuries");

            migrationBuilder.DropTable(
                name: "PlayerSkills");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "BasePlayers");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Modifiers");

            migrationBuilder.DropTable(
                name: "Races");
        }
    }
}
