using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karma.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class spesificationAddContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spesification_Products_ProductId",
                table: "Spesification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Spesification",
                table: "Spesification");

            migrationBuilder.RenameTable(
                name: "Spesification",
                newName: "Spesifications");

            migrationBuilder.RenameIndex(
                name: "IX_Spesification_ProductId",
                table: "Spesifications",
                newName: "IX_Spesifications_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Spesifications",
                table: "Spesifications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Spesifications_Products_ProductId",
                table: "Spesifications",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spesifications_Products_ProductId",
                table: "Spesifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Spesifications",
                table: "Spesifications");

            migrationBuilder.RenameTable(
                name: "Spesifications",
                newName: "Spesification");

            migrationBuilder.RenameIndex(
                name: "IX_Spesifications_ProductId",
                table: "Spesification",
                newName: "IX_Spesification_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Spesification",
                table: "Spesification",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Spesification_Products_ProductId",
                table: "Spesification",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
