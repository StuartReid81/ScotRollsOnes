using Microsoft.EntityFrameworkCore.Migrations;

namespace ArmyBuilderSite.Data.Migrations
{
    public partial class added_PA_to_Base_players_and_denormalised_stats_for_players : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Agility",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArmourValue",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Movement",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PassingAbility",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Strength",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PassingAbility",
                table: "BasePlayers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agility",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ArmourValue",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Movement",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PassingAbility",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Strength",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PassingAbility",
                table: "BasePlayers");
        }
    }
}
