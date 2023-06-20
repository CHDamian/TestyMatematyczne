using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestyMatematyczne.Data.Migrations
{
    public partial class SolutionsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Solution",
                columns: table => new
                {
                    ContestId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SolutionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Answers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solution", x => new { x.ContestId, x.UserId, x.SolutionTime });
                    table.ForeignKey(
                        name: "FK_Solution_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Solution_Contest_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solution_UserId",
                table: "Solution",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solution");
        }
    }
}
