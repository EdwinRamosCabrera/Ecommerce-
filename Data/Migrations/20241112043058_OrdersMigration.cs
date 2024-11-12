using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ecommerce_.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrdersMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Proformas",
                newName: "Usuario");

            migrationBuilder.RenameColumn(
                name: "ProformaQuantity",
                table: "Proformas",
                newName: "Cantidad");

            migrationBuilder.RenameColumn(
                name: "ProductPrice",
                table: "Proformas",
                newName: "Precio");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Proformas",
                newName: "Producto_Id");

            migrationBuilder.RenameColumn(
                name: "ProformaId",
                table: "Proformas",
                newName: "Proforma_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Proformas_ProductId",
                table: "Proformas",
                newName: "IX_Proformas_Producto_Id");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Productos",
                newName: "Categoria_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_CategoryId",
                table: "Productos",
                newName: "IX_Productos_Categoria_Id");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Pagos",
                newName: "Usuario");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Productos",
                type: "text",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Usuario = table.Column<string>(type: "text", nullable: false),
                    Monto_Total = table.Column<decimal>(type: "numeric", nullable: false),
                    Pago_Id = table.Column<int>(type: "integer", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false),
                    Correo = table.Column<string>(type: "text", nullable: false),
                    Teléfono = table.Column<string>(type: "text", nullable: false),
                    Observaciones = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Pedidos_Pagos_Pago_Id",
                        column: x => x.Pago_Id,
                        principalTable: "Pagos",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Pedidos",
                columns: table => new
                {
                    Detalle_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pedido_Id = table.Column<int>(type: "integer", nullable: false),
                    Proforma_Id = table.Column<int>(type: "integer", nullable: false),
                    Producto_Nombre = table.Column<string>(type: "text", nullable: false),
                    Producto_Cantidad = table.Column<int>(type: "integer", nullable: false),
                    Producto_Precio = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Pedidos", x => x.Detalle_Id);
                    table.ForeignKey(
                        name: "FK_Detalle_Pedidos_Pedidos_Pedido_Id",
                        column: x => x.Pedido_Id,
                        principalTable: "Pedidos",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Detalle_Pedidos_Proformas_Proforma_Id",
                        column: x => x.Proforma_Id,
                        principalTable: "Proformas",
                        principalColumn: "Proforma_Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Pedidos_Pedido_Id",
                table: "Detalle_Pedidos",
                column: "Pedido_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Pedidos_Proforma_Id",
                table: "Detalle_Pedidos",
                column: "Proforma_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_Pago_Id",
                table: "Pedidos",
                column: "Pago_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle_Pedidos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "Proformas",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Producto_Id",
                table: "Proformas",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "Proformas",
                newName: "ProductPrice");

            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "Proformas",
                newName: "ProformaQuantity");

            migrationBuilder.RenameColumn(
                name: "Proforma_Id",
                table: "Proformas",
                newName: "ProformaId");

            migrationBuilder.RenameIndex(
                name: "IX_Proformas_Producto_Id",
                table: "Proformas",
                newName: "IX_Proformas_ProductId");

            migrationBuilder.RenameColumn(
                name: "Categoria_Id",
                table: "Productos",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_Categoria_Id",
                table: "Productos",
                newName: "IX_Productos_CategoryId");

            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "Pagos",
                newName: "UsuarioId");

            migrationBuilder.AlterColumn<bool>(
                name: "Estado",
                table: "Productos",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
