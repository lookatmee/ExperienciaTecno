using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExperienciaTecno.BackEnd.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class DeletePropertiesManufacturer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Manufacturers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Manufacturers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Manufacturers",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Manufacturers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }
    }
}
