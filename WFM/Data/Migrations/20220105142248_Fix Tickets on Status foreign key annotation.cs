using Microsoft.EntityFrameworkCore.Migrations;

namespace WFM.Data.Migrations
{
    public partial class FixTicketsonStatusforeignkeyannotation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Status_StatusId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_StatusId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Ticket");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_StatusRefId",
                table: "Ticket",
                column: "StatusRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Status_StatusRefId",
                table: "Ticket",
                column: "StatusRefId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Status_StatusRefId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_StatusRefId",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Ticket",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_StatusId",
                table: "Ticket",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Status_StatusId",
                table: "Ticket",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
