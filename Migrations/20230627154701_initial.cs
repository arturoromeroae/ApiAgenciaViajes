using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgenciaViajes.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actividad",
                columns: table => new
                {
                    idAct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameAct = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    duracionAct = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    precioAct = table.Column<decimal>(type: "decimal(18,2)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividad", x => x.idAct);
                });

            migrationBuilder.CreateTable(
                name: "Aerolinea",
                columns: table => new
                {
                    idAero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameAero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aerolinea", x => x.idAero);
                });

            migrationBuilder.CreateTable(
                name: "hoteles",
                columns: table => new
                {
                    idHot = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameHot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    addressHot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    priceHot = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoteles", x => x.idHot);
                });

            migrationBuilder.CreateTable(
                name: "tiposDocumentos",
                columns: table => new
                {
                    idTd = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameTd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiposDocumentos", x => x.idTd);
                });

            migrationBuilder.CreateTable(
                name: "vuelos",
                columns: table => new
                {
                    idVuelo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    destinoVuelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salidaVuelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateVuelo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    asientoVuelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    idAero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vuelos", x => x.idVuelo);
                    table.ForeignKey(
                        name: "FK_vuelos_Aerolinea_idAero",
                        column: x => x.idAero,
                        principalTable: "Aerolinea",
                        principalColumn: "idAero",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    idCl = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameCl = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    lnameCl = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    nroDocCl = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    birthdateCl = table.Column<DateTime>(type: "datetime2", unicode: false, maxLength: 100, nullable: false),
                    idTd = table.Column<int>(type: "int", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.idCl);
                    table.ForeignKey(
                        name: "FK_Cliente_tiposDocumentos_idTd",
                        column: x => x.idTd,
                        principalTable: "tiposDocumentos",
                        principalColumn: "idTd");
                });

            migrationBuilder.CreateTable(
                name: "trabajadores",
                columns: table => new
                {
                    idTrab = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameTrab = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lnameTrab = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nroDocTrab = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idTd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajadores", x => x.idTrab);
                    table.ForeignKey(
                        name: "FK_trabajadores_tiposDocumentos_idTd",
                        column: x => x.idTd,
                        principalTable: "tiposDocumentos",
                        principalColumn: "idTd",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "compras",
                columns: table => new
                {
                    idCr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subtotalCr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    totalCr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    idVuelo = table.Column<int>(type: "int", nullable: true),
                    idHot = table.Column<int>(type: "int", nullable: true),
                    idCl = table.Column<int>(type: "int", nullable: true),
                    idTb = table.Column<int>(type: "int", nullable: true),
                    idAct = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compras", x => x.idCr);
                    table.ForeignKey(
                        name: "FK_compras_Actividad_idAct",
                        column: x => x.idAct,
                        principalTable: "Actividad",
                        principalColumn: "idAct");
                    table.ForeignKey(
                        name: "FK_compras_Cliente_idCl",
                        column: x => x.idCl,
                        principalTable: "Cliente",
                        principalColumn: "idCl");
                    table.ForeignKey(
                        name: "FK_compras_hoteles_idHot",
                        column: x => x.idHot,
                        principalTable: "hoteles",
                        principalColumn: "idHot");
                    table.ForeignKey(
                        name: "FK_compras_trabajadores_idTb",
                        column: x => x.idTb,
                        principalTable: "trabajadores",
                        principalColumn: "idTrab");
                    table.ForeignKey(
                        name: "FK_compras_vuelos_idVuelo",
                        column: x => x.idVuelo,
                        principalTable: "vuelos",
                        principalColumn: "idVuelo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_idTd",
                table: "Cliente",
                column: "idTd");

            migrationBuilder.CreateIndex(
                name: "IX_compras_idAct",
                table: "compras",
                column: "idAct");

            migrationBuilder.CreateIndex(
                name: "IX_compras_idCl",
                table: "compras",
                column: "idCl");

            migrationBuilder.CreateIndex(
                name: "IX_compras_idHot",
                table: "compras",
                column: "idHot");

            migrationBuilder.CreateIndex(
                name: "IX_compras_idTb",
                table: "compras",
                column: "idTb");

            migrationBuilder.CreateIndex(
                name: "IX_compras_idVuelo",
                table: "compras",
                column: "idVuelo");

            migrationBuilder.CreateIndex(
                name: "IX_trabajadores_idTd",
                table: "trabajadores",
                column: "idTd");

            migrationBuilder.CreateIndex(
                name: "IX_vuelos_idAero",
                table: "vuelos",
                column: "idAero");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "compras");

            migrationBuilder.DropTable(
                name: "Actividad");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "hoteles");

            migrationBuilder.DropTable(
                name: "trabajadores");

            migrationBuilder.DropTable(
                name: "vuelos");

            migrationBuilder.DropTable(
                name: "tiposDocumentos");

            migrationBuilder.DropTable(
                name: "Aerolinea");
        }
    }
}
