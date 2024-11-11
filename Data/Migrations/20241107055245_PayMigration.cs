using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_.Data.Migrations
{
    /// <inheritdoc />
    public partial class PayMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Proformas",
                table: "Proformas");

            migrationBuilder.RenameTable(
                name: "Proformas",
                newName: "Proforma");

            migrationBuilder.RenameIndex(
                name: "IX_Proformas_ProductId",
                table: "Proforma",
                newName: "IX_Proforma_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proforma",
                table: "Proforma",
                column: "ProformaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Proforma",
                table: "Proforma");

            migrationBuilder.RenameTable(
                name: "Proforma",
                newName: "Proformas");

            migrationBuilder.RenameIndex(
                name: "IX_Proforma_ProductId",
                table: "Proformas",
                newName: "IX_Proformas_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proformas",
                table: "Proformas",
                column: "ProformaId");
        }
    }
}
