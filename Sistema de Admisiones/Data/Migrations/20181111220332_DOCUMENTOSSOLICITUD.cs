using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sistema_de_Admisiones.Data.Migrations
{
    public partial class DOCUMENTOSSOLICITUD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "URL_Record_Notas",
                table: "Solicitud_Admisiones",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "URL_Foto",
                table: "Solicitud_Admisiones",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "URL_Certificado_Medico",
                table: "Solicitud_Admisiones",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "URL_Acta_Nacimiento",
                table: "Solicitud_Admisiones",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "URL_Record_Notas",
                table: "Solicitud_Admisiones",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "URL_Foto",
                table: "Solicitud_Admisiones",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "URL_Certificado_Medico",
                table: "Solicitud_Admisiones",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "URL_Acta_Nacimiento",
                table: "Solicitud_Admisiones",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
