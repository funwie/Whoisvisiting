using Microsoft.EntityFrameworkCore.Migrations;

namespace Whoisvisiting.UI.Web.Migrations
{
    public partial class AddEnrichmentColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Industry",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Contacts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Industry",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Contacts");
        }
    }
}
