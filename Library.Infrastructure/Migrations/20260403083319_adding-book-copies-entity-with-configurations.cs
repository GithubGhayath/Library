using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingbookcopiesentitywithconfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookCopies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    IsAvailabile = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCopies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookCopies_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCopies_BookId",
                table: "BookCopies",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCopies");
        }
    }
}
