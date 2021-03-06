using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArmyBuilderSite.Data.Migrations
{
    public partial class Added_Date_Deleted_To_Teams_Players : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateSoftDeleted",
                table: "Teams",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateSoftDeleted",
                table: "Players",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateSoftDeleted",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "DateSoftDeleted",
                table: "Players");
        }
    }
}
