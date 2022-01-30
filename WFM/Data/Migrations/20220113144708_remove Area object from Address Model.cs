using Microsoft.EntityFrameworkCore.Migrations;

namespace WFM.Data.Migrations
{
    public partial class removeAreaobjectfromAddressModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Area_AreaRefId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_AreaRefId",
                table: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Address_AreaRefId",
                table: "Address",
                column: "AreaRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Area_AreaRefId",
                table: "Address",
                column: "AreaRefId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
