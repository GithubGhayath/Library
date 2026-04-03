using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingUserTablewithconfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    LibraryCardNumber = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    IsDeleted = table.Column<bool>(type: "BIT", maxLength: 5, nullable: false, defaultValue: false),
                    Password = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "NVARCHAR(5)", maxLength: 5, nullable: false, defaultValue: "User")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
