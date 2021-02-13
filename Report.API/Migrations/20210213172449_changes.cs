using Microsoft.EntityFrameworkCore.Migrations;

namespace Report.API.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Reports",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "addDate",
                table: "Reports",
                newName: "AddDate");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Reports",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "Reports",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "AddDate",
                table: "Reports",
                newName: "addDate");
        }
    }
}
