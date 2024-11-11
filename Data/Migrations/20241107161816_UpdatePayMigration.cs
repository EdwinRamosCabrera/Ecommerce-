using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ecommerce_.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePayMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<string>(type: "text", nullable: false),
                    Nombre_Tarjeta = table.Column<string>(type: "text", nullable: false),
                    Fecha_Pago = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Monto_Total = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.PaymentId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");

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
    }
}
