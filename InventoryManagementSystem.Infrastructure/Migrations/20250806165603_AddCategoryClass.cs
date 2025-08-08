using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "TbProducts");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TbProducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TbCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbProducts_CategoryId",
                table: "TbProducts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbProducts_TbCategories_CategoryId",
                table: "TbProducts",
                column: "CategoryId",
                principalTable: "TbCategories",
                principalColumn: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbProducts_TbCategories_CategoryId",
                table: "TbProducts");

            migrationBuilder.DropTable(
                name: "TbCategories");

            migrationBuilder.DropIndex(
                name: "IX_TbProducts_CategoryId",
                table: "TbProducts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TbProducts");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "TbProducts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
