using Microsoft.EntityFrameworkCore.Migrations;

namespace EduxV4.Repo.Migrations
{
    public partial class addBirthPlace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoureId",
                table: "Announcements");

            migrationBuilder.AddColumn<string>(
                name: "BirthPlace",
                table: "Contacts",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthPlace",
                table: "Contacts");

            migrationBuilder.AddColumn<string>(
                name: "CoureId",
                table: "Announcements",
                nullable: true);
        }
    }
}
