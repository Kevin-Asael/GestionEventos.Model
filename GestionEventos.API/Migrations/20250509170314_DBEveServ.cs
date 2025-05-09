using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionEventos.API.Migrations
{
    /// <inheritdoc />
    public partial class DBEveServ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Ponentes",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponentes", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lugar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Eventos_Tipos_TipoCodigo",
                        column: x => x.TipoCodigo,
                        principalTable: "Tipos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AsignarPonentes",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PonenteCodigo = table.Column<int>(type: "int", nullable: false),
                    EventoCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignarPonentes", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_AsignarPonentes_Eventos_EventoCodigo",
                        column: x => x.EventoCodigo,
                        principalTable: "Eventos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignarPonentes_Ponentes_PonenteCodigo",
                        column: x => x.PonenteCodigo,
                        principalTable: "Ponentes",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GestionarSesiones",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sala = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventoCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GestionarSesiones", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_GestionarSesiones_Eventos_EventoCodigo",
                        column: x => x.EventoCodigo,
                        principalTable: "Eventos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventoCodigo = table.Column<int>(type: "int", nullable: false),
                    ParticipanteCodigo = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Eventos_EventoCodigo",
                        column: x => x.EventoCodigo,
                        principalTable: "Eventos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Participantes_ParticipanteCodigo",
                        column: x => x.ParticipanteCodigo,
                        principalTable: "Participantes",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificados",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InscripcionCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificados", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Certificados_Inscripciones_InscripcionCodigo",
                        column: x => x.InscripcionCodigo,
                        principalTable: "Inscripciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetodoPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InscripcionCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Pagos_Inscripciones_InscripcionCodigo",
                        column: x => x.InscripcionCodigo,
                        principalTable: "Inscripciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsignarPonentes_EventoCodigo",
                table: "AsignarPonentes",
                column: "EventoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_AsignarPonentes_PonenteCodigo",
                table: "AsignarPonentes",
                column: "PonenteCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Certificados_InscripcionCodigo",
                table: "Certificados",
                column: "InscripcionCodigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_TipoCodigo",
                table: "Eventos",
                column: "TipoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_GestionarSesiones_EventoCodigo",
                table: "GestionarSesiones",
                column: "EventoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_EventoCodigo",
                table: "Inscripciones",
                column: "EventoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_ParticipanteCodigo",
                table: "Inscripciones",
                column: "ParticipanteCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_InscripcionCodigo",
                table: "Pagos",
                column: "InscripcionCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsignarPonentes");

            migrationBuilder.DropTable(
                name: "Certificados");

            migrationBuilder.DropTable(
                name: "GestionarSesiones");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Ponentes");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Participantes");

            migrationBuilder.DropTable(
                name: "Tipos");
        }
    }
}
