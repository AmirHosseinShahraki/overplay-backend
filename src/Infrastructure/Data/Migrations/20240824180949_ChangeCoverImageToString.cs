using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCoverImageToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_CoverImageFile_CoverImageId",
                table: "Songs");

            migrationBuilder.DropTable(
                name: "CoverImageFile");

            migrationBuilder.DropIndex(
                name: "IX_Songs_CoverImageId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "CoverImageId",
                table: "Songs");

            migrationBuilder.AddColumn<string>(
                name: "CoverImageUrl",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImageUrl",
                table: "Songs");

            migrationBuilder.AddColumn<Guid>(
                name: "CoverImageId",
                table: "Songs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CoverImageFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverImageFile", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_CoverImageId",
                table: "Songs",
                column: "CoverImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_CoverImageFile_CoverImageId",
                table: "Songs",
                column: "CoverImageId",
                principalTable: "CoverImageFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
