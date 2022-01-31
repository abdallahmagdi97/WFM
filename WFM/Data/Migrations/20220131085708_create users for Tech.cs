using Microsoft.EntityFrameworkCore.Migrations;

namespace WFM.Data.Migrations
{
    public partial class createusersforTech : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Tech",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Tech",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Tech");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Tech");
        }
    }
}
