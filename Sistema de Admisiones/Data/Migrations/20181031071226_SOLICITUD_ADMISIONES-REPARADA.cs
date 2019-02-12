using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sistema_de_Admisiones.Data.Migrations
{
    public partial class SOLICITUD_ADMISIONESREPARADA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Solicitud",
                table: "Solicitud_Admisiones",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Fecha_Solicitud",
                table: "Solicitud_Admisiones",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
