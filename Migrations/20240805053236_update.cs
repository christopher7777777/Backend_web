using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wandermate.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Hotel_HotelId",
                table: "Review");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Hotel_HotelId",
                table: "Review",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Hotel_HotelId",
                table: "Review");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Hotel_HotelId",
                table: "Review",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
