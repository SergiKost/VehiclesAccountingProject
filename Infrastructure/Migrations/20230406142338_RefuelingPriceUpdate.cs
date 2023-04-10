using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RefuelingPriceUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefuelingPrice_Petrols_PetrolTypeId",
                table: "RefuelingPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_Waybills_RefuelingPrice_RefuelingPriceId",
                table: "Waybills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefuelingPrice",
                table: "RefuelingPrice");

            migrationBuilder.RenameTable(
                name: "RefuelingPrice",
                newName: "RefuelingPrices");

            migrationBuilder.RenameIndex(
                name: "IX_RefuelingPrice_PetrolTypeId",
                table: "RefuelingPrices",
                newName: "IX_RefuelingPrices_PetrolTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefuelingPrices",
                table: "RefuelingPrices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefuelingPrices_Petrols_PetrolTypeId",
                table: "RefuelingPrices",
                column: "PetrolTypeId",
                principalTable: "Petrols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Waybills_RefuelingPrices_RefuelingPriceId",
                table: "Waybills",
                column: "RefuelingPriceId",
                principalTable: "RefuelingPrices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefuelingPrices_Petrols_PetrolTypeId",
                table: "RefuelingPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_Waybills_RefuelingPrices_RefuelingPriceId",
                table: "Waybills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefuelingPrices",
                table: "RefuelingPrices");

            migrationBuilder.RenameTable(
                name: "RefuelingPrices",
                newName: "RefuelingPrice");

            migrationBuilder.RenameIndex(
                name: "IX_RefuelingPrices_PetrolTypeId",
                table: "RefuelingPrice",
                newName: "IX_RefuelingPrice_PetrolTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefuelingPrice",
                table: "RefuelingPrice",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefuelingPrice_Petrols_PetrolTypeId",
                table: "RefuelingPrice",
                column: "PetrolTypeId",
                principalTable: "Petrols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Waybills_RefuelingPrice_RefuelingPriceId",
                table: "Waybills",
                column: "RefuelingPriceId",
                principalTable: "RefuelingPrice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
