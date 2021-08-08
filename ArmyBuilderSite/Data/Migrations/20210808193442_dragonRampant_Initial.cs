using Microsoft.EntityFrameworkCore.Migrations;

namespace ArmyBuilderSite.Data.Migrations
{
    public partial class dragonRampant_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Points = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Armies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnitOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Cost = table.Column<int>(nullable: false),
                    Rule = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BasePoints = table.Column<int>(nullable: false),
                    AttackOrder = table.Column<int>(nullable: false),
                    MoveOrder = table.Column<int>(nullable: false),
                    ShootOrder = table.Column<int>(nullable: false),
                    Courage = table.Column<int>(nullable: false),
                    Armour = table.Column<int>(nullable: false),
                    AttackValue = table.Column<int>(nullable: false),
                    ShootValue = table.Column<int>(nullable: false),
                    DefenceValue = table.Column<int>(nullable: false),
                    MaximumMove = table.Column<int>(nullable: false),
                    StrengthPoints = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArmyUnits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ArmyId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Points = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: true),
                    FigureCount = table.Column<int>(nullable: false),
                    IsSingleFigure = table.Column<bool>(nullable: false),
                    IsReducedModelUnit = table.Column<bool>(nullable: false),
                    IsLeader = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmyUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArmyUnits_Armies_ArmyId",
                        column: x => x.ArmyId,
                        principalTable: "Armies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmyUnits_UnitTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "UnitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AvailabeUnitOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitTypeId = table.Column<int>(nullable: false),
                    OptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailabeUnitOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailabeUnitOptions_UnitOptions_OptionId",
                        column: x => x.OptionId,
                        principalTable: "UnitOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailabeUnitOptions_UnitTypes_UnitTypeId",
                        column: x => x.UnitTypeId,
                        principalTable: "UnitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DRSpecialRules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UnitTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DRSpecialRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DRSpecialRules_UnitTypes_UnitTypeId",
                        column: x => x.UnitTypeId,
                        principalTable: "UnitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChosenUnitOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmyUnitId = table.Column<int>(nullable: false),
                    OptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChosenUnitOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChosenUnitOptions_ArmyUnits_ArmyUnitId",
                        column: x => x.ArmyUnitId,
                        principalTable: "ArmyUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChosenUnitOptions_UnitOptions_OptionId",
                        column: x => x.OptionId,
                        principalTable: "UnitOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Armies_UserId",
                table: "Armies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmyUnits_ArmyId",
                table: "ArmyUnits",
                column: "ArmyId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmyUnits_TypeId",
                table: "ArmyUnits",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailabeUnitOptions_OptionId",
                table: "AvailabeUnitOptions",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailabeUnitOptions_UnitTypeId",
                table: "AvailabeUnitOptions",
                column: "UnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChosenUnitOptions_ArmyUnitId",
                table: "ChosenUnitOptions",
                column: "ArmyUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ChosenUnitOptions_OptionId",
                table: "ChosenUnitOptions",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_DRSpecialRules_UnitTypeId",
                table: "DRSpecialRules",
                column: "UnitTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailabeUnitOptions");

            migrationBuilder.DropTable(
                name: "ChosenUnitOptions");

            migrationBuilder.DropTable(
                name: "DRSpecialRules");

            migrationBuilder.DropTable(
                name: "ArmyUnits");

            migrationBuilder.DropTable(
                name: "UnitOptions");

            migrationBuilder.DropTable(
                name: "Armies");

            migrationBuilder.DropTable(
                name: "UnitTypes");
        }
    }
}
