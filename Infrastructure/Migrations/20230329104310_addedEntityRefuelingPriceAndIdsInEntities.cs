using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class addedEntityRefuelingPriceAndIdsInEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RefuelingPriceId",
                table: "Waybills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalCost",
                table: "Waybills",
                type: "float",
                nullable: true);

            migrationBuilder.DropColumn(
               name: "RefuelingCardId",
               table: "Waybills");

            migrationBuilder.CreateTable(
                name: "RefuelingPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetrolTypeId = table.Column<int>(type: "int", nullable: true),
                    PetrolPrice = table.Column<double>(type: "float", nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefuelingPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefuelingPrice_Petrols_PetrolTypeId",
                        column: x => x.PetrolTypeId,
                        principalTable: "Petrols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Waybills_RefuelingPriceId",
                table: "Waybills",
                column: "RefuelingPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_RefuelingPrice_PetrolTypeId",
                table: "RefuelingPrice",
                column: "PetrolTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Waybills_RefuelingPrice_RefuelingPriceId",
                table: "Waybills",
                column: "RefuelingPriceId",
                principalTable: "RefuelingPrice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Waybills_RefuelingPrice_RefuelingPriceId",
                table: "Waybills");

            migrationBuilder.DropTable(
                name: "RefuelingPrice");

            migrationBuilder.DropIndex(
                name: "IX_Waybills_RefuelingPriceId",
                table: "Waybills");

            migrationBuilder.DropColumn(
                name: "RefuelingPriceId",
                table: "Waybills");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "Waybills");
        }
    }
}
