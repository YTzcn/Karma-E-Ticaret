using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karma.DataAccess.Migrations
{
    public partial class CampaignProductFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CampaginProducts_ProductId",
                table: "CampaginProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaginProducts_Products_ProductId",
                table: "CampaginProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaginProducts_Products_ProductId",
                table: "CampaginProducts");

            migrationBuilder.DropIndex(
                name: "IX_CampaginProducts_ProductId",
                table: "CampaginProducts");
        }
    }
}
