using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixdeletebookflow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowingRecords_BookCopies_BookCopyId",
                table: "BorrowingRecords");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowingRecords_BookCopies_BookCopyId",
                table: "BorrowingRecords",
                column: "BookCopyId",
                principalTable: "BookCopies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowingRecords_BookCopies_BookCopyId",
                table: "BorrowingRecords");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowingRecords_BookCopies_BookCopyId",
                table: "BorrowingRecords",
                column: "BookCopyId",
                principalTable: "BookCopies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
