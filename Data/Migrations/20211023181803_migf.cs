using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class migf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactParagraf",
                table: "General",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceParagraf",
                table: "General",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactParagraf",
                table: "General");

            migrationBuilder.DropColumn(
                name: "ServiceParagraf",
                table: "General");
        }
    }
}
