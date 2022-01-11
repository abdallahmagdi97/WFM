using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WFM.Data.Migrations
{
    public partial class AddingModelsandAPIControllers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tech",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    NationalID = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tech", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    TechId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Area_Tech_TechId",
                        column: x => x.TechId,
                        principalTable: "Tech",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    AreaRefId = table.Column<int>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    Latitude = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Area_AreaRefId",
                        column: x => x.AreaRefId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    NationalID = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    AddressRefId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Address_AddressRefId",
                        column: x => x.AddressRefId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Meter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: true),
                    CustomerRefId = table.Column<int>(nullable: false),
                    InstallationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meter_Customer_CustomerRefId",
                        column: x => x.CustomerRefId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    AreaRefId = table.Column<int>(nullable: false),
                    AddressRefId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true),
                    CustomerRefId = table.Column<int>(nullable: false),
                    MeterRefId = table.Column<int>(nullable: false),
                    TechRefId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: true),
                    StatusRefId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Address_AddressRefId",
                        column: x => x.AddressRefId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ticket_Area_AreaRefId",
                        column: x => x.AreaRefId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ticket_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ticket_Meter_MeterRefId",
                        column: x => x.MeterRefId,
                        principalTable: "Meter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ticket_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ticket_Tech_TechRefId",
                        column: x => x.TechRefId,
                        principalTable: "Tech",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    TechId = table.Column<int>(nullable: true),
                    TicketId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_Tech_TechId",
                        column: x => x.TechId,
                        principalTable: "Tech",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Skill_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_AreaRefId",
                table: "Address",
                column: "AreaRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Area_TechId",
                table: "Area",
                column: "TechId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_AddressRefId",
                table: "Customer",
                column: "AddressRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Meter_CustomerRefId",
                table: "Meter",
                column: "CustomerRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_TechId",
                table: "Skill",
                column: "TechId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_TicketId",
                table: "Skill",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_AddressRefId",
                table: "Ticket",
                column: "AddressRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_AreaRefId",
                table: "Ticket",
                column: "AreaRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CustomerId",
                table: "Ticket",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_MeterRefId",
                table: "Ticket",
                column: "MeterRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_StatusId",
                table: "Ticket",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TechRefId",
                table: "Ticket",
                column: "TechRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Meter");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Tech");
        }
    }
}
