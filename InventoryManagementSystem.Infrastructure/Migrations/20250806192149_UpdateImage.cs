using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "TbProducts");

            migrationBuilder.RenameColumn(
                name: "ImageContentType",
                table: "TbProducts",
                newName: "ImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "TbProducts",
                newName: "ImageContentType");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "TbProducts",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
