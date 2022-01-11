using Microsoft.EntityFrameworkCore.Migrations;

namespace WFM.Data.Migrations
{
    public partial class AddingAssignTicketRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignTicketRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketRefId = table.Column<int>(nullable: false),
                    TechRefId = table.Column<int>(nullable: false),
                    IsApprovedByTech = table.Column<bool>(nullable: false),
                    IsForceAssigned = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignTicketRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignTicketRequest_Tech_TechRefId",
                        column: x => x.TechRefId,
                        principalTable: "Tech",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignTicketRequest_Ticket_TicketRefId",
                        column: x => x.TicketRefId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignTicketRequest_TechRefId",
                table: "AssignTicketRequest",
                column: "TechRefId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignTicketRequest_TicketRefId",
                table: "AssignTicketRequest",
                column: "TicketRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignTicketRequest");
        }
    }
}
