using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class productclassupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Features",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsHome",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Pattern",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Releasedon",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Features",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHome",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Pattern",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Releasedon",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
