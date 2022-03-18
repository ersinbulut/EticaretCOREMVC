using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class summarytableupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Summaries_SummaryId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Summaries_SummaryId",
                table: "ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Summaries_Categories_CategoryId",
                table: "Summaries");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategory_SummaryId",
                table: "ProductCategory");

            migrationBuilder.DropIndex(
                name: "IX_Comments_SummaryId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Summaries");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Summaries");

            migrationBuilder.DropColumn(
                name: "Image1",
                table: "Summaries");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "Summaries");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "Summaries");

            migrationBuilder.DropColumn(
                name: "Slider",
                table: "Summaries");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Summaries");

            migrationBuilder.DropColumn(
                name: "SummaryId",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "SummaryId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Summaries",
                newName: "musteriID");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Summaries",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Summaries_CategoryId",
                table: "Summaries",
                newName: "IX_Summaries_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Summaries_Products_ProductId",
                table: "Summaries",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Summaries_Products_ProductId",
                table: "Summaries");

            migrationBuilder.RenameColumn(
                name: "musteriID",
                table: "Summaries",
                newName: "ParentId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Summaries",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Summaries_ProductId",
                table: "Summaries",
                newName: "IX_Summaries_CategoryId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Summaries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Summaries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image1",
                table: "Summaries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "Summaries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "Summaries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Slider",
                table: "Summaries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Summaries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SummaryId",
                table: "ProductCategory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SummaryId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_SummaryId",
                table: "ProductCategory",
                column: "SummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SummaryId",
                table: "Comments",
                column: "SummaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Summaries_SummaryId",
                table: "Comments",
                column: "SummaryId",
                principalTable: "Summaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Summaries_SummaryId",
                table: "ProductCategory",
                column: "SummaryId",
                principalTable: "Summaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Summaries_Categories_CategoryId",
                table: "Summaries",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
