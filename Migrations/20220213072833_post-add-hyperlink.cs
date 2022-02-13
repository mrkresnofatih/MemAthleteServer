using Microsoft.EntityFrameworkCore.Migrations;

namespace MemAthleteServer.Migrations
{
    public partial class postaddhyperlink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hyperlink",
                table: "Posts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hyperlink",
                table: "Posts");
        }
    }
}
