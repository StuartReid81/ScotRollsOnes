using Microsoft.EntityFrameworkCore.Migrations;

namespace ArmyBuilderSite.Data.Migrations
{
    public partial class added_crusade_classes_to_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrusadeForces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForceName = table.Column<string>(nullable: true),
                    Faction = table.Column<string>(nullable: true),
                    PlayerName = table.Column<string>(nullable: true),
                    BattlesPlayed = table.Column<int>(nullable: false),
                    BattlesWon = table.Column<int>(nullable: false),
                    RequisitionPoints = table.Column<int>(nullable: false),
                    SupplyLimit = table.Column<int>(nullable: false),
                    SupplyUsed = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrusadeForces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrusadeForces_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CrusadeCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(nullable: true),
                    PowerRating = table.Column<int>(nullable: false),
                    CrusadePoints = table.Column<int>(nullable: false),
                    BattleFieldRole = table.Column<int>(nullable: false),
                    Faction = table.Column<string>(nullable: true),
                    SelectableKeyword = table.Column<string>(nullable: true),
                    ExperiencePoints = table.Column<int>(nullable: false),
                    UnitType = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    PsychicPowers = table.Column<string>(nullable: true),
                    WarlordTraits = table.Column<string>(nullable: true),
                    Relics = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    BattlesPlayed = table.Column<int>(nullable: false),
                    BattlesSurvived = table.Column<int>(nullable: false),
                    EnemyUnitsDestroyedThisBattle = table.Column<int>(nullable: false),
                    EnemyUnitsDestroyedTotal = table.Column<int>(nullable: false),
                    EnemyUnitsDestroyedWithPsychicPowersThisBattle = table.Column<int>(nullable: false),
                    EnemyUnitsDestroyedWithPsychicPowersInTotal = table.Column<int>(nullable: false),
                    EnemyUnitsDestroyedWithRangedWeaponsThisBattle = table.Column<int>(nullable: false),
                    EnemyUnitsDestroyedWithRangedWeaponsInTotal = table.Column<int>(nullable: false),
                    EnemyUnitsDestroyedWithMeleeWeaponsThisBattle = table.Column<int>(nullable: false),
                    EnemyUnitsDestroyedWithMeleeWeaponsInTotal = table.Column<int>(nullable: false),
                    AgendaTallyOne = table.Column<int>(nullable: false),
                    AgendaTallyTwo = table.Column<int>(nullable: false),
                    AgendaTallyThree = table.Column<int>(nullable: false),
                    Rank = table.Column<int>(nullable: false),
                    BattleHonours = table.Column<string>(nullable: true),
                    BattleScars = table.Column<string>(nullable: true),
                    ForceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrusadeCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrusadeCards_CrusadeForces_ForceId",
                        column: x => x.ForceId,
                        principalTable: "CrusadeForces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrusadeCards_ForceId",
                table: "CrusadeCards",
                column: "ForceId");

            migrationBuilder.CreateIndex(
                name: "IX_CrusadeForces_UserId",
                table: "CrusadeForces",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrusadeCards");

            migrationBuilder.DropTable(
                name: "CrusadeForces");
        }
    }
}
