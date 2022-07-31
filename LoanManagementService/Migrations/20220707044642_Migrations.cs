using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagementService.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collaterals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaterals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAge = table.Column<int>(type: "int", nullable: false),
                    CustomerPhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    CustomerAccountNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanMaxAmount = table.Column<int>(type: "int", nullable: false),
                    Interest = table.Column<double>(type: "float", nullable: false),
                    LoanTenureInYears = table.Column<byte>(type: "tinyint", nullable: false),
                    TypeOfCollateralAccepted = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanId);
                });

            migrationBuilder.CreateTable(
                name: "CustomersLoans",
                columns: table => new
                {
                    CustomerLoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    LoanId = table.Column<int>(type: "int", nullable: false),
                    SanctionedAmount = table.Column<int>(type: "int", nullable: false),
                    IsCollateraled = table.Column<bool>(type: "bit", nullable: false),
                    EMI = table.Column<double>(type: "float", nullable: false),
                    CollateralId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersLoans", x => x.CustomerLoanId);
                    table.ForeignKey(
                        name: "FK_CustomersLoans_Collaterals_CollateralId",
                        column: x => x.CollateralId,
                        principalTable: "Collaterals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersLoans_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersLoans_Loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Collaterals",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "50 gms of gold Bought in January 2017 From KK Jewellery in Hyderabad" },
                    { 2, "3000 sq feet Land Located in Anantapur Bought in 2015 From JJ Properties, Now with Coconut Plantation" },
                    { 3, "1500 sq feet Two storeyed House with Two Bedrooms built in 2010 located in Hyderabad" },
                    { 4, "3500 sq feet Land Located in KR puram Bangalore Bought in 2010 from private owner ,Now with Banana Plantation" },
                    { 5, "70 gms of gold bought in 2019 From JO Jewellary in Chennai" },
                    { 6, "2000 sq feet Three storeyed home built in 2007 located in Sarjapur Bangalore Bought from private owner" },
                    { 7, "400 gms of gold bought in 2010 from RR Jewellary Coimbatore" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerAccountNumber", "CustomerAge", "CustomerFirstName", "CustomerLastName", "CustomerPhoneNumber" },
                values: new object[,]
                {
                    { 7, 1788765L, 27, "Chandan", "M", 7665663241L },
                    { 6, 2010201L, 35, "Srujana", "K", 9808997761L },
                    { 5, 1908765L, 45, "Ram", "Raj", 6324143454L },
                    { 2, 1501322L, 21, "George", "Antony", 7337004089L },
                    { 3, 1439087L, 21, "Varun", "Raj", 9312456892L },
                    { 1, 1301567L, 21, "Saicharan", "M", 8317670705L },
                    { 4, 1209873L, 21, "Vivek", "Boppudi", 6303129879L }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "LoanId", "Interest", "LoanMaxAmount", "LoanName", "LoanTenureInYears", "TypeOfCollateralAccepted" },
                values: new object[,]
                {
                    { 3, 8.3000000000000007, 5000000, "Loan3", (byte)8, "Land House" },
                    { 1, 5.9000000000000004, 500000, "Loan1", (byte)6, "Gold House" },
                    { 2, 7.7999999999999998, 1500000, "Loan2", (byte)7, "Gold Land House" },
                    { 4, 8.9000000000000004, 10000000, "Loan4", (byte)9, "Land" }
                });

            migrationBuilder.InsertData(
                table: "CustomersLoans",
                columns: new[] { "CustomerLoanId", "CollateralId", "CustomerId", "EMI", "IsCollateraled", "LoanId", "SanctionedAmount" },
                values: new object[,]
                {
                    { 2, 1, 3, 4300.0, false, 1, 300000 },
                    { 3, 2, 4, 8400.0, false, 2, 700000 },
                    { 5, 5, 7, 5300.0, false, 2, 400000 },
                    { 1, 3, 2, 30000.0, false, 3, 2000000 },
                    { 6, 6, 5, 10000.0, false, 3, 1000000 },
                    { 4, 4, 1, 46400.0, false, 4, 5000000 },
                    { 7, 7, 6, 30000.0, false, 4, 2500000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomersLoans_CollateralId",
                table: "CustomersLoans",
                column: "CollateralId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersLoans_CustomerId",
                table: "CustomersLoans",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomersLoans_LoanId",
                table: "CustomersLoans",
                column: "LoanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersLoans");

            migrationBuilder.DropTable(
                name: "Collaterals");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Loans");
        }
    }
}
