using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.BookStore.Migrations
{
    /// <inheritdoc />
    public partial class Cap2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaptchaForUser_CaptchaImages_CaptchaImageId",
                table: "CaptchaForUser");

            migrationBuilder.DropColumn(
                name: "CaptchaId",
                table: "CaptchaForUser");

            migrationBuilder.AddForeignKey(
                name: "FK_CaptchaForUser_CaptchaImages_CaptchaImageId",
                table: "CaptchaForUser",
                column: "CaptchaImageId",
                principalTable: "CaptchaImages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaptchaForUser_CaptchaImages_CaptchaImageId",
                table: "CaptchaForUser");

            migrationBuilder.AddColumn<Guid>(
                name: "CaptchaId",
                table: "CaptchaForUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_CaptchaForUser_CaptchaImages_CaptchaImageId",
                table: "CaptchaForUser",
                column: "CaptchaImageId",
                principalTable: "CaptchaImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
