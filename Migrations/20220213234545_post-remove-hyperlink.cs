using Microsoft.EntityFrameworkCore.Migrations;

namespace MemAthleteServer.Migrations
{
    public partial class postremovehyperlink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hyperlink",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hyperlink",
                table: "Posts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
