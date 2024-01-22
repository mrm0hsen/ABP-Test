using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.BookStore.Migrations
{
    /// <inheritdoc />
    public partial class Captcha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaptchaImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaptchaImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaptchaForUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaptchaImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaptchaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaptchaForUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaptchaForUser_CaptchaImages_CaptchaImageId",
                        column: x => x.CaptchaImageId,
                        principalTable: "CaptchaImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaptchaForUser_CaptchaImageId",
                table: "CaptchaForUser",
                column: "CaptchaImageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaptchaForUser");

            migrationBuilder.DropTable(
                name: "CaptchaImages");
        }
    }
}
