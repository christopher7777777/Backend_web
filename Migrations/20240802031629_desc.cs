using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Wandermate.Migrations
{
    /// <inheritdoc />
    public partial class desc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FreeCancellation",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Hotel");

            migrationBuilder.RenameColumn(
                name: "ReserveNow",
                table: "Hotel",
                newName: "IsDeleted");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Hotel",
                type: "text",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Hotel",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Hotel",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_HotelId",
                table: "Review",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Hotel");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Hotel",
                newName: "ReserveNow");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Hotel",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<bool>(
                name: "FreeCancellation",
                table: "Hotel",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<List<string>>(
                name: "Image",
                table: "Hotel",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<bool>(
                name: "Rating",
                table: "Hotel",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
