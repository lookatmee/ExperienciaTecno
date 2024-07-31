using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExperienciaTecno.BackEnd.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecificationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specifications_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_ProductId",
                table: "Specifications",
                column: "ProductId");
            
            migrationBuilder.Sql("INSERT INTO Specifications (Id, Label, Description, ProductId) SELECT Id, Label, Description, ProductId FROM Especification;");
            
            migrationBuilder.DropTable(
                name: "Especification");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especification_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Especification_ProductId",
                table: "Especification",
                column: "ProductId");
            
            migrationBuilder.Sql("INSERT INTO Especification (Id, Label, Description, ProductId) SELECT Id, Label, Description, ProductId FROM Specifications;");
            
            migrationBuilder.DropTable(
                name: "Specifications");
        }
    }
}
