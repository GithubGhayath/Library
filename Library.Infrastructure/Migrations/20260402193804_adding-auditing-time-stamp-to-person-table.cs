using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingauditingtimestamptopersontable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "People",
                type: "datetime2",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "People",
                type: "datetime2",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "People");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "People");
        }
    }
}
