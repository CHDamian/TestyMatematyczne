using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestyMatematyczne.Data.Migrations
{
    public partial class Contest_Up : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "Contest",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Published",
                table: "Contest");
        }
    }
}
