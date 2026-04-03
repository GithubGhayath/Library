using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingSettingtablewithconfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefualtBorrrowDays = table.Column<int>(type: "INT", nullable: false),
                    DefaultFinePerDay = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
