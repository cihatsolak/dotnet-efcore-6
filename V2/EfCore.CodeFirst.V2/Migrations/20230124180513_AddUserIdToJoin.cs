using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCore.CodeFirst.V2.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToJoin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Gallery",
                type: "varchar",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Gallery",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Gallery");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Gallery");
        }
    }
}
