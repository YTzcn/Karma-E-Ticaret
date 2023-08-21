using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karma.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class spesificationAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spesification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Depth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QualityCheck = table.Column<bool>(type: "bit", nullable: false),
                    FreshnessDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhenPacketing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityPerBox = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spesification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spesification_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spesification_ProductId",
                table: "Spesification",
                column: "ProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spesification");
        }
    }
}
