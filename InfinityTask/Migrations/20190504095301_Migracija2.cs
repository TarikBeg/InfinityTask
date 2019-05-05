using Microsoft.EntityFrameworkCore.Migrations;

namespace InfinityTask.Migrations
{
    public partial class Migracija2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Blog",
                newName: "Summary");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Blog",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Blog");

            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "Blog",
                newName: "Text");
        }
    }
}
