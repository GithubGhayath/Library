using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingfinetablewithconfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    BorrowingRecordId = table.Column<int>(type: "int", nullable: false),
                    NumberOfLateDays = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    FineAmount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, defaultValue: 0m),
                    PaymentStatus = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fines_BorrowingRecords_BorrowingRecordId",
                        column: x => x.BorrowingRecordId,
                        principalTable: "BorrowingRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fines_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fines_BorrowingRecordId",
                table: "Fines",
                column: "BorrowingRecordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fines_PaymentMethodId",
                table: "Fines",
                column: "PaymentMethodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fines");
        }
    }
}
