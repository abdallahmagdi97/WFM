using Microsoft.EntityFrameworkCore.Migrations;

namespace WFM.Data.Migrations
{
    public partial class addcustomeraddresseslookup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Address_AddressRefId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_AddressRefId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "AddressRefId",
                table: "Customer");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Address",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerRefId = table.Column<int>(nullable: false),
                    AddressRefId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddresses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerId",
                table: "Address",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Customer_CustomerId",
                table: "Address",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Customer_CustomerId",
                table: "Address");

            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropIndex(
                name: "IX_Address_CustomerId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Address");

            migrationBuilder.AddColumn<int>(
                name: "AddressRefId",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_AddressRefId",
                table: "Customer",
                column: "AddressRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Address_AddressRefId",
                table: "Customer",
                column: "AddressRefId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
