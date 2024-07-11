using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escola.Migrations
{
    /// <inheritdoc />
    public partial class NewDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Students",
                type: "date",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Students",
                type: "datetime2",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldMaxLength: 50);
        }
    }
}
