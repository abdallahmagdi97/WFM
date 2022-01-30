using Microsoft.EntityFrameworkCore.Migrations;

namespace WFM.Data.Migrations
{
    public partial class fixforiegnkeysinallModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Area_Tech_TechId",
                table: "Area");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignTicketRequest_Tech_TechRefId",
                table: "AssignTicketRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignTicketRequest_Ticket_TicketRefId",
                table: "AssignTicketRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_Meter_Customer_CustomerRefId",
                table: "Meter");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Tech_TechId",
                table: "Skill");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Ticket_TicketId",
                table: "Skill");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Address_AddressRefId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Area_AreaRefId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Customer_CustomerRefId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Meter_MeterRefId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Status_StatusRefId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Tech_TechRefId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_AddressRefId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_AreaRefId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_CustomerRefId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_MeterRefId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_StatusRefId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_TechRefId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Skill_TechId",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_Skill_TicketId",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_Meter_CustomerRefId",
                table: "Meter");

            migrationBuilder.DropIndex(
                name: "IX_AssignTicketRequest_TechRefId",
                table: "AssignTicketRequest");

            migrationBuilder.DropIndex(
                name: "IX_AssignTicketRequest_TicketRefId",
                table: "AssignTicketRequest");

            migrationBuilder.DropIndex(
                name: "IX_Area_TechId",
                table: "Area");

            migrationBuilder.DropColumn(
                name: "TechId",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "TechId",
                table: "Area");

            migrationBuilder.AddColumn<int>(
                name: "TicketSkillsRefId",
                table: "Ticket",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TechAreasRefId",
                table: "Tech",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TechSkillsRefId",
                table: "Tech",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Meter",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "TechId",
                table: "Skill",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Skill",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TechId",
                table: "Area",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_AddressRefId",
                table: "Ticket",
                column: "AddressRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_AreaRefId",
                table: "Ticket",
                column: "AreaRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CustomerRefId",
                table: "Ticket",
                column: "CustomerRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_MeterRefId",
                table: "Ticket",
                column: "MeterRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_StatusRefId",
                table: "Ticket",
                column: "StatusRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TechRefId",
                table: "Ticket",
                column: "TechRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_TechId",
                table: "Skill",
                column: "TechId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_TicketId",
                table: "Skill",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Meter_CustomerRefId",
                table: "Meter",
                column: "CustomerRefId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignTicketRequest_TechRefId",
                table: "AssignTicketRequest",
                column: "TechRefId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignTicketRequest_TicketRefId",
                table: "AssignTicketRequest",
                column: "TicketRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Area_TechId",
                table: "Area",
                column: "TechId");

            migrationBuilder.AddForeignKey(
                name: "FK_Area_Tech_TechId",
                table: "Area",
                column: "TechId",
                principalTable: "Tech",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignTicketRequest_Tech_TechRefId",
                table: "AssignTicketRequest",
                column: "TechRefId",
                principalTable: "Tech",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignTicketRequest_Ticket_TicketRefId",
                table: "AssignTicketRequest",
                column: "TicketRefId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meter_Customer_CustomerRefId",
                table: "Meter",
                column: "CustomerRefId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Tech_TechId",
                table: "Skill",
                column: "TechId",
                principalTable: "Tech",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Ticket_TicketId",
                table: "Skill",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Address_AddressRefId",
                table: "Ticket",
                column: "AddressRefId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Area_AreaRefId",
                table: "Ticket",
                column: "AreaRefId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Customer_CustomerRefId",
                table: "Ticket",
                column: "CustomerRefId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Meter_MeterRefId",
                table: "Ticket",
                column: "MeterRefId",
                principalTable: "Meter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Status_StatusRefId",
                table: "Ticket",
                column: "StatusRefId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Tech_TechRefId",
                table: "Ticket",
                column: "TechRefId",
                principalTable: "Tech",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
