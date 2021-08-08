using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArmyBuilderSite.Data.Migrations
{
    public partial class dragonRampant_softdelete_dateAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateAdded",
                table: "ArmyUnits",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateSoftDeleted",
                table: "ArmyUnits",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "IsSoftDeleted",
                table: "ArmyUnits",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateAdded",
                table: "Armies",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateSoftDeleted",
                table: "Armies",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "IsSoftDeleted",
                table: "Armies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LeaderName",
                table: "Armies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "ArmyUnits");

            migrationBuilder.DropColumn(
                name: "DateSoftDeleted",
                table: "ArmyUnits");

            migrationBuilder.DropColumn(
                name: "IsSoftDeleted",
                table: "ArmyUnits");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Armies");

            migrationBuilder.DropColumn(
                name: "DateSoftDeleted",
                table: "Armies");

            migrationBuilder.DropColumn(
                name: "IsSoftDeleted",
                table: "Armies");

            migrationBuilder.DropColumn(
                name: "LeaderName",
                table: "Armies");
        }
    }
}
