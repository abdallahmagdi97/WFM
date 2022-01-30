using Microsoft.EntityFrameworkCore.Migrations;

namespace WFM.Data.Migrations
{
    public partial class addingcustomerMeterstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meter_Customer_CustomerId",
                table: "Meter");

            migrationBuilder.DropIndex(
                name: "IX_Meter_CustomerId",
                table: "Meter");

            migrationBuilder.DropColumn(
                name: "TicketSkillsRefId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "TechAreasRefId",
                table: "Tech");

            migrationBuilder.DropColumn(
                name: "TechSkillsRefId",
                table: "Tech");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Meter");

            migrationBuilder.CreateTable(
                name: "CustomerMeters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerRefId = table.Column<int>(nullable: false),
                    MeterRefId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMeters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketSkills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillRefId = table.Column<int>(nullable: false),
                    TicketRefId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketSkills", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerMeters");

            migrationBuilder.DropTable(
                name: "TicketSkills");

            migrationBuilder.AddColumn<int>(
                name: "TicketSkillsRefId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TechAreasRefId",
                table: "Tech",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TechSkillsRefId",
                table: "Tech",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Meter",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meter_CustomerId",
                table: "Meter",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meter_Customer_CustomerId",
                table: "Meter",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
