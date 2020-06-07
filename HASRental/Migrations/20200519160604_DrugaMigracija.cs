using Microsoft.EntityFrameworkCore.Migrations;

namespace HASRental.Migrations
{
    public partial class DrugaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Uloga",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uloga",
                table: "AspNetUsers");
        }
    }
}
