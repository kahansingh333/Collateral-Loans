using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CollateralManagement.Migrations
{
    public partial class MyMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollateralLoans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    LoanId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CollateralType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollateralLoans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollateralGold",
                columns: table => new
                {
                    CollateralId = table.Column<int>(type: "int", nullable: false),
                    GoldOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearInGoldBought = table.Column<int>(type: "int", nullable: false),
                    GoldWeightinGrams = table.Column<int>(type: "int", nullable: false),
                    GoldRateperGram = table.Column<double>(type: "float", nullable: false),
                    GoldDepriciationRate = table.Column<double>(type: "float", nullable: false),
                    GoldPledgedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollateralGold", x => x.CollateralId);
                    table.ForeignKey(
                        name: "FK_CollateralGold_CollateralLoans_CollateralId",
                        column: x => x.CollateralId,
                        principalTable: "CollateralLoans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollateralHouse",
                columns: table => new
                {
                    CollateralId = table.Column<int>(type: "int", nullable: false),
                    HouseOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseArea = table.Column<int>(type: "int", nullable: false),
                    YearinBuilt = table.Column<int>(type: "int", nullable: false),
                    CurrentLandPricePerSqFt = table.Column<long>(type: "bigint", nullable: false),
                    CurrentStructurePrice = table.Column<long>(type: "bigint", nullable: false),
                    HouseDepriciationRate = table.Column<int>(type: "int", nullable: false),
                    PledgedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollateralHouse", x => x.CollateralId);
                    table.ForeignKey(
                        name: "FK_CollateralHouse_CollateralLoans_CollateralId",
                        column: x => x.CollateralId,
                        principalTable: "CollateralLoans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollateralLand",
                columns: table => new
                {
                    CollateralId = table.Column<int>(type: "int", nullable: false),
                    LandOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandArea = table.Column<int>(type: "int", nullable: false),
                    Pricepersquarefeet = table.Column<long>(type: "bigint", nullable: false),
                    YearInLandBought = table.Column<int>(type: "int", nullable: false),
                    LandDepriciationRate = table.Column<int>(type: "int", nullable: false),
                    PledgedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollateralLand", x => x.CollateralId);
                    table.ForeignKey(
                        name: "FK_CollateralLand_CollateralLoans_CollateralId",
                        column: x => x.CollateralId,
                        principalTable: "CollateralLoans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollateralGold");

            migrationBuilder.DropTable(
                name: "CollateralHouse");

            migrationBuilder.DropTable(
                name: "CollateralLand");

            migrationBuilder.DropTable(
                name: "CollateralLoans");
        }
    }
}
