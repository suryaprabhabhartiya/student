using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student.Migrations
{
    /// <inheritdoc />
    public partial class thirdmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BulkLedgers",
                columns: table => new
                {
                    Sr = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Academic_Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Session = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alloted_Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Voucher_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Voucher_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Roll_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Admno_UniqueId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fee_Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Faculty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Program = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Batch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Receipt_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fee_Head = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Due_Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Paid_Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Concession_Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Scholarship_Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reverse_Concession_Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Write_Off_Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adjusted_Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Refund_Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fund_TranCfer_Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BulkLedgers", x => x.Sr);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BulkLedgers");
        }
    }
}
