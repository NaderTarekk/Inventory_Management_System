using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateProductAddingImageData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "TbProducts");

            migrationBuilder.AddColumn<string>(
                name: "ImageContentType",
                table: "TbProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "TbProducts",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageContentType",
                table: "TbProducts");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "TbProducts");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "TbProducts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
