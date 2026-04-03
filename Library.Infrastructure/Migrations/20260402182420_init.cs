using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "VARCHAR(1)", maxLength: 1, nullable: false),
                    City = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    Street = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phone = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_PersonId",
                table: "PhoneNumbers",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
