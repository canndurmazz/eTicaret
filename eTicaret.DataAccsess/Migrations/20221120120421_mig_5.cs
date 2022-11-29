using Microsoft.EntityFrameworkCore.Migrations;

namespace eTicaret.DataAccsess.Migrations
{
    public partial class mig_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyCount",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "Earning",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "ProductCount",
                table: "Sites");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyCount",
                table: "Sites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Earning",
                table: "Sites",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ProductCount",
                table: "Sites",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
