using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class summarytableadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SummaryId",
                table: "ProductCategory",
                type: "int",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "SummaryId",
                table: "Comments",
                type: "int",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "Summaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slider = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Summaries_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_SummaryId",
                table: "ProductCategory",
                column: "SummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SummaryId",
                table: "Comments",
                column: "SummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Summaries_CategoryId",
                table: "Summaries",
                column: "CategoryId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Summaries_SummaryId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Summaries_SummaryId",
                table: "ProductCategory");

            migrationBuilder.DropTable(
                name: "Summaries");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategory_SummaryId",
                table: "ProductCategory");

            migrationBuilder.DropIndex(
                name: "IX_Comments_SummaryId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "SummaryId",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "SummaryId",
                table: "Comments");
        }
    }
}
