using Microsoft.EntityFrameworkCore.Migrations;

namespace eTicaret.DataAccsess.Migrations
{
    public partial class mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "SitesEarning",
                table: "Shoppings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SitesEarning",
                table: "Shoppings");
        }
    }
}
