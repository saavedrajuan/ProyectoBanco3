using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoBanco1.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cajas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cbu = table.Column<int>(type: "int", nullable: false),
                    saldo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cajas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dni = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    apellido = table.Column<string>(type: "varchar(50)", nullable: false),
                    mail = table.Column<string>(type: "varchar(512)", nullable: false),
                    password = table.Column<string>(type: "varchar(50)", nullable: false),
                    intentosFallidos = table.Column<int>(type: "int", nullable: false),
                    bloqueado = table.Column<bool>(type: "bit", nullable: false),
                    esAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCaja = table.Column<int>(type: "int", nullable: false),
                    detalle = table.Column<string>(type: "varchar(100)", nullable: false),
                    monto = table.Column<double>(type: "float", nullable: false),
                    fecha = table.Column<DateTime>(type: "dateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Movimientos_Cajas_idCaja",
                        column: x => x.idCaja,
                        principalTable: "Cajas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(100)", nullable: false),
                    monto = table.Column<double>(type: "float", nullable: false),
                    pagado = table.Column<bool>(type: "bit", nullable: false),
                    metodo = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pagos_Usuarios_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pfs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idTitular = table.Column<int>(type: "int", nullable: false),
                    monto = table.Column<double>(type: "float", nullable: false),
                    fechaIni = table.Column<DateTime>(type: "dateTime", nullable: false),
                    fechaFin = table.Column<DateTime>(type: "dateTime", nullable: false),
                    tasa = table.Column<double>(type: "float", nullable: false),
                    pagado = table.Column<bool>(type: "bit", nullable: false),
                    cbu = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pfs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pfs_Usuarios_idTitular",
                        column: x => x.idTitular,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarjetas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idTitular = table.Column<int>(type: "int", nullable: false),
                    numero = table.Column<int>(type: "int", nullable: false),
                    codigoV = table.Column<int>(type: "int", nullable: false),
                    limite = table.Column<double>(type: "float", nullable: false),
                    consumos = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjetas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tarjetas_Usuarios_idTitular",
                        column: x => x.idTitular,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosCajas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idCaja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosCajas", x => x.id);
                    table.ForeignKey(
                        name: "FK_UsuariosCajas_Cajas_idCaja",
                        column: x => x.idCaja,
                        principalTable: "Cajas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosCajas_Usuarios_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_idCaja",
                table: "Movimientos",
                column: "idCaja");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_idUsuario",
                table: "Pagos",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Pfs_idTitular",
                table: "Pfs",
                column: "idTitular");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetas_idTitular",
                table: "Tarjetas",
                column: "idTitular");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosCajas_idCaja",
                table: "UsuariosCajas",
                column: "idCaja");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosCajas_idUsuario",
                table: "UsuariosCajas",
                column: "idUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimientos");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Pfs");

            migrationBuilder.DropTable(
                name: "Tarjetas");

            migrationBuilder.DropTable(
                name: "UsuariosCajas");

            migrationBuilder.DropTable(
                name: "Cajas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
