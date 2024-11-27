using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cezo.API.Migrations
{
    /// <inheritdoc />
    public partial class NewPublicId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
    name: "ImgUrl",
    table: "Artists",
    nullable: true, // Allowing NULL values
    oldClrType: typeof(string),
    oldType: "nvarchar(max)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Artists");
        }
    }
}
