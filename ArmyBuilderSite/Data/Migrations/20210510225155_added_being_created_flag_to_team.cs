using Microsoft.EntityFrameworkCore.Migrations;

namespace ArmyBuilderSite.Data.Migrations
{
    public partial class added_being_created_flag_to_team : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BeingCreated",
                table: "Teams",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeingCreated",
                table: "Teams");
        }
    }
}
