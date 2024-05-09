﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EzpLaura2024.Migrations
{
    /// <inheritdoc />
    public partial class MigracionEjercicioFisico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "TipoEjercicios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "EjercicioFisico",
                columns: table => new
                {
                    EjercicioFisicoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoEjercicioID = table.Column<int>(type: "int", nullable: false),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoEmocionalInicio = table.Column<int>(type: "int", nullable: false),
                    EstadoEmocionalFin = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EjercicioFisico", x => x.EjercicioFisicoID);
                    table.ForeignKey(
                        name: "FK_EjercicioFisico_TipoEjercicios_TipoEjercicioID",
                        column: x => x.TipoEjercicioID,
                        principalTable: "TipoEjercicios",
                        principalColumn: "TipoEjercicioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EjercicioFisico_TipoEjercicioID",
                table: "EjercicioFisico",
                column: "TipoEjercicioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EjercicioFisico");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "TipoEjercicios");
        }
    }
}
