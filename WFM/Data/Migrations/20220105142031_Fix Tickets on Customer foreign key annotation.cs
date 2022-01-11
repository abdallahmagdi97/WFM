using Microsoft.EntityFrameworkCore.Migrations;

namespace WFM.Data.Migrations
{
    public partial class FixTicketsonCustomerforeignkeyannotation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Customer_CustomerId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_CustomerId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Ticket");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CustomerRefId",
                table: "Ticket",
                column: "CustomerRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Customer_CustomerRefId",
                table: "Ticket",
                column: "CustomerRefId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Customer_CustomerRefId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_CustomerRefId",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Ticket",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CustomerId",
                table: "Ticket",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Customer_CustomerId",
                table: "Ticket",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
