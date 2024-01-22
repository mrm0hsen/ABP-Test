using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.BookStore.Migrations
{
    /// <inheritdoc />
    public partial class Cap3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaptchaForUser_CaptchaImages_CaptchaImageId",
                table: "CaptchaForUser");

            migrationBuilder.DropTable(
                name: "CaptchaImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaptchaForUser",
                table: "CaptchaForUser");

            migrationBuilder.DropIndex(
                name: "IX_CaptchaForUser_CaptchaImageId",
                table: "CaptchaForUser");

            migrationBuilder.DropColumn(
                name: "CaptchaImageId",
                table: "CaptchaForUser");

            migrationBuilder.RenameTable(
                name: "CaptchaForUser",
                newName: "CaptchaForUsers");

            migrationBuilder.RenameColumn(
                name: "IP",
                table: "CaptchaForUsers",
                newName: "Answer");

            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "CaptchaForUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaptchaForUsers",
                table: "CaptchaForUsers",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CaptchaForUsers",
                table: "CaptchaForUsers");

            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "CaptchaForUsers");

            migrationBuilder.RenameTable(
                name: "CaptchaForUsers",
                newName: "CaptchaForUser");

            migrationBuilder.RenameColumn(
                name: "Answer",
                table: "CaptchaForUser",
                newName: "IP");

            migrationBuilder.AddColumn<Guid>(
                name: "CaptchaImageId",
                table: "CaptchaForUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaptchaForUser",
                table: "CaptchaForUser",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CaptchaImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaptchaImages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaptchaForUser_CaptchaImageId",
                table: "CaptchaForUser",
                column: "CaptchaImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaptchaForUser_CaptchaImages_CaptchaImageId",
                table: "CaptchaForUser",
                column: "CaptchaImageId",
                principalTable: "CaptchaImages",
                principalColumn: "Id");
        }
    }
}
