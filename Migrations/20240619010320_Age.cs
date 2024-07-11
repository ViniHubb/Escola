using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escola.Migrations
{
    /// <inheritdoc />
    public partial class Age : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(127)",
                oldMaxLength: 127);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(127)",
                oldMaxLength: 127);

            migrationBuilder.AlterColumn<string>(
                name: "Classe",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(127)",
                oldMaxLength: 127);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Students",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Students",
                type: "nvarchar(127)",
                maxLength: 127,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Students",
                type: "nvarchar(127)",
                maxLength: 127,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Classe",
                table: "Students",
                type: "nvarchar(127)",
                maxLength: 127,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
