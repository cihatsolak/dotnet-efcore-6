using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCore.CodeFirst.V2.Migrations
{
    /// <inheritdoc />
    public partial class VehicleChangeDeleteBehaviourRule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Brand_BrandId",
                table: "Vehicle");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Brand_BrandId",
                table: "Vehicle",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Brand_BrandId",
                table: "Vehicle");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Brand_BrandId",
                table: "Vehicle",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
